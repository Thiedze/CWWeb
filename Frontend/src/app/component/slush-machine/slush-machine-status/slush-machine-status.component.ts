import {Component} from '@angular/core';
import {SlushMachine} from "../../../domain/slush-machine";

@Component({
    selector: 'app-slush-machine-status',
    templateUrl: './slush-machine-status.component.html',
    styleUrls: ['./slush-machine-status.component.scss']
})
export class SlushMachineStatusComponent {

    public show: boolean = true;
    public leftSlushMachine: SlushMachine;
    public rightSlushMachine: SlushMachine;

    constructor() {
        this.leftSlushMachine = new SlushMachine();
        this.leftSlushMachine.id = 'left';
        this.leftSlushMachine.level = 10;
        this.leftSlushMachine.color = 'lime';

        this.rightSlushMachine = new SlushMachine();
        this.rightSlushMachine.id = 'right';
        this.rightSlushMachine.level = 90;
        this.rightSlushMachine.color = 'blue';
    }

    public onLoad(): void {
        this.show = true;
    }

    public getLevel(slushMachine: SlushMachine, offset: number = 0): number {
        // gradient starts at 70%
        if (slushMachine.level != undefined) {
            return ((slushMachine.level / 100) * 70) + offset;
        }
        return 0;
    }

}
