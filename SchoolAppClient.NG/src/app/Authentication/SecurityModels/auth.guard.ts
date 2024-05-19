import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { AuthService } from "./auth.service";

export const AuthGuard: CanActivateFn = (route, state) => {
  let authService = inject(AuthService);
  let routerService = inject(Router);
  if (!authService.isLoggedIn()) {
    localStorage.setItem("redirectTo", route.url[0].path);
    routerService.navigate(['/login']);
    return false;
  }
  return true;
};
