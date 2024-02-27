import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';

import { TranslateLoader, TranslateModule, TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';

import { NgChartsModule } from 'ng2-charts';
import { NgxJsonViewerModule } from 'ngx-json-viewer';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

/* @Custom library for text difference  */
import { TextDiffModule, initializerTranslationFactoy } from 'text-diff';

/* @Component partials  */
import { ProgressSpinerComponent } from './core/components/partials/progress-spiner/progress-spiner.component';
import { SideNavContentComponent } from './core/components/partials/side-nav-content/side-nav-content.component';
import { BreadcrumbComponent } from './core/components/partials/breadcrumb/breadcrumb.component';
import { FooterComponent } from './core/components/partials/footer/footer.component';
import { NavBarComponent } from './core/components/partials/nav-bar/nav-bar.component';

/* @Component core miscellaneous imports */
import { GenericDialogErrorComponent } from './core/components/miscellaneous/generic-dialog-error/generic-dialog-error.component';
import { GenericDialogSuccessComponent } from './core/components/miscellaneous/generic-dialog-success/generic-dialog-success.component';
import { GenericDialogInfoComponent } from './core/components/miscellaneous/generic-dialog-info/generic-dialog-info.component';
import { GenericDialogWarningComponent } from './core/components/miscellaneous/generic-dialog-warning/generic-dialog-warning.component';

/* @Component core reusable imports */
import { PageNotFoundComponent } from './core/components/pages/page-not-found/page-not-found.component';
import { InternalServerErrorComponent } from './core/components/pages/internal-server-error/internal-server-error.component';

/* @angular/material imports */
import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatMenuModule } from '@angular/material/menu';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSelectModule } from '@angular/material/select';
import {
  MatPaginatorIntl,
  MatPaginatorModule,
} from '@angular/material/paginator';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatTabsModule } from '@angular/material/tabs';
import { MatBadgeModule } from '@angular/material/badge';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTreeModule } from '@angular/material/tree';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

/* @State Management imports */
import { NgxsModule } from '@ngxs/store';
import { NgxsStoragePluginModule } from '@ngxs/storage-plugin';
import { sharedStates } from './shared/store/index';

/* @Services imports */
import { SessionTimeoutService } from './core/services/session-timeout.service';

/* @Shared imports */
import { DynamicGridComponent } from './shared/components/dynamic-grid/dynamic-grid.component';
import { DynamicFormComponent } from './shared/components/dynamic-form/dynamic-form.component';

/* Fields for dynamic forms */
import { InputComponent } from './shared/components/fields/input/input.component';
import { ButtonComponent } from './shared/components/fields/button/button.component';
import { SelectComponent } from './shared/components/fields/select/select.component';
import { SelectWithApiResultComponent } from './shared/components/fields/select-with-api-result/select-with-api-result.component';
import { DateComponent } from './shared/components/fields/date/date.component';
import { RadioButtonComponent } from './shared/components/fields/radio-button/radio-button.component';
import { CheckBoxComponent } from './shared/components/fields/check-box/check-box.component';
import { TextAreaComponent } from './shared/components/fields/text-area/text-area.component';
import { DateRangeComponent } from './shared/components/fields/date-range/date-range.component';

/* @Component feature Administration Component import */
import { LoginComponent } from './features/administration/pages/login/login.component';
import { RegisterComponent } from './features/administration/pages/register/register.component';
import { ForgotPasswordComponent } from './features/administration/pages/forgot-password/forgot-password.component';
import { RecoverPasswordComponent } from './features/administration/pages/recover-password/recover-password.component';
import { ChangePasswordComponent } from './features/administration/pages/change-password/change-password.component';

import { HomeComponent } from './features/administration/pages/home/home.component';
import { DashboardComponent } from './features/administration/pages/dashboard/dashboard.component';

import { UserListComponent } from './features/administration/pages/user-list/user-list.component';
import { UserComponent } from './features/administration/pages/user/user.component';

import { AuditComponent } from './features/administration/pages/audit/audit.component';
import { AuditListComponent } from './features/administration/pages/audit-list/audit-list.component';

import { RoleListComponent } from './features/administration/pages/role-list/role-list.component';
import { RoleComponent } from './features/administration/pages/role/role.component';

/* @Component feature Organization Component import */
import { ClientListComponent } from './features/organization/pages/client-list/client-list.component';
import { ClientComponent } from './features/organization/pages/client/client.component';
import { ClientConfirmDeleteComponent } from './features/organization/pages/client-confirm-delete/client-confirm-delete.component';
import { EmployeeComponent } from './features/organization/pages/employee/employee.component';
import { EmployeeListComponent } from './features/organization/pages/employee-list/employee-list.component';
import { EmployeeConfirmDeleteComponent } from './features/organization/pages/employee-confirm-delete/employee-confirm-delete.component';

/* @Directives imports */
import { DragNDropDirective, SideNavAnimationDirective, DynamicFieldDirective, ProfileCardDirective, StylingDialogTitleDirective, BorderlessAccordionStyleDirective } from './shared/directives/index';

/* @Interceptor Provider imports */
import { httpInterceptorProviders } from './core/interceptor';

/* @Pipes imports */
import { SortByPipe } from './shared/pipes/sort-by.pipe';

/* Paginator translation service */
import { CustomPaginatorService } from './core/services/custom-paginator.service';

/* AoT requires an exported function for factories */
export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    GenericDialogErrorComponent,
    GenericDialogSuccessComponent,
    GenericDialogInfoComponent,
    GenericDialogWarningComponent,
    DashboardComponent,
    UserListComponent,
    UserComponent,
    ChangePasswordComponent,
    AuditComponent,
    AuditListComponent,
    PageNotFoundComponent,
    SideNavContentComponent,
    FooterComponent,
    NavBarComponent,
    InternalServerErrorComponent,
    BreadcrumbComponent,
    DynamicGridComponent,
    DynamicFormComponent,
    RecoverPasswordComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    DragNDropDirective,
    ProgressSpinerComponent,
    RoleListComponent,
    RoleComponent,
    DynamicFieldDirective,
    InputComponent,
    ButtonComponent,
    SelectComponent,
    DateComponent,
    RadioButtonComponent,
    CheckBoxComponent,
    TextAreaComponent,
    DateRangeComponent,
    SortByPipe,
    SideNavAnimationDirective,
    ProfileCardDirective,
    StylingDialogTitleDirective,
    BorderlessAccordionStyleDirective,
    SelectWithApiResultComponent,
    ClientListComponent,
    ClientComponent,
    ClientConfirmDeleteComponent,
    EmployeeComponent,
    EmployeeListComponent,
    EmployeeConfirmDeleteComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatSliderModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatChipsModule,
    MatCardModule,
    MatButtonToggleModule,
    MatInputModule,
    MatDividerModule,
    MatListModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    MatIconModule,
    MatGridListModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatTableModule,
    MatCheckboxModule,
    MatExpansionModule,
    MatSortModule,
    MatSlideToggleModule,
    MatSelectModule,
    MatPaginatorModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatAutocompleteModule,
    MatMenuModule,
    MatTabsModule,
    MatBadgeModule,
    MatTooltipModule,
    MatProgressBarModule,
    MatTreeModule,
    NgChartsModule,
    NgxJsonViewerModule,
    TextDiffModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: true
    }),
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory
    }),
    NgxsModule.forRoot([...sharedStates]),
    NgxsStoragePluginModule.forRoot({
      key: 'SessionState'
    }),
    ToastrModule.forRoot({
      timeOut: 3500,
      closeButton: true,
      preventDuplicates: true,
      positionClass: 'toast-bottom-right',
      newestOnTop: true,
      toastClass: 'toast-icon'
    }),
  ],
  exports: [
    TranslateModule
  ],
  providers: [
    SessionTimeoutService,
    httpInterceptorProviders,
    {
      provide: APP_INITIALIZER,
      useFactory: initializerTranslationFactoy,
      deps: [TranslateService],
      multi: true
    },
    { provide: MatPaginatorIntl, deps: [TranslateService], useFactory: (translateService: TranslateService) => new CustomPaginatorService(translateService).getPaginatorIntl() }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
