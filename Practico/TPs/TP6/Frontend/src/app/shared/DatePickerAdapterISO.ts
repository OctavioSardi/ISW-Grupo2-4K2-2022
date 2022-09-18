import { Injectable } from '@angular/core';
import { NgbDateAdapter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';


@Injectable()
export class DatePickerAdapterISO extends NgbDateAdapter<string> {

  // string = ISO8061
  fromModel(value: string ): NgbDateStruct  {
    if (!value) return null;

    if (value.includes('T'))
      value = value.substr(0, value.indexOf("T"));  // sacar hora

    let parts=value.split('-');
    let res = {year:+parts[0],month:+parts[1],day:+parts[2]};
    return res;
  }

  toModel(date: NgbDateStruct): string {
    //return  date ? date.day + this.DELIMITER + date.month + this.DELIMITER + date.year : null;
    if (date == null) return null;
    let res = (new Date(date.year, date.month - 1, date.day)).toISOString();
    return res;
  }
}