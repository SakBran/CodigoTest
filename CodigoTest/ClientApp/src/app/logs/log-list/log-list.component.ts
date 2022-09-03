import { LogsService } from './../../Services/Logs/logs.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-log-list',
  templateUrl: './log-list.component.html',
  styleUrls: ['./log-list.component.css']
})
export class LogListComponent implements OnInit {@Input() searchBox: boolean;
  //@Output() newItemEvent = new EventEmitter<Customer>();
  form: FormGroup;
  sortColumn: string = "logTable";
  newURL: string = "log";
  IDColumn: string = "logId";
  title: string = "Logs";
  //EntityCodePrefix="C";
  //EntityCode="customerCode";


  constructor(public LogService: LogsService) {
    this.form = new FormGroup({
      //logId: new FormControl("", Validators.required),
      logTable: new FormControl(""),
      // logOldData: new FormControl(""),
      // logNewData: new FormControl(""),
      user: new FormControl(""),
      createdDate: new FormControl(""),

    });
  }

  ngOnInit(): void {
  }


}
