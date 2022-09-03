import { UploadServiceService } from './../../Services/UploadService/upload-service.service';
import { DatePipe } from '@angular/common';
import { BaseAPIServiceService } from './../../Services/BaseAPIService/base-apiservice.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnDestroy, OnInit, Inject, Input, Type } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Subject, Subscription } from 'rxjs';
import { BaseFormComponent } from 'src/app/base.form.component';
import { Guid } from 'guid-typescript';
import { CommonService } from 'src/app/Services/Common/common.service';

@Component({
  selector: 'app-base-edit',
  templateUrl: './base-edit.component.html',
  styleUrls: ['./base-edit.component.css']
})
export
  class BaseEditComponent
  extends BaseFormComponent
  implements OnInit, OnDestroy {
  @Input() apiurl: string;
  @Input() BaseForm: FormGroup;
  @Input() ID: string;
  @Input() returnURL: string;
  @Input() Service: BaseAPIServiceService;
  @Input() Key: string;
  @Input() Hidden: string[];
  @Input() EntityCode: string;
  @Input() EntityCodePrefix: string;
  @Input() ReadOnly: string[];

  // the view title
  title: string;

  // the form model
  form: FormGroup;

  // the city object to edit or create
  data: any;

  // the city object id, as fetched from the active route:
  // It"s NULL when we"re adding a new city,
  // and not NULL when we"re editing an existing one.
  id?: string;

  // Activity Log (for debugging purposes)
  activityLog: string = "";
  formGroup: string[] = [];
  tempCode: number = 0;

  // Notifier subject (to avoid memory leaks)
  private destroySubject: Subject<boolean> = new Subject<boolean>();

  back: string;
  GUID: string;
  baseUrl: string;

  CreatedDate: string;
  Subscription: Subscription;
  constructor(
    private activatedRoute: ActivatedRoute,
    private commonService: CommonService,
    private uploadService: UploadServiceService,
    private router: Router,
    @Inject('BASE_URL') baseUrl: string,
    public datepipe: DatePipe,) {
    super();
    this.GUID = Guid.create().toString();
    this.baseUrl = baseUrl;
  }

  ngOnInit() {

    this.form = this.BaseForm;
    this.back = "/" + this.returnURL;
    Object.keys(this.form.controls).forEach((key: string) => {
      this.formGroup.push(key);
    });
    this.loadData();
    this.GetGUID();
    //console.log(this.form.get(this.Key).value)
  }

  hiddenFilter(x): boolean {
    if (this.Hidden) {
      return this.Hidden.filter(h => h === x).length === 0;
    }
    else {
      return true;
    }
  }

  readonlyFilter(data): boolean {
    if (this.ReadOnly) {
      return this.ReadOnly.filter(h => h === data).length === 0;
    }
    else {
      return true;
    }
  }

  ngOnDestroy() {
    // emit a value with the takeUntil notifier
    this.destroySubject.next(true);
    // unsubscribe from the notifier itself
    this.destroySubject.unsubscribe();
    if (this.Subscription) {
      this.Subscription.unsubscribe();
    }

  }

  formName(strings: string): string {
    var i = 0;
    var character;
    var data = "";
    while (i <= strings.length) {
      character = strings.charAt(i);
      if (!isNaN(character * 1)) {

      }
      else {
        if (i == 0) {
          data = data + character.toUpperCase();
        } else {
          if (character == character.toUpperCase()) {

            data = data + " " + character;
          }
          else {
            data = data + character;
          }
        }
      }
      i++;
    }
    return data;
  }
  //Lazy Code
  CustomStatusList = ["preparingFile", "priceRecommendation", "billOfLading"];
  textAreaList = ["historyOfPresentIllness", "examination", "drugHistory", "pastMedicalHistory", "investigations", "treatment"];
  CustomYesNoList = ["submittingContainerZipFileForest"];
  //Lazy Code
  formType(strings: string): string {
    if (strings.search("Date") != -1 || strings.search("date") != -1) {
      return "date"
    }
    if (strings.search("Attachment") != -1 || strings.search("attachment") != -1) {
      return "link"
    }
    if (this.CustomStatusList.find(x => x == strings) || strings.search("status") != -1 || strings.search("Status") != -1) {
      return "status"
    }
    if (this.textAreaList.find(x => x == strings)) {
      return "textArea"
    }
    if (this.CustomYesNoList.find(x => x == strings)) {
      return "YesNo"
    }
    else {
      return "text"
    }
  }

  loadData() {
    // retrieve the ID from the "id"
    this.id = this.ID;

    this.id = this.activatedRoute.snapshot.paramMap.get("id");
    if (this.id) {
      // EDIT MODE
      // fetch the city from the server
      try {
        this.Subscription = this.Service.get(this.id).subscribe(result => {
          this.data = Object.assign(result);
          this.title = "Edit";
          //console.log(this.data);
          if (this.EntityCode) {
            this.tempCode = this.data[this.EntityCode];
            this.data[this.EntityCode] = this.commonService.productCodeGenerator(this.EntityCodePrefix, this.data[this.EntityCode]);
          }
          if (this.ID) {
            this.tempCode = this.data[this.ID];
            this.data[this.ID] = this.id;
          }

          this.form.patchValue(this.data);

          Object.keys(this.form.controls).forEach((controlName) => {
            if (this.formType(controlName) == 'date') {

              this.datepipe.transform(this.data[controlName], 'dd/MM/yyyy');
              this.commonService.parseDate(this.data[controlName]);
              this.form.controls[controlName].setValue(this.commonService.parseDate(this.data[controlName]));
            }
          });

          if (this.data.createdDate) {
            this.CreatedDate = this.datepipe.transform(this.data.createdDate, 'dd/MM/yyyy');
          }
        });
      } catch (err) {
        console.log("ID is undefined.Error message:" + err);
      }

    }
    else {
      this.title = "New";
      if (this.EntityCode) {
        this.form.get(this.EntityCode).setValue("0");
      }
      this.CreatedDate = this.datepipe.transform(new Date(), 'dd/MM/yyyy');
    }
  }

  temp = this.router.url.includes('purchaseOrder');
  commercialInvoice = this.router.url.includes('commercialInvoice');
  officeAttachment = this.router.url.includes('AttachmentModel');

  getValue(x): string {
    return this.form.controls[x].value;
  }
  async onSubmit() {
    var data = (this.id) ? this.data : <object>{};
    data = Object.assign(this.form.getRawValue());

    if (this.id) {
      // EDIT mode
      data[this.EntityCode] = this.tempCode;
      this.Subscription = this.Service
        .put(this.id, data)
        .subscribe(result => {

        }, error => console.error(error), async () => {
          if (this.officeAttachment) {
            await this.UploadOfficeFile(this.id);
            this.router.navigate([this.back]);
          }


          if (!this.temp) {
            this.router.navigate([this.back]);
          }
          if (this.commercialInvoice) {
            let temp = JSON.parse(localStorage.getItem("commercialInvoiceDetail"));
            temp.forEach(x => {
              x.commercialInvoiceId = data.commercialInvoiceId;
            });

          }




        });
      //this.router.navigate([this.back]);
    }
    else {
      // ADD NEW mode

      this.Subscription = this.Service
        .post(data)
        ?.subscribe(result => {
        }, error => console.error(error), async () => {
          if (this.officeAttachment) {
            await this.UploadOfficeFile(this.id);
            this.router.navigate([this.back]);
          }
          if (!this.commercialInvoice) {
            this.router.navigate([this.back]);
          } else {
            let temp = JSON.parse(localStorage.getItem("commercialInvoiceDetail"));
            temp.forEach(x => {
              x.commercialInvoiceId = data.commercialInvoiceId;
            });



          }

        });
      //this.router.navigate([this.back]);
    }
  }
  async UploadOfficeFile(id) {
    let EDAttachment = localStorage.getItem("EDAttachment");
    let GeneralAttachment = localStorage.getItem("GeneralAttachment");
    if (EDAttachment) {
      const result = await this.uploadService.postPDF(EDAttachment, "EDAttachment" + id + ".pdf").toPromise();;
    }
    if (GeneralAttachment) {
      const result = await this.uploadService.postPDF(GeneralAttachment, "GeneralAttachment" + id + ".pdf").toPromise();;
    }

  }
  onDelete() {
    var result = confirm("Want to delete?");
    if (result) {
      this.Subscription = this.Service
        .delete(this.id)
        .subscribe(result => {
        }, error => this.commonService.sweetAlert("error", "You can't delete this item. Many data are based on this item"), () => {
          this.router.navigate([this.back]);
        });
    }

    //this.router.navigate([this.back]);
  }
  GetGUID() {
    if (this.ID) {
      this.form.get(this.Key).setValue(this.ID);

    } else {
      //console.log(result.toString());
      this.form.get(this.Key).setValue(this.GUID);
    }

  }

  requiredCheck(data, BaseForm: FormGroup) {
    return this.commonService.requiredCheck(data, BaseForm);
  }
}
