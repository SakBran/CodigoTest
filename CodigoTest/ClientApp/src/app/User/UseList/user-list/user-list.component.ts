import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/Services/User/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  form: FormGroup;
  sortColumn:string="email";
  newURL:string="user";
  IDColumn: string = "id";
  title:string="Users";
  constructor(public service:UserService) {
    this.form = new FormGroup({
      //Id: new FormControl("", Validators.required),
      email: new FormControl("", Validators.required),
      //password: new FormControl("", Validators.required),
      role: new FormControl("", Validators.required)
    });
   }

  ngOnInit(): void {
  }

}
