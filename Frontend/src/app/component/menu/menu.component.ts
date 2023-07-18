import {Component} from '@angular/core';
import {User} from "../../domain/user";
import {AuthenticationService} from "../../service/authentication.service";

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.scss']
})
export class MenuComponent {

    public user?: User | null;

    constructor(private authenticationService: AuthenticationService) {
        this.authenticationService.user.subscribe((data: any) => this.user = data);
    }

    logout() {
        this.authenticationService.logout();
    }
}
