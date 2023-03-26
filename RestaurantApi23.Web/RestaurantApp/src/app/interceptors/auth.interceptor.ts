import { Injectable } from "@angular/core";
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable()
export class AuthHttpInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let tokenInfo = localStorage.getItem('TokenInfo');

        if(tokenInfo)
        {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${tokenInfo}`
                }
            })
        }

        return next.handle(request);
    }
}