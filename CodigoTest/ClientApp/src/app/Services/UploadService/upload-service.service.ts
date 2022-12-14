import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Inject,Injectable } from '@angular/core';
import { BaseService } from 'src/app/base.service';

@Injectable({
  providedIn: 'root'
})
export class UploadServiceService  extends BaseService{
  private url;
  private httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "multipart/form-data",
    }),
  };
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
    this.url=baseUrl;
}


  post(data, filename): Observable<any> {
    let Uploadurl = this.url + `api/Upload/postUpload?filename=${filename}`;
    const formData: FormData = new FormData();
    const blob = this.dataURItoBlob(data);
    formData.append('file', blob, filename+".jpg");
    if (formData !== null) {
      return this.http.post<any>(Uploadurl, formData);
    }
  }

  postPDF(data, filename): Observable<any> {
    let Uploadurl = this.url + `api/Upload/postUpload?filename=${filename}`;
    const formData: FormData = new FormData();
    const blob = this.dataURItoBlob(data);
    formData.append('file', blob, filename+".pdf");
    if (formData !== null) {
      return this.http.post<any>(Uploadurl, formData);
    }
  }

  dataURItoBlob(dataURI) {
    // convert base64 to raw binary data held in a string
    // doesn't handle URLEncoded DataURIs - see SO answer #6850276 for code that does this
    var byteString = atob(dataURI.split(',')[1]);

    // separate out the mime component
    var mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0]

    // write the bytes of the string to an ArrayBuffer
    var ab = new ArrayBuffer(byteString.length);

    // create a view into the buffer
    var ia = new Uint8Array(ab);

    // set the bytes of the buffer to the correct values
    for (var i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
    }

    // write the ArrayBuffer to a blob, and you're done
    var blob = new Blob([ab], {type: mimeString});
    return blob;

  }

  b64toBlob(dataURI): Blob {
    var byteString = atob(dataURI.split(",")[1]);
    var ab = new ArrayBuffer(byteString.length);
    var ia = new Uint8Array(ab);

    for (var i = 0; i < byteString.length; i++) {
      ia[i] = byteString.charCodeAt(i);
    }

    return new Blob([ab], { type: "image/jpeg" });
  }
}

