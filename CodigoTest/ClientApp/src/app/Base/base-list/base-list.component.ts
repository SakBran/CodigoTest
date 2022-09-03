import { BaseAPIServiceService } from './../../Services/BaseAPIService/base-apiservice.service';
import { MatTableDataSource } from '@angular/material/table';
import { FormGroup } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild, Inject } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { ApiResult } from 'src/app/base.service';
import { CommonService } from 'src/app/Services/Common/common.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-base-list',
  templateUrl: './base-list.component.html',
  styleUrls: ['./base-list.component.css']
})
export class BaseListComponent implements OnInit {

  @Output() newItemEvent = new EventEmitter<Object>();
  @Input() searchBox: boolean;
  @Input() BaseForm: FormGroup;
  @Input() SortColumn: string;
  @Input() Service: BaseAPIServiceService;
  @Input() newURL: string;
  @Input() IDcolumn: string;
  @Input() title: string;
  @Input() EntityCode: string;
  @Input() EntityCodePrefix: string;

  private destroySubject: Subject<boolean> = new Subject<boolean>();

  public displayedColumns: string[] = [];
  public datas: MatTableDataSource<Object>;
  defaultPageIndex: number = 0;
  defaultPageSize: number = 10;
  public defaultSortColumn: string = "";
  public defaultSortOrder: string = "asc";
  defaultFilterColumn: string = "";
  filterQuery: string = null;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  filterTextChanged: Subject<string> = new Subject<string>();
  createdDate = "createdDate";
  Subscription:Subscription;
  baseUrl = "";
  constructor(private commonService: CommonService,
     private datepipe: DatePipe,
    @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl;
     }

  ngOnInit(): void {
    let form: FormGroup = this.BaseForm;
    Object.keys(form.controls).forEach((key: string) => {
      this.displayedColumns.push(key);
    });
    this.defaultSortColumn = this.SortColumn;
    this.defaultFilterColumn = this.SortColumn;
    this.loadData(null);
  }

  onFilterTextChanged(filterText: string) {
    if (filterText === "") {
      var pageEvent = new PageEvent();
      pageEvent.pageIndex = this.defaultPageIndex;
      pageEvent.pageSize = this.defaultPageSize;
      this.getAllData(pageEvent);
    } else {
      if (this.filterTextChanged.observers.length === 0) {
        this.filterTextChanged
          .pipe(debounceTime(500), distinctUntilChanged())
          .subscribe(query => {
            this.loadData(query);
          });
      }
      this.filterTextChanged.next(filterText);
    }
  }

  loadData(query: string = null) {
    var pageEvent = new PageEvent();
    pageEvent.pageIndex = this.defaultPageIndex;
    pageEvent.pageSize = this.defaultPageSize;
    if (query) {
      this.filterQuery = query;
    }
    this.getData(pageEvent);
  }

  getData(event: PageEvent) {
    var sortColumn = (this.sort)
      ? this.sort.active
      : this.defaultSortColumn;

    var sortOrder = (this.sort)
      ? this.sort.direction
      : this.defaultSortOrder;

    var filterColumn = (this.filterQuery)
      ? this.defaultFilterColumn
      : null;

    var filterQuery = (this.filterQuery)
      ? this.filterQuery
      : null;

    let a;
    this.Subscription=this.Service.getData<ApiResult<Object>>(
      event.pageIndex,
      event.pageSize,
      sortColumn,
      sortOrder,
      filterColumn,
      filterQuery)
      .subscribe(result => {
        this.paginator.length = result.totalCount;
        this.paginator.pageIndex = result.pageIndex;
        this.paginator.pageSize = result.pageSize;
        let datalist = Object.assign(result.data);
        datalist.forEach(data => {
          data[this.EntityCode] = this.commonService.
            productCodeGenerator(this.EntityCodePrefix, data[this.EntityCode]);
          data[this.createdDate] = this.datepipe.transform(data[this.createdDate], 'dd/MM/yyyy');
          data['date'] = this.datepipe.transform(data['date'], 'dd/MM/yyyy');
        });
        this.datas = new MatTableDataSource<Object>(datalist);
      }, error => {
        if(error.status === 403){
          //this.commonService.sweetAlert("warning","You don't have permission.");
        }
      }, () => console.log(a));
  }

  getAllData(event: PageEvent) {
    var sortColumn = (this.sort)
      ? this.sort.active
      : this.defaultSortColumn;

    var sortOrder = (this.sort)
      ? this.sort.direction
      : this.defaultSortOrder;

    var filterColumn = (this.filterQuery)
      ? this.defaultFilterColumn
      : null;



    let a;
    this.Subscription=this.Service.getData<ApiResult<Object>>(
      event.pageIndex,
      event.pageSize,
      sortColumn,
      sortOrder,
      filterColumn,
      null)
      .subscribe(result => {
        this.paginator.length = result.totalCount;
        this.paginator.pageIndex = result.pageIndex;
        this.paginator.pageSize = result.pageSize;
        let datalist = Object.assign(result.data);
        datalist.forEach(data => {
          data[this.EntityCode] = this.commonService.
            productCodeGenerator(this.EntityCodePrefix, data[this.EntityCode]);
          data[this.createdDate] = this.datepipe.transform(data[this.createdDate], 'dd/MM/yyyy');
          data['date'] = this.datepipe.transform(data['date'], 'dd/MM/yyyy');
        });
        this.datas = new MatTableDataSource<Object>(datalist);
      }, error => console.error(error), () => console.log(a));
  }

  ngOnDestroy() {
    // emit a value with the takeUntil notifier
    this.destroySubject.next(true);
    // unsubscribe from the notifier itself
    this.destroySubject.unsubscribe();
    if(this.Subscription){
      this.Subscription.unsubscribe();
    }

  }

  setData(value: Object) {
    this.newItemEvent.emit(value);
  }

  formName(strings: string): string {
    return this.commonService.formName(strings);
  }

  filterQryChange(x) {
    this.defaultFilterColumn = x;
  }

  dateCheck(theString): boolean {
    if (theString.includes("Date") || theString.includes("date")) {
      return false;
    }
    return true;
  }

  imageCheck(theString): boolean {
    if (theString.includes("Image") || theString.includes("image")) {
      return false;
    }
    return true;
  }
}
