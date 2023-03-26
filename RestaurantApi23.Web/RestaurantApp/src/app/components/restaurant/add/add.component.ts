import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Restaurant } from 'src/app/model/restaurant.model';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  formRestaurant!: FormGroup;
   
  constructor(private formBuilder: FormBuilder, private restaurantService : RestaurantService, private router: Router)
  {
    
  }
  ngOnInit(): void {
    this.formRestaurant = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      address: ['', Validators.required]
    });

  }

  get formData() {
    return this.formRestaurant.controls;
  }

  save() {
    if(this.formRestaurant.invalid) {
      return ;
    }  

    const restaurant = {
      name: this.formData['name'].value,
      description: this.formData['description'].value,
      address: this.formData['address'].value,
    }

    this.restaurantService.create(restaurant)
      .subscribe({
        next: (res) => {
          this.router.navigate(['/restaurants'])
        },
        error: (e) => console.error(e)
      });
  }
}
