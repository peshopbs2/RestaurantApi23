import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, take } from 'rxjs/operators';
import { API_BASE_URL } from '../config';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  register() {
    //TODO: add register
  }

  login(email: string, password: string) {
    const loginUrl = API_BASE_URL + 'Auth/Login';
    return this.http.post(loginUrl, { email, password }, { responseType: 'text' })
      .pipe(map(token => {
        if (token) {
          localStorage.setItem('TokenInfo', token);
        }

        return token;
      }),
        take(1)
      );
  }

  logout() {
    localStorage.removeItem('TokenInfo');
  }
}
