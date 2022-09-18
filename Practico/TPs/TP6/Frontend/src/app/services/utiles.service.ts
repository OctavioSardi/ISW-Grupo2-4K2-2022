import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class UtilesService {
  constructor() {}

  Fecha_SumarIntervalo(
    FechaISO: string,
    Dias: number,
    Horas: number,
    Minutos: number
  ) {
    var d = new Date(FechaISO);
    d.setDate(d.getDate() + Dias);
    if (Horas) d.setHours(d.getHours() + Horas);
    if (Minutos) d.setMinutes(d.getMinutes() + Minutos);
    return d.toISOString();
  }
  ///
  /// compara fechas 0 iguales, 1 mayor, -1 menor
  ///
  Fecha_Comparar(FechaISO1: string, FechaISO2: string) {
    let f1 = new Date(FechaISO1);
    let f2 = new Date(FechaISO2);
    if (f1 == f2) return 0;
    if (f1 > f2) return 1;
    return -1;
  }
  FechaHoraActual_ISO() {
    // problema con offset al convertir toIsoString no tomo hora local
    let Fecha = new Date().toISOString();
    Fecha = this.Fecha_SumarIntervalo(
      Fecha,
      0,
      0,
      -new Date().getTimezoneOffset()
    ); // sacar el offset local de la hora
    return Fecha;
  }

  Fecha_ISO_ddMMyyyy(FechaISO: string) {
    try {
      var arrFecha = FechaISO.substr(0, 10).split("-");
      return arrFecha[2] + "/" + arrFecha[1] + "/" + arrFecha[0];
    } catch (error) {
      return "";
    }
  }

  Fecha_ISO_Struct(FEchaISO: string) {
    try {
      let f = new Date(FEchaISO);
      let struct = {
        year: f.getFullYear(),
        month: f.getMonth() + 1,
        day: f.getDate()
      };
      return struct;
    } catch (error) {
      return null;
    }
  }

  Fecha_ddMMyyyy_ISO(FechaString: string) {
    try {
      let arrFecha = FechaString.substr(0, 10).split("/");
      if (arrFecha.length == 3)
        return new Date(
          +arrFecha[2],
          +arrFecha[1] - 1,
          +arrFecha[0]
        ).toISOString();
    } catch (error) {
      return "";
    }
  }
}
