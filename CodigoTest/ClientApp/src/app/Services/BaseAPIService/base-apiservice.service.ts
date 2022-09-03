
import { HttpClient, HttpParams } from '@angular/common/http';
import {  Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseAPIServiceService {
  constructor(
    public http: HttpClient,
    public baseUrl: string,
    public APIURl: string
  ) {
  }

  getData<ApiResult>(
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string,
    filterQuery: string
  ): Observable<ApiResult> {
    var url = this.baseUrl + 'api/' + this.APIURl;
    var params = new HttpParams()
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder);

    if (filterQuery) {
      params = params
        .set("filterColumn", filterColumn)
        .set("filterQuery", filterQuery);
    }

    return this.http.get<ApiResult>(url, { params });
  }

  get(id): Observable<any> {
    var url = this.baseUrl + "api/" + this.APIURl + "/" + id;
    return this.http.get<any>(url);
  }

  put(ID, item): Observable<any> {
    var url = this.baseUrl + "api/" + this.APIURl + "/" + ID;
    console.log(item);
    return this.http.put<any>(url, item);
  }

  post(item): Observable<any> {
    var url = this.baseUrl + "api/" + this.APIURl;
    return this.http.post<any>(url, item);
  }
  postDataList(item): Observable<any> {
    var url = this.baseUrl + "api/" + this.APIURl+ "/PostDataList";
    return this.http.post<any>(url, item);
  }

  delete(id): Observable<any> {
    var url = this.baseUrl + "api/" + this.APIURl+"/" + id;
    return this.http.delete<any>(url);
  }
}

