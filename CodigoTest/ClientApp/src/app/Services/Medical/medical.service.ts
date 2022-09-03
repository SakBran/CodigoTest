import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BaseAPIServiceService } from '../BaseAPIService/base-apiservice.service';

@Injectable({
  providedIn: 'root'
})
export class MedicalService extends BaseAPIServiceService {

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    @Inject('BASE_URL') api: string) {
    super(http, baseUrl, "Medical");
  }
}
