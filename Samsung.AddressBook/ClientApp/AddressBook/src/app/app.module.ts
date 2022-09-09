import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbAlertModule, NbSpinnerModule, NbInputModule, NbCheckboxModule, NbButtonModule, NbIconModule, NbSelectModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { HttpClientModule } from '@angular/common/http';
import { AlertsComponent } from './shared/alerts/alerts.component';
import { LoaderComponent } from './shared/loader/loader.component';
import { ContactDetailComponent } from './components/contact-detail/contact-detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OnlyNumber } from './directives/only-number';
@NgModule({
  declarations: [
    AppComponent,
    AlertsComponent,
    LoaderComponent,
    ContactDetailComponent,
    OnlyNumber
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'corporate' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbAlertModule,
    NbSpinnerModule,
    NbSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NbInputModule,
    NbCheckboxModule,
    NbButtonModule,
    NbIconModule,
    ScrollingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
