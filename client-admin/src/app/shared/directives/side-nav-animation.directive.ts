import { Directive, HostListener, Input, Renderer2 } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Directive({
  selector: '[sideNavAnimation]'
})
export class SideNavAnimationDirective {
  @Input() sidenav!: MatSidenav;

  constructor(private readonly renderer: Renderer2) { }

  @HostListener('click', ['$event']) onClick($event: any) {
    $event.preventDefault();
    $event.stopPropagation();
    const isSideNavOpened = this.sidenav?.opened;

    const $matSidenav = (<any>this.sidenav)._elementRef.nativeElement;

    const $matSidenavContent = this.sidenav._container?._content.getElementRef().nativeElement;

    if (isSideNavOpened) {
      this.sidenav?.toggle();
      window.setTimeout(() => {
        this.renderer.setStyle($matSidenav, 'width', '0px');
        this.renderer.setStyle(
          $matSidenav,
          'transform',
          'translate3d(0, 0, 0)'
        );
        window.setTimeout(() => {
          this.renderer.setStyle($matSidenav, 'width', '60px');
          this.renderer.setStyle($matSidenav, 'transition', 'width 0.3s');
          this.renderer.setStyle($matSidenav, 'visibility', 'visible');
          this.renderer.setStyle($matSidenavContent, 'margin-left', '60px');
          this.renderer.setStyle(document.querySelector('.mat-expansion-panel-body'), 'padding', '0');
        }, 100);
      }, 800);
    } else {
      this.renderer.removeStyle($matSidenav, 'width');
      this.renderer.removeStyle($matSidenav, 'transition');
      this.renderer.removeStyle($matSidenav, 'visibility');
      this.renderer.removeStyle($matSidenav, 'transform');
      this.renderer.removeStyle($matSidenavContent, 'margin-left');
      this.renderer.removeStyle(document.querySelector('.mat-expansion-panel-body'), 'padding')
      this.sidenav?.toggle();
    }
  }
}
