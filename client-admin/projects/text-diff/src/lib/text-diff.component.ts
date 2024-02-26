import {
  ChangeDetectorRef,
  Component,
  Input,
  OnDestroy,
  OnInit,
  Output,
  EventEmitter,
  ViewChildren,
  QueryList,
  AfterViewInit
} from '@angular/core';
import { DiffContent, DiffPart, DiffTableFormat, DiffTableFormatOption, DiffTableRowResult, DiffResults } from './model/text-diff.model';
import { TextDiffService } from './text-diff.service';
import { Observable, Subscription } from 'rxjs'
import { TextDiffContainerDirective } from './directives/text-diff-container.directive';
import { ScrollDispatcher } from '@angular/cdk/scrolling';

@Component({
  selector: 'text-diff',
  template: `
    <div class="td-wrapper" [ngClass]="outerContainerClass" [ngStyle]="outerContainerStyle" *ngIf="!loading">

      <div [ngClass]="toolbarClass" [ngStyle]="toolbarStyle" *ngIf="showToolbar">
        <div class="td-toolbar-show-diff">
          <label class="td-checkbox-container">
            Only Show Lines with Differences ({{ diffsCount }})
            <input type="checkbox" id="showDiffs" [ngModel]="hideMatchingLines" (ngModelChange)="hideMatchingLinesChanged($event)" />
            <span class="checkmark"></span>
          </label>
        </div>
      </div>

      <div class="td-toolbar-select-format" *ngIf="showToolbar && showBtnToolbar">
        <div class="td-btn-group td-btn-group-toggle" data-toggle="buttons">
          <button
            *ngFor="let option of formatOptions"
            [ngClass]="{ active: format === option.value, disabled: !!option.disabled }"
            [name]="option.name"
            [id]="option.id"
            [disabled]="!!option.disabled"
            (click)="setDiffTableFormat(option.value)"
          >
            {{ option.label }}
          </button>
        </div>
      </div>

      <div class="td-table-wrapper" [ngClass]="compareRowsClass" [ngStyle]="compareRowsStyle">
        <!-- Right side-by-side -->
        <div class="td-table-container side-by-side" *ngIf="format === 'SideBySide'" id="td-left-compare-container" tdContainer cdkScrollable>
          <table class="td-table">
            <tbody>
              <tr *ngFor="let row of filteredTableRows; trackBy: trackTableRows">
                <td
                  scope="row"
                  class="fit-column line-number-col"
                  [ngClass]="{ 'delete-row': row.leftContent?.prefix === '-', 'empty-row': !row.leftContent?.lineContent }"
                >
                  {{ row.leftContent?.lineNumber !== -1 ? row.leftContent?.lineNumber : ' ' }}
                </td>
                <td
                  class="fit-column prefix-col"
                  [ngClass]="{ 'delete-row': row.leftContent?.prefix === '-', 'empty-row': !row.leftContent?.lineContent }"
                >
                  <span>{{ row.leftContent?.prefix || ' ' }}</span>
                </td>
                <td
                  class="content-col"
                  [ngClass]="{ 'delete-row': row.leftContent?.prefix === '-', 'empty-row': !row.leftContent?.lineContent }"
                  *ngIf="!row.hasDiffs"
                >
                  <span [innerHTML]="row.leftContent?.lineContent | formatLine"></span>
                </td>
                <td
                  class="content-col"
                  [ngClass]="{ 'delete-row': row.leftContent?.prefix === '-', 'empty-row': !row.leftContent?.lineContent }"
                  *ngIf="row.hasDiffs"
                >
                  <span
                    [innerHTML]="diff.content | formatLine"
                    [ngClass]="{ highlight: diff.isDiff }"
                    *ngFor="let diff of row.leftContent?.lineDiffs; trackBy: trackDiffs"
                  ></span>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <!-- Left side-by-side -->
        <div class="td-table-container side-by-side" *ngIf="format === 'SideBySide'" id="td-right-compare-container" tdContainer cdkScrollable>
          <table class="td-table">
            <tbody>
              <tr *ngFor="let row of filteredTableRows; trackBy: trackTableRows">
                <td
                  scope="row"
                  class="fit-column line-number-col"
                  [ngClass]="{ 'insert-row': row.rightContent?.prefix === '+', 'empty-row': !row.rightContent?.lineContent }"
                >
                  {{ row.rightContent?.lineNumber !== -1 ? row.rightContent?.lineNumber : ' ' }}
                </td>
                <td
                  class="fit-column prefix-col"
                  [ngClass]="{ 'insert-row': row.rightContent?.prefix === '+', 'empty-row': !row.rightContent?.lineContent }"
                >
                  <span>{{ row.rightContent?.prefix || ' ' }}</span>
                </td>
                <td
                  class="content-col"
                  [ngClass]="{ 'insert-row': row.rightContent?.prefix === '+', 'empty-row': !row.rightContent?.lineContent }"
                  *ngIf="!row.hasDiffs"
                >
                  <span [innerHTML]="row.rightContent?.lineContent | formatLine"></span>
                </td>
                <td
                  class="content-col"
                  [ngClass]="{ 'insert-row': row.rightContent?.prefix === '+', 'empty-row': !row.rightContent?.lineContent }"
                  *ngIf="row.hasDiffs"
                >
                  <span
                    [innerHTML]="diff.content | formatLine"
                    [ngClass]="{ highlight: diff.isDiff }"
                    *ngFor="let diff of row.rightContent?.lineDiffs; trackBy: trackDiffs"
                  ></span>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <!-- Line By Line - combined table -->
        <div class="td-table-container line-by-line" *ngIf="format === 'LineByLine'">
          <table class="td-table">
            <tbody>
              <tr *ngFor="let row of filteredTableRowsLineByLine; trackBy: trackTableRows">
                <td scope="row" class="fit-column line-number-col-left">{{ row.leftContent?.lineNumber }}</td>
                <td scope="row" class="fit-column line-number-col">{{ row.rightContent?.lineNumber }}</td>
                <td
                  class="fit-column prefix-col"
                  [ngClass]="{ 'delete-row': row.leftContent?.prefix === '-', 'insert-row': row.rightContent?.prefix === '+' }"
                >
                  <span>{{ row.leftContent?.prefix || row.rightContent?.prefix || ' ' }}</span>
                </td>
                <td
                  class="content-col"
                  [ngClass]="{ 'delete-row': row.leftContent?.prefix === '-', 'insert-row': row.rightContent?.prefix === '+' }"
                  *ngIf="!row.hasDiffs"
                >
                  <span [innerHTML]="row.leftContent?.lineContent | formatLine"></span>
                </td>
                <td
                  class="content-col"
                  [ngClass]="{ 'delete-row': row.leftContent?.prefix === '-', 'insert-row': row.rightContent?.prefix === '+' }"
                  *ngIf="row.hasDiffs && row.leftContent && row.rightContent?.lineDiffs && row.leftContent?.lineDiffs?.length !== 0"
                >
                  <span
                    [innerHTML]="diff.content | formatLine"
                    [ngClass]="{ highlight: diff.isDiff }"
                    *ngFor="let diff of row.leftContent?.lineDiffs; trackBy: trackDiffs"
                  ></span>
                </td>
                <td
                  class="content-col"
                  [ngClass]="{ 'delete-row': row.leftContent?.prefix === '-', 'insert-row': row.rightContent?.prefix === '+' }"
                  *ngIf="row.hasDiffs && row.rightContent && row.rightContent?.lineDiffs && row.rightContent?.lineDiffs?.length !== 0"
                >
                  <span
                    [innerHTML]="diff.content | formatLine"
                    [ngClass]="{ highlight: diff.isDiff }"
                    *ngFor="let diff of row.rightContent?.lineDiffs; trackBy: trackDiffs"
                  ></span>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  `,
  styles: [
    `
    .td-wrapper {
      display: grid;
      width: 100%;
      grid-row-gap: 10px;
      grid-template-columns: repeat(2, [col] 50%);
      grid-template-rows: repeat(2, [row] auto);
      background-color: #fff;
      color: #444;
    }

    .td-toolbar-show-diff {
      grid-column: 1;
      grid-row: 1;
    }

    .td-toolbar-select-format {
      margin-left: auto;
      grid-column: 2;
      grid-row: 1;
    }

    .td-table-container {
      grid-column: 1 / 2;
      grid-row: 2;
      width: 100%;
      max-width: 100%;
      overflow-x: auto;
    }

    .td-table-wrapper {
      display: flex;
      width: 200%;
    }

    .td-table {
      border: 1px solid darkgray;
      max-height: 50vh;
      width: 100%;
      max-width: 100%;
    }

    .fit-column {
      width: 1px;
      white-space: nowrap;
    }

    .line-number-col {
      position: relative; /* I am the fallback */

      /* Give it everything you got! (use an auto prefixer...) */
      position: -webkit-sticky;
      position: sticky;
      left: 0;
      top: auto;
      border-right: 1px solid #ddd;
      color: #999;
      text-align: right;
      background-color: #f7f7f7;
      padding-left: 10px;
      padding-right: 10px;
      font-size: 87.5%;
    }

    .line-number-col-left {
      color: #999;
      padding-left: 10px;
      padding-right: 10px;
      text-align: right;
      background-color: #f7f7f7;
      font-size: 87.5%;
    }

    .insert-row,
    .insert-row > .line-number-col {
      background-color: #dfd;
      border-color: #b4e2b4;
    }

    .delete-row,
    .delete-row > .line-number-col {
      background-color: #fee8e9;
      border-color: #e9aeae;
    }

    .empty-row {
      background-color: #f7f7f7;
      height: 24px;
    }

    .td-table td {
      border-top: 0;
      padding-top: 0;
      padding-bottom: 0;
      white-space: nowrap;
      max-width: 50%;
    }

    pre {
      margin-bottom: 0;
    }

    td.content-col {
      padding: 0;
      margin: 0;
      line-height: 24px;
    }

    td.prefix-col {
      padding-left: 10px;
      padding-right: 10px;
      line-height: 24px;
    }

    .td-btn-group {
      border-radius: 4px;
    }

    .td-btn-group button {
      background-color: rgba(23,162,184,.7); /* Green background */
      border: 1px solid #17a2b8; /* Green border */
      color: white; /* White text */
      cursor: pointer; /* Pointer/hand icon */
      float: left; /* Float the buttons side by side */
    }

    .td-btn-group button:not(:last-child) {
      border-right: none; /* Prevent double borders */
    }
    .td-btn-group button:first-child {
      -webkit-border-top-left-radius: 4px;
      -webkit-border-bottom-left-radius: 4px;
      -moz-border-radius-topleft: 4px;
      -moz-border-radius-bottomleft: 4px;
      border-top-left-radius: 4px;
      border-bottom-left-radius: 4px;
    }

    .td-btn-group button:last-child {
      -webkit-border-top-right-radius: 4px;
      -webkit-border-bottom-right-radius: 4px;
      -moz-border-radius-topright: 4px;
      -moz-border-radius-bottomright: 4px;
      border-top-right-radius: 4px;
      border-bottom-right-radius: 4px;
    }

    /* Clear floats (clearfix hack) */
    .td-btn-group:after {
      content: '';
      clear: both;
      display: table;
    }

    /* Add a background color on hover */
    .td-btn-group button:hover,
    .td-btn-group button.active {
      background-color: #17a2b8;
    }

    /* Customize the label (the container) */
    .td-checkbox-container {
      display: block;
      position: relative;
      padding-left: 21px;
      margin-bottom: 0;
      cursor: pointer;
      font-size: 16px;
      line-height: 28px;
      -webkit-user-select: none;
      -moz-user-select: none;
      -ms-user-select: none;
      user-select: none;
    }

    /* Hide the browser's default checkbox */
    .td-checkbox-container input {
      position: absolute;
      opacity: 0;
      cursor: pointer;
      height: 0;
      width: 0;
    }

    /* Create a custom checkbox */
    .checkmark {
      position: absolute;
      top: 7px;
      left: 0;
      height: 16px;
      width: 16px;
      background-color: #eee;
    }

    /* On mouse-over, add a grey background color */
    .td-checkbox-container:hover input ~ .checkmark {
      background-color: #ccc;
    }

    /* When the checkbox is checked, add a blue background */
    .td-checkbox-container input:checked ~ .checkmark {
      background-color: #17a2b8;
    }

    /* Create the checkmark/indicator (hidden when not checked) */
    .checkmark:after {
      content: "";
      position: absolute;
      display: none;
    }

    /* Show the checkmark when checked */
    .td-checkbox-container input:checked ~ .checkmark:after {
      display: block;
    }

    /* Style the checkmark/indicator */
    .td-checkbox-container .checkmark:after {
      left: 5px;
      top: 3px;
      width: 5px;
      height: 10px;
      border: solid white;
      border-width: 0 3px 3px 0;
      -webkit-transform: rotate(45deg);
      -ms-transform: rotate(45deg);
      transform: rotate(45deg);
    }

    .insert-row > .highlight {
      background-color: #acf2bd !important;
    }

    .delete-row > .highlight {
      background-color: #fdb8c0 !important;
    }`
  ]
})
export class TextDiffComponent implements OnInit, AfterViewInit, OnDestroy {
  private _hideMatchingLines = false;
  @ViewChildren(TextDiffContainerDirective) containers!: QueryList<TextDiffContainerDirective>;
  @Input() format: DiffTableFormat = 'SideBySide';
  @Input() left = '';
  @Input() right = '';
  @Input() diffContent!: Observable<DiffContent>;
  @Input() loading = false;
  @Input() showToolbar = true;
  @Input() showBtnToolbar = true;
  @Input()
  get hideMatchingLines() {
    return this._hideMatchingLines;
  }

  set hideMatchingLines(hide: boolean) {
    this.hideMatchingLinesChanged(hide);
  }
  @Input() outerContainerClass: string = '';
  @Input() outerContainerStyle: any;
  @Input() toolbarClass: string = '';
  @Input() toolbarStyle: any;
  @Input() compareRowsClass: string = '';
  @Input() compareRowsStyle: any;
  @Input() synchronizeScrolling = true;
  @Output() compareResults = new EventEmitter<DiffResults>();
  subscriptions: Subscription[] = [];
  tableRows: DiffTableRowResult[] = [];
  filteredTableRows: DiffTableRowResult[] = [];
  tableRowsLineByLine: DiffTableRowResult[] = [];
  filteredTableRowsLineByLine: DiffTableRowResult[] = [];
  diffsCount = 0;

  formatOptions: DiffTableFormatOption[] = [
    {
      id: 'side-by-side',
      name: 'side-by-side',
      label: 'Side by Side',
      value: 'SideBySide',
    },
    {
      id: 'line-by-line',
      name: 'line-by-line',
      label: 'Line by Line',
      value: 'LineByLine',
    },
  ];

  constructor(private scrollService: ScrollDispatcher, private diff: TextDiffService, private cd: ChangeDetectorRef) { }

  ngOnInit() {
    this.loading = true;
    if (this.diffContent) {
      this.subscriptions.push(
        this.diffContent.subscribe((content: any) => {
          this.loading = true;
          this.left = content.leftContent;
          this.right = content.rightContent;
          this.renderDiffs()
            .then(() => {
              this.cd.detectChanges();
              this.loading = false;
            })
            .catch(() => (this.loading = false));
        })
      );
    }
    this.renderDiffs()
      .then(() => (this.loading = false))
      .catch(e => (this.loading = false));
  }

  ngAfterViewInit() {
    this.initScrollListener();
  }

  ngOnDestroy(): void {
    if (this.subscriptions) {
      this.subscriptions.forEach(subscription => subscription.unsubscribe());
    }
  }

  hideMatchingLinesChanged(value: boolean) {
    this._hideMatchingLines = value;
    if (this.hideMatchingLines) {
      this.filteredTableRows = this.tableRows.filter(
        row => (row.leftContent && row.leftContent.prefix === '-') || (row.rightContent && row.rightContent.prefix === '+')
      );
      this.filteredTableRowsLineByLine = this.tableRowsLineByLine.filter(
        row => (row.leftContent && row.leftContent.prefix === '-') || (row.rightContent && row.rightContent.prefix === '+')
      );
    } else {
      this.filteredTableRows = this.tableRows;
      this.filteredTableRowsLineByLine = this.tableRowsLineByLine;
    }
  }

  setDiffTableFormat(format: DiffTableFormat) {
    this.format = format;
  }

  async renderDiffs() {
    try {
      this.diffsCount = 0;
      this.tableRows = await this.diff.getDiffsByLines(this.left, this.right);
      this.tableRowsLineByLine = this.tableRows.reduce((tableLineByLine: DiffTableRowResult[], row: DiffTableRowResult) => {
        if (!tableLineByLine) {
          tableLineByLine = [];
        }
        if (row.hasDiffs) {
          if (row.leftContent) {
            tableLineByLine.push({
              leftContent: row.leftContent,
              rightContent: null,
              belongTo: row.belongTo,
              hasDiffs: true,
              numDiffs: row.numDiffs,
            });
          }
          if (row.rightContent) {
            tableLineByLine.push({
              leftContent: null,
              rightContent: row.rightContent,
              belongTo: row.belongTo,
              hasDiffs: true,
              numDiffs: row.numDiffs,
            });
          }
        } else {
          tableLineByLine.push(row);
        }

        return tableLineByLine;
      }, []);
      this.diffsCount = this.tableRows.filter(row => row.hasDiffs).length;
      this.filteredTableRows = this.tableRows;
      this.filteredTableRowsLineByLine = this.tableRowsLineByLine;
      this.emitCompareResultsEvent();
    } catch (e) {
      throw e;
    }
  }

  emitCompareResultsEvent() {
    const diffResults: DiffResults = {
      hasDiff: this.diffsCount > 0,
      diffsCount: this.diffsCount,
      rowsWithDiff:
        this.tableRows
          .filter(row => row.hasDiffs)
          .map(row => {
            return {
              leftLineNumber: row.leftContent ? row.leftContent.lineNumber : null,
              rightLineNumber: row.rightContent ? row.rightContent.lineNumber : null,
              numDiffs: row.numDiffs,
            }
          }),

    };

    this.compareResults.emit(diffResults);
  }

  trackTableRows(index: any, row: DiffTableRowResult) {
    return row && row.leftContent ? row.leftContent.lineContent : row && row.rightContent ? row.rightContent.lineContent : undefined;
  }

  trackDiffs(index: any, diff: DiffPart) {
    return diff && diff.content ? diff.content : undefined;
  }

  initScrollListener() {
    this.subscriptions.push((<any>this.scrollService).scrolled().subscribe((scrollableEv: any) => {
      if (scrollableEv && this.synchronizeScrolling) {
        const scrollableId = scrollableEv.getElementRef().nativeElement.id;
        const nonScrolledContainer = this.containers.find(container => container.id !== scrollableId);
        if (nonScrolledContainer) {
          nonScrolledContainer.element.scrollTo({
            top: scrollableEv.measureScrollOffset('top'),
            left: scrollableEv.measureScrollOffset('left'),
          });
        }
      }
    }));
  }
}
