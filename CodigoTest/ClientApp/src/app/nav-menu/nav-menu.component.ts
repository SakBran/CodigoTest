import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  baseUrl="";
  /**
   *
   */
  constructor(
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl=baseUrl;

  }
  collapse() {
    this.isExpanded = false;
  }
  username() {
    if (document.getElementById("username")) {
      return document.getElementById("username").innerHTML.toString();
    } else {
      return "Hello";
    }
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
