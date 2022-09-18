import { NgbDatepickerI18n, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { Injectable } from '@angular/core';
import { TranslationWidth } from '@angular/common';


@Injectable()
export class DatePickerSpanish extends NgbDatepickerI18n {
  getWeekdayLabel(weekday: number, width?: TranslationWidth): string {
    throw new Error('Method not implemented.');
  }
  public getWeekdayShortName(weekday: number): string {
      return [
        'Lu',
        'Ma',
        'Mi',
        'Ju',
        'Vi',
        'Sa',
        'Do'
      ][weekday - 1];
  }
  public getMonthShortName(month: number): string {
      return [
        'Ene',
        'Feb',
        'Mar',
        'Abr',
        'May',
        'Jun',
        'Jul',
        'Ago',
        'Sep',
        'Oct',
        'Nov',
        'Dic'
      ][month - 1];
  }
  public getMonthFullName(month: number): string {
    return [
        'Enero',
        'Febrero',
        'Marzo',
        'Abril',
        'Mayo',
        'Junio',
        'Julio',
        'Agosto',
        'Septiembre',
        'Octubre',
        'Noviembre',
        'Diciembre'
      ][month - 1];
  }
  public getDayAriaLabel(date: NgbDateStruct): string {
      return date.day + ' de ' + this.getMonthFullName(date.month) + ', ' + date.year;
  }
}