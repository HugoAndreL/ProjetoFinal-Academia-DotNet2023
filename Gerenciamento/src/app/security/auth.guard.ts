import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

import { LoginService } from '../services/login.service';
import {  jwtDecode } from 'jwt-decode';

export const AuthGuard: CanActivateFn = (route, state) => {
  const service = inject(LoginService);
  const router = inject(Router);
  const tokenBoleano = !!localStorage.getItem("token");
  if (tokenBoleano) {
    const token = localStorage.getItem("token");
    if (service.ehExpiradoToken(token)) {
      localStorage.removeItem("token");
      service.pacthLogin()
      router.navigate(['Login']);
      return false;
    } else {
      return true;
    }
  }
  service.pacthLogin();
  router.navigate(['Login'])
  return false;
};