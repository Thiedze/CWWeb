import {RouterModule, Routes} from '@angular/router';
import {
    SlushMachineStatusComponent
} from "./component/slush-machine/slush-machine-status/slush-machine-status.component";
import {SlushMachineAdminComponent} from "./component/slush-machine/slush-machine-admin/slush-machine-admin.component";
import {AuthGuard} from "./service/auth.guard";
import {LoginComponent} from "./component/login/login.component";


const appRoutes: Routes = [
    {path: 'slush_machine_status', component: SlushMachineStatusComponent, canActivate: [AuthGuard]},
    {path: 'slush_machine_admin', component: SlushMachineAdminComponent, canActivate: [AuthGuard]},
    {path: 'login', component: LoginComponent},
    {path: '**', redirectTo: 'slush_machine_status'}
];

export const routing = RouterModule.forRoot(appRoutes);
