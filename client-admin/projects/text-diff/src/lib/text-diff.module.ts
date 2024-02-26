import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';

import { ScrollingModule } from '@angular/cdk/scrolling';

import { TextDiffComponent } from './text-diff.component';

import { TextDiffContainerDirective } from './directives/text-diff-container.directive';

import { FormatLinePipe } from './pipes/format-line.pipe';

@NgModule({
  declarations: [
    TextDiffComponent,
    TextDiffContainerDirective,
    FormatLinePipe
  ],
  imports: [CommonModule, FormsModule, ScrollingModule],
  exports: [
    TextDiffComponent
  ],
  providers: []
})
export class TextDiffModule { }
