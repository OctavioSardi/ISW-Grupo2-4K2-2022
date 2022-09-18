import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PreloadAllModules, RouterModule } from '@angular/router';
import {
  NgbDatepickerModule,
  NgbModalModule,
  NgbModule,
  NgbPaginationModule,
  NgbTypeaheadModule,
  NgbDateAdapter,
  NgbDateParserFormatter,
  NgbDatepickerI18n,
} from '@ng-bootstrap/ng-bootstrap';
import { APP_BASE_HREF, DatePipe } from '@angular/common';

import { AppComponent } from './app.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { MenuComponent } from './components/menu/menu.component';
import { ModalDialogComponent } from './components/modal-dialog/modal-dialog.component';
import { PedidoComponent } from './components/pedido/pedido.component';

import { MyInterceptor } from './shared/my-interceptor';

import { DatePickerAdapterISO } from './shared/DatePickerAdapterISO';
import { DatePickerParserFormatter } from './shared/DatePickerParserFormater';
import { DatePickerSpanish } from './shared/DatePickerSpanish';
import { FormFocusDirective } from './shared/form-focus.directive';
import { CarritoComponent } from './components/carrito/carrito.component';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,

    //Ref Angular Routing
    RouterModule.forRoot(
      [
        { path: '', redirectTo: '/inicio', pathMatch: 'full' },
        { path: 'inicio', component: InicioComponent },
        { path: 'pedido', component: PedidoComponent },

        //Ref Angular LazyLoad #1  https://angular.io/guide/lazy-loading-ngmodules

        { path: '**', redirectTo: '/inicio', pathMatch: 'full' },
      ],
      {
        relativeLinkResolution: 'legacy',
        // Ref Angular LazyLoad #2 https://angular.io/guide/lazy-loading-ngmodules
        preloadingStrategy: PreloadAllModules,
      }
    ),
    NgbModule,
    NgbPaginationModule,
    NgbModalModule,
    NgbTypeaheadModule,
    NgbDatepickerModule,
  ],
  declarations: [
    AppComponent,
    InicioComponent,
    MenuComponent,
    PedidoComponent,
    ModalDialogComponent,
    CarritoComponent,
  ],
  entryComponents: [ModalDialogComponent],
  providers: [
    DatePipe,
    { provide: APP_BASE_HREF, useValue: '/' },
    { provide: HTTP_INTERCEPTORS, useClass: MyInterceptor, multi: true },

    // ref angular ngbootrapt datepicker
    { provide: NgbDateAdapter, useClass: DatePickerAdapterISO },
    { provide: NgbDateParserFormatter, useClass: DatePickerParserFormatter }, // formato datepicker desde/hacia el imput
    { provide: NgbDatepickerI18n, useClass: DatePickerSpanish },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
