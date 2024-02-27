import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

/* @Login & Change password imports */
import { LoginComponent } from './features/administration/pages/login/login.component';
import { RegisterComponent } from './features/administration/pages/register/register.component';
import { ChangePasswordComponent } from './features/administration/pages/change-password/change-password.component';

/* @Auth guard services imports */
import { AuthGuardService } from './core/guards/auth-guard.service';

/* @Home Component parent layout import */
import { HomeComponent } from './features/administration/pages/home/home.component';

/* @Dashboard & monitoring component import */
import { DashboardComponent } from './features/administration/pages/dashboard/dashboard.component';

/* @Constants imports */
import { MenuRoles } from './core/constants/menu-roles.constant';

/* @User Component & CRUD management */
import { UserListComponent } from './features/administration/pages/user-list/user-list.component';
import { UserComponent } from './features/administration/pages/user/user.component';

/* @Role Component & CRUD management */
import { RoleListComponent } from './features/administration/pages/role-list/role-list.component';
import { RoleComponent } from './features/administration/pages/role/role.component';

/* @Audit Component & CRUD management */
import { AuditListComponent } from './features/administration/pages/audit-list/audit-list.component';
import { AuditComponent } from './features/administration/pages/audit/audit.component';

/* @Client Component & CRUD management */
import { ClientListComponent } from './features/organization/pages/client-list/client-list.component';
import { ClientComponent } from './features/organization/pages/client/client.component';

/* @Employee Component & CRUD management */
import { EmployeeComponent } from './features/organization/pages/employee/employee.component';

/* @Page Not Found Component & route for a 404 page */
import { PageNotFoundComponent } from './core/components/pages/page-not-found/page-not-found.component';
import { ClientConfirmDeleteComponent } from './features/organization/pages/client-confirm-delete/client-confirm-delete.component';
import { EmployeeConfirmDeleteComponent } from './features/organization/pages/employee-confirm-delete/employee-confirm-delete.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'user/:id/change-password',
    component: ChangePasswordComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuardService],
    children: [
      {
        path: '',
        component: DashboardComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.DASHBOARD,
        },
      },
      {
        path: 'client-list',
        component: ClientListComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.CLIENTS,
        },
      },
      {
        path: 'client',
        component: ClientComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.CLIENTS_CREATE,
        },
      },
      {
        path: 'client/:id',
        component: ClientComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.CLIENTS_UPDATE,
        },
      },
      {
        path: 'client/:id/delete',
        component: ClientConfirmDeleteComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.CLIENTS_DELETE,
        },
      },
      {
        path: 'client/:clientId/employee',
        component: EmployeeComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.EMPLOYEES_CREATE,
        },
      },
      {
        path: 'client/:clientId/employee/:id',
        component: EmployeeComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.EMPLOYEES_UPDATE,
        },
      },
      {
        path: 'client/:clientId/employee/:id/delete',
        component: EmployeeConfirmDeleteComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.EMPLOYEES_DELETE,
        },
      },
      {
        path: 'user-list',
        component: UserListComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.USERS,
        },
      },
      {
        path: 'user',
        component: UserComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.USERS_CREATE,
        },
      },
      {
        path: 'user/:id',
        component: UserComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.USERS_UPDATE,
        },
      },
      {
        path: 'user/:id/view',
        component: UserComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.USERS,
        },
      },
      {
        path: 'role-list',
        component: RoleListComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.ROLES,
        },
      },
      {
        path: 'role',
        component: RoleComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.ROLES_CREATE,
        },
      },
      {
        path: 'role/:id',
        component: RoleComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.ROLES_UPDATE,
        },
      },
      {
        path: 'role/:id/view',
        component: RoleComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.ROLES,
        },
      },
      {
        path: 'audit-list',
        component: AuditListComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.AUDITS,
        },
      },
      {
        path: 'audit/:id/view',
        component: AuditComponent,
        canActivate: [AuthGuardService],
        data: {
          expectedRoles: MenuRoles.AUDITS,
        },
      },
    ],
  },
  {
    path: '**', pathMatch: 'full',
    component: PageNotFoundComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
