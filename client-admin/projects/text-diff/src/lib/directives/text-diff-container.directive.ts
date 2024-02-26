import { Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector: '[tdContainer]'
})
export class TextDiffContainerDirective {
  @Input() id: string = '';

  element: HTMLTableHeaderCellElement;

  constructor(private _el: ElementRef) {
    this.element = _el.nativeElement;
  }
}
