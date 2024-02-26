import { Directive, ElementRef, OnInit, Renderer2 } from '@angular/core';

@Directive({
  selector: '[stylingDialogTitle]'
})
export class StylingDialogTitleDirective implements OnInit {

  constructor(private render: Renderer2) { }

  ngOnInit(): void {
    const matDialogTitle = document.querySelector('.mat-dialog-title');
    this.render.setStyle(matDialogTitle, 'display', 'flex');
  }
}
