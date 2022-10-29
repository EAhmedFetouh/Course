import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {   Observable, throwError } from "rxjs";
import {  catchError, retry } from "rxjs/operators";

@Injectable()

export class ErrorInterceptor implements HttpInterceptor
{
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            retry(1),
            catchError((error: HttpErrorResponse)=> {
                let errorMessage = '';
                        if (error.error instanceof ErrorEvent) {
                            errorMessage=`Error: ${error.error.message}`;
                        }else{
                            errorMessage = `Error Status: ${error.status}\nMessage: ${error.message}`;
                        }
                        console.error(errorMessage);
                        return throwError(errorMessage);
                    }
                
            )
        )
      }
    }

    export const ErrorInterceptorProvider={
        provide:HTTP_INTERCEPTORS,
        useClass:ErrorInterceptor,
        multi:true
    }


   