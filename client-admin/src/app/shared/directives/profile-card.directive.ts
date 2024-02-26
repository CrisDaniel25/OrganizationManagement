import { OnInit, Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
  selector: '[profileCard]'
})
export class ProfileCardDirective implements OnInit {

  constructor(private el: ElementRef, private render: Renderer2) { }

  ngOnInit(): void {
    const $matCardProfile = this.el.nativeElement;
    this.render.setStyle($matCardProfile, 'box-shadow', '0px 0px 0px 0px rgba(0, 0, 0, 0.2), 0px 0px 0px 0px rgba(0, 0, 0, 0.14), 0px 0px 0px 0px rgba(0, 0, 0, 0.12)');
    this.render.setStyle($matCardProfile, 'border-radius', '0');
    this.render.setStyle($matCardProfile, 'padding', '10px');
    this.render.setStyle($matCardProfile, 'margin-bottom', '10px');
    this.render.setStyle($matCardProfile, 'height', '15%');
    this.render.setStyle($matCardProfile, 'border-bottom', '1px solid rgba(0, 0, 0, 0.12)');
  }
}
