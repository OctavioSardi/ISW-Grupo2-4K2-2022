// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  //ConexionWebApiProxy : "/api/"  //usarlo cuando backend y frontend estan en el mismo servidor
  //ConexionWebApiProxy: 'https://pymes2021.azurewebsites.net/api/', //disponibles desde internet
  //ConexionWebApiProxy: 'https://labsys.frc.utn.edu.ar:8443/api/' //disponibles desde internet

  //ConexionWebApiProxy: 'https://localhost:44349/api/', // solo localmente
  // ConexionWebApiProxy: 'https://pymes.com.ar/api/' // solo localmente, mapeado en archivo host a locahost, stackblitz no acepta certificado local de iis
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
