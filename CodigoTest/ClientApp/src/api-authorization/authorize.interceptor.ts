import { Router } from '@angular/router';
import { CommonService } from "src/app/Services/Common/common.service";
import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { AuthorizeService } from "./authorize.service";
import { mergeMap, finalize, retryWhen, tap, catchError } from "rxjs/operators";
import { error } from "@angular/compiler/src/util";

@Injectable({
  providedIn: "root",
})
export class AuthorizeInterceptor implements HttpInterceptor {
  constructor(
    private authorize: AuthorizeService,
    private loadingScreenService: CommonService,
    private router: Router,
  ) {}
  activeRequests: number = 0;

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (this.activeRequests === 0) {
      this.loadingScreenService.loading();
    }
    this.activeRequests++;
    return this.authorize
      .getAccessToken()
      .pipe(
        mergeMap((token) => this.processRequestWithToken(token, req, next))
      );
  }

  // Checks if there is an access_token available in the authorize service
  // and adds it to the request in case it's targeted at the same origin as the
  // single page application.
  private processRequestWithToken(
    token: string,
    req: HttpRequest<any>,
    next: HttpHandler
  ) {
    if (!!token && this.isSameOriginUrl(req)) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }

    return next.handle(req).pipe(
      tap((evt) => {}),
      catchError((error) => {
        this.handleError(error);
        return throwError(error); // add this line
      }),

      finalize(() => {
        this.activeRequests--;
        if (this.activeRequests === 0) {
          this.loadingScreenService.done();
        }
      })
    );
  }

  private isSameOriginUrl(req: any) {
    // It's an absolute url with the same origin.
    if (req.url.startsWith(`${window.location.origin}/`)) {
      return true;
    }

    // It's a protocol relative url with the same origin.
    // For example: //www.example.com/api/Products
    if (req.url.startsWith(`//${window.location.host}/`)) {
      return true;
    }

    // It's a relative url like /api/Products
    if (/^\/[^\/].*/.test(req.url)) {
      return true;
    }

    // It's an absolute or protocol relative url that
    // doesn't have the same origin.
    return false;
  }

  public handleError(err: HttpErrorResponse) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
      this.loadingScreenService.sweetAlert("error", errorMessage);
    } else {
      switch (err.status) {
        case 400:
          errorMessage = "Bad Request.";
          break;
        case 401:
          errorMessage = "You need to log in to do this action.";
          break;
        case 403:
          errorMessage =
            "You don't have permission to access the requested resource.";
          break;
        case 404:
          errorMessage = "The requested resource does not exist.";
          break;
        case 412:
          errorMessage = "Precondition Failed.";
          break;
        case 500:
          errorMessage = "Internal Server Error.";
          break;
        case 503:
          errorMessage = "The requested service is not available.";
          break;
        case 422:
          errorMessage = "Validation Error!";
          break;
        default:
          errorMessage = "Something went wrong";
      }
      this.loadingScreenService.sweetAlert("error", errorMessage);
      if(err.status===403){
        this.router.navigateByUrl("forbidden");
      }
      
      
    }
  }
}
