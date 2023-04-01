import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Restaurant } from 'src/app/model/restaurant.model';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {
  restaurantId!: Number;
  restaurant: Restaurant | undefined;
  constructor(private restaurantService: RestaurantService, private router: Router, private activatedRoute: ActivatedRoute) {

  }
  ngOnInit(): void {

    this.activatedRoute.params
      .subscribe(params => {
        this.restaurantId = params['id'];
        this.restaurantService.get(this.restaurantId)
          .subscribe({
            next: (data) => {
              this.restaurant = data;
            }
          });
      });
  }
  cancel() {
    this.router.navigate(['/restaurants']);
  }

  save() {
    this.restaurantService.delete(this.restaurantId)
    .subscribe({
      next: () => {
        this.router.navigate(['/restaurants'])
      }
    });
  }
}
