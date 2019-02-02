import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from "@angular/forms";
import { Observable, of } from 'rxjs';
import { Router } from "@angular/router";

import { Genre } from "../models/genre";
import { GenresService } from "../services/genres.service";
import { Film } from '../models/film';
import { FilmsService } from '../services/films.service';

@Component({
  selector: 'app-add-film',
  templateUrl: './add-film.component.html',
  styleUrls: ['./add-film.component.css']
})
export class AddFilmComponent implements OnInit {

  addForm: FormGroup;
  public genres: Observable<Genre[]>;

  constructor(private formBuilder: FormBuilder, private router: Router,
    private genresService: GenresService, private filmsService: FilmsService) {
  }

  ngOnInit() {
    this.genres = this.genresService.getGenres();
    this.genres.subscribe(gs => {
      const controls = gs.map(c => new FormControl(false));

      this.addForm = this.formBuilder.group({
        title: ['', Validators.required],
        genres: [controls]
      });
    });
  }

  onSubmit(value: any) {
    if (this.addForm.invalid) {
      return;
    }

    const film: Film = { id: 0, title: value.title, genres: value.genres, genresTitles: [] };
    var films = [film];

    this.filmsService.createFilms(films)
      .subscribe(data => {
        this.router.navigate(['films']);
      });
    //this.router.navigate(['films']);
  }
}
