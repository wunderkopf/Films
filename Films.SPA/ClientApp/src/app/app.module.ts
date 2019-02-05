import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import {
  MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule,
  MatTableModule, MatCardModule, MatDialogModule, MatInputModule, MatCheckboxModule
} from '@angular/material';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilmsComponent } from './films/films.component';
import { GenresComponent } from './genres/genres.component';
import { AddFilmComponent } from './add-film/add-film.component';
import { CachingInterceptor } from './services/caching-interceptor';
import { CacheMapService } from './services/cache-map.service';
import { EditFilmComponent } from './edit-film/edit-film.component';

export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: CachingInterceptor, multi: true }
];

@NgModule({
  declarations: [
    AppComponent,
    FilmsComponent,
    GenresComponent,
    AddFilmComponent,
    EditFilmComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatTableModule,
    MatCardModule,
    MatDialogModule,
    MatInputModule,
    MatCheckboxModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    CacheMapService,
    { provide: Cache, useClass: CacheMapService },
    httpInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
