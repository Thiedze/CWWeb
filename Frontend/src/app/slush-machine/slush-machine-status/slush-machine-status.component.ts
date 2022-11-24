import {Component, ElementRef, ViewChild} from '@angular/core';

@Component({
    selector: 'app-slush-machine-status',
    templateUrl: './slush-machine-status.component.html',
    styleUrls: ['./slush-machine-status.component.scss']
})
export class SlushMachineStatusComponent {

    @ViewChild("slush_machine") background: ElementRef | undefined;
    public width: number = 0;
    public top: number = 0;
    public left: number = 0;
    public height: number = 0;
    public leftLevel: number = 20;
    public show: boolean = true;

    constructor() {
    }

    onLoad() {
        this.width = this.background?.nativeElement.width;
        this.height = this.background?.nativeElement.height;
        this.show = true;
    }
}
