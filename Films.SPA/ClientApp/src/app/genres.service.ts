import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Genre } from './models/genre';

@Injectable({
  providedIn: 'root'
})
export class GenresService {

  private genresUrl = 'https://localhost:5000/api/genres';

  constructor(private http: HttpClient) { }

  private log(message: string) {
    console.log('GenreService: ' + message);
  }

  private error(message: string) {
    console.error('GenreService: ' + message);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  getGenres(): Observable<Genre[]> {
    return this.http.get<Genre[]>(this.genresUrl)
      .pipe(
        tap(accounts => this.log(`fetched genres`)),
        catchError(this.handleError('getGenres', []))
      );
  }
}
