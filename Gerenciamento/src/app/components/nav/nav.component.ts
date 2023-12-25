import { Component } from '@angular/core';

import { faBriefcase, faFile, faHospital, faLaptopMedical, faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {
  icUser = faUser;
  icCargo = faBriefcase;
  icTAA = faLaptopMedical;
  icAA = faHospital;
  icRelatorio = faFile;
}
