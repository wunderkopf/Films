import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Film } from '../models/film';

@Injectable({
  providedIn: 'root'
})
export class FilmsService {

  private filmsUrl = 'https://localhost:5000/api/films';

  constructor(private http: HttpClient) { }

  private log(message: string) {
    console.log('FilmsService: ' + message);
  }

  private error(message: string) {
    console.error('FilmsService: ' + message);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  getFilms(): Observable<Film[]> {
    return this.http.get<Film[]>(this.filmsUrl)
      .pipe(
        tap(films => this.log(`fetched films`)),
        catchError(this.handleError('getFilms', []))
      );
  }

  createFilms(films: Film[]): Observable<Film[]> {
    const options = { headers: { 'Content-Type': 'application/json' } };
    return this.http.post<Film[]>(this.filmsUrl, JSON.stringify(films), options).pipe(
      tap(films => this.log(`created films`)),
      catchError(this.handleError('createFilms', []))
    );
  }
}
