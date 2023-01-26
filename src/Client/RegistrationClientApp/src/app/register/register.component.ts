import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';

import { NzFormTooltipIcon } from 'ng-zorro-antd/form';
import { Country, Province, UserProvince } from '../models/country.province.model';
import { Email, Password, User } from '../models/user.request';
import { RequestService } from '../services/request.service';

@Component({
  selector: 'register-component',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [RequestService],
  animations: [
    trigger(
      'inOutAnimation', 
      [
        transition(
          ':enter', 
          [
            style({ height: 0, opacity: 0 }),
            animate('1s ease-out', 
                    style({ height: 300, opacity: 1 }))
          ]
        ),
        transition(
          ':leave', 
          [
            style({ height: 300, opacity: 1 }),
            animate('1s ease-in', 
                    style({ height: 0, opacity: 0 }))
          ]
        )
      ]
    )
  ]
})
export class RegisterComponent implements OnInit {
  validateForm!: UntypedFormGroup;
  validateFormRegister!: UntypedFormGroup;
  captchaTooltipIcon: NzFormTooltipIcon = {
    type: 'info-circle',
    theme: 'twotone'
  };

  doneStepOne: boolean = false;
  doneStepTwo: boolean = false;
  doneLastStep: boolean = false;

  userId: string = '';

  countries:Array<Country> = [];
  provinces:Array<Province> = [];

  selectedCountry!: Country;
  selectedProvince: Province | null = null;

  constructor(private httpService: RequestService, private fb: UntypedFormBuilder){}

  submitForm(): void {
    if (this.validateForm.valid) {
      console.log('submit', this.validateForm.value);
      let formValue = (this.validateForm.value as any);
      let user = new User(
        new Email(formValue.email),
        new Password(formValue.password),
        new Password(formValue.checkPassword),
        formValue.agree
      )

      this.httpService.createUser(user)
          .subscribe({
            next:(data: any) => { 
              this.userId = data.userId; 
              this.doneStepOne=true; 
            },
            error: error => console.log(error)
        })

    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  
  submitRegisterForm(): void {
    if (this.validateFormRegister.valid) {
      let user = new UserProvince(
        this.userId,
        (this.selectedProvince?.id as string)
      )
      this.httpService.setUserProvince(user)
          .subscribe({
            next:(data: any) => { 
              this.doneLastStep = true; 
            },
            error: error => console.log(error)
        })

    } else {
      Object.values(this.validateFormRegister.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  updateConfirmValidator(): void {
    /** wait for refresh value */
    Promise.resolve().then(() => (this.validateForm.controls as any).checkPassword.updateValueAndValidity());
  }

  confirmationValidator = (control: UntypedFormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== (this.validateForm.controls as any).password.value) {
      return { confirm: true, error: true };
    }
    return {};
  };

  containDigitAndLetter = (control: UntypedFormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (/\d/.test(control.value) !== true || /[a-zA-Z]/g.test(control.value) !== true) {
      return { confirm: true, error: true };
    }
    return {};
  };

  countryChange(){
    if(!this.selectedCountry)
      return;
    this.provinces = [];
    this.selectedProvince = null;
    this.httpService.getProvincesByCountry(this.selectedCountry.id).subscribe({
      next:(data: any) => { 
        this.provinces = data; 
      },
      error: error => console.log(error)
    });
  }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required, this.containDigitAndLetter]],
      checkPassword: [null, [Validators.required, this.confirmationValidator]],
      agree: [false, [Validators.requiredTrue]]
    });
    this.validateFormRegister = this.fb.group({
      country: [null, [Validators.required]],
      province: [null, [Validators.required]]
    });

    this.httpService.getAllCountries().subscribe({
      next:(data: any) => { 
        this.countries = data; 
      },
      error: error => console.log(error)
    });
  }
}
