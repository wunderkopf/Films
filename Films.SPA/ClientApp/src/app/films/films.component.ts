import { Component, OnInit } from '@angular/core';
import { FilmsService } from '../films.service';
import { Film } from '../models/film';

@Component({
  selector: 'app-films',
  templateUrl: './films.component.html',
  styleUrls: ['./films.component.css']
})

export class FilmsComponent implements OnInit {

    films: Film[];

  constructor(private filmsService: FilmsService) { }

    ngOnInit() {
        this.getFilms();
  }

    private getFilms(): void {
      this.filmsService.getFilms().subscribe(films => {
        this.films = films;
      });
  }
}
