import {Component} from '@angular/core';

@Component({
    selector: 'app-slush-machine-status',
    templateUrl: './slush-machine-status.component.html',
    styleUrls: ['./slush-machine-status.component.scss']
})
export class SlushMachineStatusComponent {

    public leftLevel: number;

    constructor() {
        this.leftLevel = 0;
    }

}
