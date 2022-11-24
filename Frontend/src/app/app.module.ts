import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {routing} from './app-routing.module';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {HashLocationStrategy, LocationStrategy} from '@angular/common';
import {MatSelectModule} from '@angular/material/select';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatInputModule} from '@angular/material/input';
import {MatOptionModule} from '@angular/material/core';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import {MAT_TOOLTIP_DEFAULT_OPTIONS, MatTooltipDefaultOptions} from '@angular/material/tooltip';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDividerModule} from '@angular/material/divider';
import {MatTabsModule} from '@angular/material/tabs';
import {MatRadioModule} from '@angular/material/radio';
import {MatCardModule} from '@angular/material/card';
import {MatListModule} from '@angular/material/list';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MenuComponent} from "./menu/menu.component";
import {MatMenuModule} from "@angular/material/menu";
import { SlushMachineComponent } from './slush-machine/slush-machine.component';
import { SlushMachineStatusComponent } from './slush-machine/slush-machine-status/slush-machine-status.component';
import {RouterModule} from "@angular/router";
import { SlushMachineAdminComponent } from './slush-machine/slush-machine-admin/slush-machine-admin.component';

export const tooltipDefaults: MatTooltipDefaultOptions = {
    showDelay: 1200,
    hideDelay: 100,
    touchendHideDelay: 1000,
};

const materialModules = [
    MatSelectModule,
    MatButtonModule,
    MatCheckboxModule,
    MatAutocompleteModule,
    MatInputModule,
    MatOptionModule,
    MatProgressBarModule,
    MatIconModule,
    MatDialogModule,
    MatSnackBarModule,
    MatDividerModule,
    MatTabsModule,
    MatRadioModule,
    MatCardModule,
    MatListModule,
    MatSlideToggleModule,
    MatMenuModule
];

const customComponents = [
    MenuComponent,
    SlushMachineComponent,
    SlushMachineStatusComponent,
    SlushMachineAdminComponent
];

@NgModule({
    declarations: [
        AppComponent,
        customComponents
    ],
    imports: [
        routing,
        BrowserModule,
        HttpClientModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        materialModules
    ],
    providers: [
        // {provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true},
        {provide: LocationStrategy, useClass: HashLocationStrategy},
        {provide: MAT_TOOLTIP_DEFAULT_OPTIONS, useValue: tooltipDefaults}
    ],
    entryComponents: [
        customComponents
    ],
    exports: [RouterModule],
    bootstrap: [AppComponent]
})
export class AppModule {
}
