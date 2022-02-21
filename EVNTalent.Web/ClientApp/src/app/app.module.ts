import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CandidateAddEditFormComponent } from './candidate-add-edit-form/candidate-add-edit-form.component';
import { CandidateDetailsComponent } from './candidate-details/candidate-details.component';
import { FilterComponent } from './fragments/filter/filter.component';
import { FooterComponent } from './fragments/footer/footer.component';
import { NavBarComponent } from './fragments/nav-bar/nav-bar.component';

@NgModule({
  declarations: [
    AppComponent,
   HomeComponent,
    CandidateAddEditFormComponent,
    CandidateDetailsComponent,
    FilterComponent,
   FooterComponent,
    NavBarComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
       { path: '', component: HomeComponent, pathMatch: 'full' },
       { path: 'details/:id', component: CandidateDetailsComponent },
       { path: 'edit/:id', component: CandidateAddEditFormComponent },
       { path: 'create', component: CandidateAddEditFormComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
