import { MedicalService } from './../../Services/Medical/medical.service';
import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CommonService } from 'src/app/Services/Common/common.service';

@Component({
  selector: 'app-medical-record-edit',
  templateUrl: './medical-record-edit.component.html',
  styleUrls: ['./medical-record-edit.component.css']
})
export class MedicalRecordEditComponent implements OnInit {

  apiurl:string;
  returnURL:string;
  form: FormGroup;
  Key:string="id";
  today:string;


  constructor(public service:MedicalService,public datepipe: DatePipe,private commonService:CommonService) {

    this.apiurl="Medical";
    this.returnURL="medicalRecords";
    this.form = new FormGroup({
        id : new FormControl("", Validators.required),
        name : new FormControl("", Validators.required),
        age : new FormControl("", Validators.required),
        sex : new FormControl("", Validators.required),
        phone : new FormControl("", Validators.required),
        bloodPressure : new FormControl("", Validators.required),
        pulseRate : new FormControl("", Validators.required),
        temperature : new FormControl("", Validators.required),
        spO2 : new FormControl("", Validators.required),
        historyOfPresentIllness : new FormControl("", Validators.required),
        examination : new FormControl("", Validators.required),
        drugHistory : new FormControl("", Validators.required),
        pastMedicalHistory : new FormControl("", Validators.required),
        investigations : new FormControl("", Validators.required),
        treatment : new FormControl("", Validators.required),
        currentDrugs : new FormControl("", Validators.required),
        fees : new FormControl("", Validators.required),
        date : new FormControl("", Validators.required),
        //CreatedDate : new FormControl("", Validators.required),
    });

// HOPI
// Examination
// Drug History
// Past medical history
// Investigations
// Treatment

   }

  ngOnInit(): void {
    //console.log(this.form);

  }

  async requiredCheck(data, BaseForm: FormGroup) {
    return this.commonService.requiredCheck(data,BaseForm);
  }


  Dispay(text){
    let txt=text;
    let myHTML=txt.replace(/(?:\r\n|\r|\n)/g, '<br>');
    return myHTML
  }

}
