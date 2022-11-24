import {RouterModule, Routes} from '@angular/router';
import {SlushMachineStatusComponent} from "./slush-machine/slush-machine-status/slush-machine-status.component";
import {AppComponent} from "./app.component";
import {SlushMachineAdminComponent} from "./slush-machine/slush-machine-admin/slush-machine-admin.component";


const appRoutes: Routes = [
    {path : 'slush_machine_status', component : SlushMachineStatusComponent},
    {path : 'slush_machine_admin', component : SlushMachineAdminComponent},
    {path: '**', redirectTo: 'slush_machine_status'}
];

export const routing = RouterModule.forRoot(appRoutes);
