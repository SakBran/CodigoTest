import { CommonService } from './../../../Services/Common/common.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/Services/User/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  apiurl: string;
  returnURL: string;
  form: FormGroup;
  Key: string = "id";
  customerType='role';
  Hidden=[this.customerType];

  constructor(public service: UserService,private commonService:CommonService) {

    this.apiurl = "Seed";
    this.returnURL = "users";
    this.form = new FormGroup({
      id: new FormControl(),
      email: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required),
      role: new FormControl("", Validators.required)
    });

  }

  ngOnInit(): void {
    
  }

  async requiredCheck(data, BaseForm: FormGroup) {
    return this.commonService.requiredCheck(data,BaseForm);
  }
}
