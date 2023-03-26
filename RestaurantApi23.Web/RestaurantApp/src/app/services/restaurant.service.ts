import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restaurant } from '../model/restaurant.model';
import { API_BASE_URL } from '../config';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  restaurantUrl = API_BASE_URL + 'Restaurants';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Restaurant[]> {
    return this.http.get<Restaurant[]>(this.restaurantUrl);
  }

  get(id: any) : Observable<Restaurant> {
    return this.http.get<Restaurant>(`${this.restaurantUrl}/${id}`);
  }

  create(data: any) : Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post<Restaurant>(this.restaurantUrl, JSON.stringify(data), {headers: headers});
  }

  update(id: any, data: any) : Observable<any> {
    //TODO: json ^
    return this.http.put(`${this.restaurantUrl}/${id}`, data);
  }

  delete(id: any) : Observable<any> {
    return this.http.delete(`${this.restaurantUrl}/${id}`);
  }
}
