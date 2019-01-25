import { Component, OnInit } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { FilmsService } from '../services/films.service';
import { Film } from '../models/film';

@Component({
    selector: 'app-films',
    templateUrl: './films.component.html',
    styleUrls: ['./films.component.css']
})

export class FilmsComponent implements OnInit {

    films: Film[];

    displayedColumns: string[] = ['id', 'title', 'genres'];
    dataSource: MatTableDataSource<Film>;

    constructor(private filmsService: FilmsService) { }

    ngOnInit() {
        this.getFilms();
    }

    private getFilms(): void {
        this.filmsService.getFilms().subscribe(films => {
            this.films = films;
            this.films.forEach((film, index) => {
                film.genresTitles = [];
                film.genres.forEach((id, index) => {
                    film.genresTitles[index] = [id, 'action'];
                });
            });

            this.dataSource = new MatTableDataSource<Film>(this.films);
        });
    }
}
