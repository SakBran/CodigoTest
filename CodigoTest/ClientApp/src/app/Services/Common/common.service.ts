import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import  Swal  from "node_modules/admin-lte/plugins/sweetalert2/sweetalert2.min.js";
@Injectable({
  providedIn: 'root'
})
export class CommonService {

  constructor() { }

  productCodeGenerator(type, productCode: string): string {
    let result = "";
    if (+productCode < 10) {
      result = `${type}0000${productCode}`;
    }
    else if (+productCode < 100) {
      result = `${type}000${productCode}`;
    }
    else if (+productCode < 1000) {
      result = `${type}00${productCode}`;
    }
    else if (+productCode < 10000) {
      result = `${type}0${productCode}`;
    }
    return result;
  }

  loading() {
    // let btn = document.getElementById('btnOverlay') as HTMLButtonElement;
    // btn.click();
   // document.getElementById("overlay").style.display = "block";
  }

  done() {
    // let btn = document.getElementById('btnOverlay') as HTMLButtonElement;
    // btn.click();
    document.getElementById("overlay").style.display = "none";
  }

  formName(strings: string): string {
    var character;
    var data = "";
    for (var i = 0; i <= strings.length; i++) {
      character = strings.charAt(i);
      if (!isNaN(character * 1)) {
        //console.log('character is numeric');
      }
      else {
        if (i == 0) {
          data = data + character.toUpperCase();
        } else {
          if (character == character.toUpperCase()) {
            // console.log('upper case true');
            data = data + " " + character;
          }
          else {
            data = data + character;
          }
        }
      }
    }
    return data;
  }

  async requiredCheck(data, BaseForm: FormGroup) {
    if (BaseForm) {
      if (BaseForm.controls[data]) {
        let formControl = BaseForm.controls[data];
        if (formControl.validator) {
          if(formControl.validator(data)!=null){
            let dom = Object.assign(formControl.validator(data));
            if (dom) {
              return dom.required;
            }
            else {
              return false;
            }
          }
          else{
            return false;
          }

        }
      }
    } else {
      return false;
    }
  }

  sweetAlert(icon,msg){
    if(icon===""){
      icon="success";
    }
    var Toast =Swal.mixin({
      toast: true,
      position: 'top-end',
      showConfirmButton: false,
      timer: 5000
    });
    Toast.fire({
      icon: icon,
      title: msg
    });
  }

  parseDate(dateString: string): Date {
    if (dateString) {
        return new Date(dateString);
    }
    return null;
  }

}
