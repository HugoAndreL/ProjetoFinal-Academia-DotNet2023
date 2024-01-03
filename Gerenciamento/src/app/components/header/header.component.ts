import { Component } from '@angular/core';

import { faHospital, faRightToBracket } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  title = "Hospital SGS Gerenciamento";

  icLogin = faRightToBracket;
  icHospital = faHospital;
}
