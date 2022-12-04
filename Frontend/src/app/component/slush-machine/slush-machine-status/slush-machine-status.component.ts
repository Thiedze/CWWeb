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
    this.leftSlushMachine.id= 'left';
    this.leftSlushMachine.level = 50;

    this.rightSlushMachine = new SlushMachine();
    this.rightSlushMachine.id= 'right';
    this.rightSlushMachine.level = 90;
  }

  public onLoad(): void {
    this.show = true;
  }

  public getLevel(slushMachine: SlushMachine, offset: number = 0): string {
    // gradient starts at 70%
    if (slushMachine.level != undefined) {
      const level = ((slushMachine.level / 100) * 70) + offset;
      return level.toString();
    }
    return "0";
  }

}
