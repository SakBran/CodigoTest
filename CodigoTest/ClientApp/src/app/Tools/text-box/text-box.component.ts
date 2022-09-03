import { ControlValueAccessor, FormGroup } from '@angular/forms';
import { BaseFormComponent } from 'src/app/base.form.component';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-text-box',
  templateUrl: './text-box.component.html',
  styleUrls: ['./text-box.component.css']
})
export class TextBoxComponent extends BaseFormComponent implements ControlValueAccessor {
  value: string;

  constructor() {
    super();
  }

  writeValue(value: any) {
    this.value = value;
  }

  registerOnChange(onChange: any) {
  }

  registerOnTouched(onTouched: any) {
  }

  markAsTouched() {
  }

  setDisabledState(disabled: boolean) {
  }

}
