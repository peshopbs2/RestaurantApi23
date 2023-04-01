import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Restaurant } from 'src/app/model/restaurant.model';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit  {
  formRestaurant!: FormGroup;
  restaurantId! : Number;

  constructor(private formBuilder: FormBuilder, private restaurantService : RestaurantService, private router: Router, private activatedRoute : ActivatedRoute)
  {
    
  }
  ngOnInit(): void {
    this.formRestaurant = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      address: ['', Validators.required]
    });
    this.activatedRoute.params
    .subscribe(params => {
      this.restaurantId = params['id'];
      this.restaurantService.get(this.restaurantId)
      .subscribe({
        next: (data) => {
          let restaurant : Restaurant = data;
          console.log(restaurant);
          this.formRestaurant = this.formBuilder.group({
            name: [restaurant.name, Validators.required],
            description: [restaurant.description, Validators.required],
            address: [restaurant.address, Validators.required]
          });
        }
      });
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

    this.restaurantService.update(this.restaurantId, restaurant)
      .subscribe({
        next: (res) => {
          this.router.navigate(['/restaurants'])
        },
        error: (e) => console.error(e)
      });
  }
}
