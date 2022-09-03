import { Component, Inject, OnInit } from '@angular/core';
import {Chart} from 'chart.js';
@Component({
  selector: 'app-dashboard-list',
  templateUrl: './dashboard-list.component.html',
  styleUrls: ['./dashboard-list.component.css']
})
export class DashboardListComponent implements OnInit {

  baseUrl = "";
  constructor(@Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {

  }


}
