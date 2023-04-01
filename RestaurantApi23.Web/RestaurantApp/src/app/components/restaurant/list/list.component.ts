import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/model/restaurant.model';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  restaurants?: Restaurant[];
  currentRestaurant = {};
  currentIndex = -1;

  constructor(private resturantService: RestaurantService) {

  }
  ngOnInit(): void {
    this.loadRestaurants();
  }
  loadRestaurants() {
    this.resturantService.getAll()
      .subscribe({
        next: (data) => {
          this.restaurants = data;
        }
      })
  }
  refreshList() : void {
    this.loadRestaurants();
    this.currentRestaurant = {};
    this.currentIndex = -1;
  }
  editRestaurant(id : Number) {
    
  }
}
