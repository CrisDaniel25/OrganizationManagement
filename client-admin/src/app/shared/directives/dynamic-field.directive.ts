import { ComponentFactoryResolver, ComponentRef, Directive, Input, Renderer2, ViewContainerRef } from '@angular/core';
import { FieldConfig } from '../interfaces';
import { FormGroup } from '@angular/forms';

import { fieldComponents } from 'src/app/core/constants/field-components.constant';

@Directive({
  selector: '[dynamicField]'
})
export class DynamicFieldDirective {
  @Input() field!: FieldConfig;
  @Input() group!: FormGroup;

  componentRef!: ComponentRef<any>;

  constructor(
    private render: Renderer2,
    private container: ViewContainerRef,
    private resolver: ComponentFactoryResolver,
  ) { }

  ngOnInit() {
    const componentType = this.findComponent(this.field.type);

    if (componentType) {
      const factory = this.resolver.resolveComponentFactory(
        componentType as any
      );

      this.componentRef = this.container.createComponent(factory);
      this.componentRef.instance.field = this.field;
      this.componentRef.instance.group = this.group;

      if (Array.isArray(this.field.classes) && this.field.classes.length > 0)
        this.field.classes.map(inputClass => this.render.addClass(this.componentRef.location.nativeElement, inputClass));
    }
  }

  findComponent(type: string | undefined) {
    if (!!type) {
      const field = fieldComponents.find((component) => component.type == type);
      return field?.component;
    }

    return null;
  }
}
