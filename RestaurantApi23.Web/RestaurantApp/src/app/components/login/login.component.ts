import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize, first } from 'rxjs/operators';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  submitted = false;
  submitClick = false;
  error = '';
  returnUrl = '';
  constructor(private formBuilder: FormBuilder,
  private route: ActivatedRoute,
  private router : Router,
  private authService : AuthService)
  {
    
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.authService.logout();
    
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get formData() { return this.loginForm.controls; }
  onLogin() {
    this.submitted = true;

    if(this.loginForm.invalid)
    {
      //stop submitting
      return; 
    }

    this.submitClick = true;
    try
    {
      const data = this.authService.login(this.formData['username'].value,
      this.formData['password'].value)
        .pipe(
          first(),
          finalize( () => {
            this.submitClick = false;
          })
        )
        .subscribe(() => {
          this.router.navigate([this.returnUrl]);
        })
      console.log(this.loginForm.controls);
    } catch(error : any) {
      console.log(error);
      this.error = error;
      this.submitClick = false;
    }
  }
}
