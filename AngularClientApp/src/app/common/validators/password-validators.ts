import { AbstractControl, ValidationErrors } from "@angular/forms";

export class PasswordValidators {
    static cannotContainSpace(control: AbstractControl) : ValidationErrors | null {
        if ((control.value as string).indexOf(' ') >= 0) {
            return { cannotContainSpace: true };
        }

        return null;
    }

    static passwordShouldHaveNumbers(control: AbstractControl) : ValidationErrors | null {
        if((control.value as string).match(/\d+/g) == null) {
            return {passwordShouldHaveNumbers: true};
        }

        return null;
    }

    static passwordShouldHaveCapitalCase(control: AbstractControl) : ValidationErrors | null {
        if((control.value as string).match(/\w\S*/g) == null) {
            return {passwordShouldHaveCapitalCase: true};
        }

        return null;
    }

    static passwordShouldHaveSpecialCharacter(control: AbstractControl) : ValidationErrors | null {
        if((control.value as string).match(/[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/) == null) {
            return {passwordShouldHaveSpecialCharacter: true};
        }

        return null;
    }
}