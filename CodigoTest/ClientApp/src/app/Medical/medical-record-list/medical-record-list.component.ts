import { MedicalService } from './../../Services/Medical/medical.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Customer } from 'src/app/Model/Customer';

@Component({
  selector: 'app-medical-record-list',
  templateUrl: './medical-record-list.component.html',
  styleUrls: ['./medical-record-list.component.css']
})
export class MedicalRecordListComponent implements OnInit {
  @Input() searchBox: boolean;
  @Output() newItemEvent = new EventEmitter<Customer>();
  form: FormGroup;
  sortColumn: string = "name";
  newURL: string = "medicalRecord";
  IDColumn: string = "id";
  title: string = "Medical Records";


  constructor(public CustomerService: MedicalService) {
    this.form = new FormGroup({
        name : new FormControl("", Validators.required),
        age : new FormControl("", Validators.required),
        sex : new FormControl("", Validators.required),
        phone : new FormControl("", Validators.required),
        bloodPressure : new FormControl("", Validators.required),
        pulseRate : new FormControl("", Validators.required),
        temperature : new FormControl("", Validators.required),
        spO2 : new FormControl("", Validators.required),
        historyOfPresentIllness : new FormControl("", Validators.required),
        drugHistory : new FormControl("", Validators.required),
        examination : new FormControl("", Validators.required),
        investigations : new FormControl("", Validators.required),
        treatment : new FormControl("", Validators.required),
        pastMedicalHistory : new FormControl("", Validators.required),
        currentDrugs : new FormControl("", Validators.required),
        fees : new FormControl("", Validators.required),
        date : new FormControl("", Validators.required),
        createdDate : new FormControl("", Validators.required),

    });
  }

  ngOnInit(): void {
  }
  emit(value) {
    if (value) {
      this.newItemEvent.emit(value);
    } else {
      console.log("No Data");
    }
  }

}
