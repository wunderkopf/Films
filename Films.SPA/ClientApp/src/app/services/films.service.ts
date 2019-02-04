import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
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

  public getFilms(): Observable<Film[]> {
    return this.http.get<Film[]>(this.filmsUrl)
      .pipe(
        tap(films => this.log(`fetched films`)),
        catchError(this.handleError('getFilms', []))
      );
  }

  public createFilms(films: Film[]): Observable<Film[]> {
    const options = { headers: { 'Content-Type': 'application/json' } };
    return this.http.post<Film[]>(this.filmsUrl, JSON.stringify(films), options)
      .pipe(
        tap(films => this.log(`created films`)),
        catchError(this.handleError('createFilms', []))
      );
  }

  public deleteFilm(id: number): Observable<any> {
    const url = `${this.filmsUrl}/${id}`;

    return this.http.delete(url)
      .pipe(
        tap(films => this.log(`deleted film`)),
        catchError(this.handleError('deleteFilm', []))
      );
  }
}
