import { Guid } from 'guid-typescript';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BaseAPIServiceService } from './../BaseAPIService/base-apiservice.service';
import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService extends BaseAPIServiceService {

  constructor(http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') baseUrl: string,
    @Inject('BASE_URL') api: string) {
    super(http, baseUrl, "Messages");
  }
  temp = this.router.url.includes('purchaseOrder');
  override get(id): Observable<any> {
    console.log(this.temp);
    if (this.temp) {
      var url = this.baseUrl + "api/" + this.APIURl + "/" + id;
      var object = {};
      return null;
    }
    else {
      var url = this.baseUrl + "api/" + this.APIURl + "/" + id;
      return this.http.get<any>(url);
    }
  }

  override put(ID, item): Observable<any> {
    if (this.temp) {
      var url = this.baseUrl + "api/" + this.APIURl;
      item.messageId=Guid.create().toString();
      return this.http.post<any>(url, item);
    } else {
      var url = this.baseUrl + "api/" + this.APIURl + "/" + ID;
      console.log(item);
      return this.http.put<any>(url, item);
    }
  }
}

