import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { Router } from "@angular/router";
import { FilmsService } from '../services/films.service';
import { Film } from '../models/film';
import { GenresService } from '../services/genres.service';

@Component({
    selector: 'app-films',
    templateUrl: './films.component.html',
    styleUrls: ['./films.component.css']
})

export class FilmsComponent implements OnInit {

    private films: Film[];

    displayedColumns: string[] = ['id', 'title', 'genres', 'actions'];
    dataSource: MatTableDataSource<Film>;

    constructor(private router: Router, private filmsService: FilmsService,
        private genresService: GenresService) { }

    ngOnInit() {
        this.getFilms();
    }

    private getFilms(): void {
        this.filmsService.getFilms().subscribe(films => {
            this.films = films;

            this.genresService.getGenres().subscribe(genres => {
                this.films.forEach((film, index) => {
                    film.genresTitles = [];
                    film.genres.forEach((id, index) => {
                        film.genresTitles[index] = [id, genres.find(x => x.id == id).title];
                    });
                });

                this.dataSource = new MatTableDataSource<Film>(this.films);
            });
        });
    }

    public addFilm(): void {
        this.router.navigate(['add-film']);
    }

    public deleteFilm(filmID: number): void {
        this.filmsService.deleteFilm(filmID).subscribe(res => {
            var data = this.dataSource.data;
            const itemIndex = data.findIndex(obj => obj.id === filmID);
            data.splice(itemIndex, 1);
            this.dataSource = new MatTableDataSource<Film>(data);
        });
    }

    public editFilm(filmID: number): void {
        this.router.navigate(['edit-film', filmID]);
    }
}
