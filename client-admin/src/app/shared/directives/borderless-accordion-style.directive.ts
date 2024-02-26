import { Directive, ElementRef, OnInit, Renderer2 } from '@angular/core';

@Directive({
  selector: '[borderlessAccordionStyle]'
})
export class BorderlessAccordionStyleDirective implements OnInit {

  constructor(private el: ElementRef, private render: Renderer2) { }

  ngOnInit(): void {
    this.render.setStyle(this.el.nativeElement, 'border-top-left-radius', '0px');
    this.render.setStyle(this.el.nativeElement, 'border-top-right-radius', '0px');
    this.render.setStyle(this.el.nativeElement, 'border-bottom-left-radius', '0px');
    this.render.setStyle(this.el.nativeElement, 'border-bottom-right-radius', '0px');
  }
}
