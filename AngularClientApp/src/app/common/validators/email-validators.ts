import { AbstractControl, AsyncValidatorFn, ValidationErrors } from "@angular/forms";
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from "src/app/services/auth.service";

export class EmailValidators {
    static shouldBeUnique(authService: AuthService) : AsyncValidatorFn {
        return (control: AbstractControl): Observable<ValidationErrors | null> => 
        {
            return authService.isUserExistByEmailOrUsername(control.value).pipe(map(result => result.isExist ? { shouldBeUnique: true } : null));
        }
    }
}