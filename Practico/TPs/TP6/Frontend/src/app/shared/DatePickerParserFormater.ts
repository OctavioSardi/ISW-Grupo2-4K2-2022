import {Injectable} from '@angular/core';
import {NgbDateParserFormatter, NgbDateStruct} from '@ng-bootstrap/ng-bootstrap';


/**
 * This Service handles how the date is rendered and parsed from keyboard i.e. in the bound input field.
 */
@Injectable()
export class DatePickerParserFormatter extends NgbDateParserFormatter {

  readonly DELIMITER = '/';

  parse(value: string): NgbDateStruct | null {
    if (value) {
      let date = value.split(this.DELIMITER);
      return {
        day : parseInt(date[0], 10),
        month : parseInt(date[1], 10),
        year : parseInt(date[2], 10)
      };
    }
    return null;
  }

  format(date: NgbDateStruct | null): string {
    let ret;
    try {
      // ret = new Date(
      //   date.year,
      //   date.month - 1, 
      //   date.day
      // );

      ret = (date.day < 10 ? '0' + date.day : date.day) + '/' + (date.month < 10 ? '0' + date.month : date.month) + '/' + date.year;      
    } catch (ex) {
      ret = '';
    }
    return ret;
  }
}