import { AsyncValidatorFn, AbstractControl, ValidationErrors } from "@angular/forms";
import { Observable, map } from "rxjs";
import { AuthService } from "src/app/services/auth.service";

export class UsernameValidators {
    static shouldBeUnique(authService: AuthService) : AsyncValidatorFn {
        return (control: AbstractControl): Observable<ValidationErrors | null> => 
        {
            return authService.isUserExistByEmailOrUsername(control.value).pipe(map(result => result.isExist ? { shouldBeUnique: true } : null));
        }
    }

    static cannotContainSpace(control: AbstractControl) : ValidationErrors | null {
        if ((control.value as string).indexOf(' ') >= 0) {
            return { cannotContainSpace: true};
        }

        return null;
    }
}