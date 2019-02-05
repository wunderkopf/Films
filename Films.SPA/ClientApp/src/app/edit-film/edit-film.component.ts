import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from "@angular/forms";
import { Observable, of } from 'rxjs';
import { ActivatedRoute, Router } from "@angular/router";

import { Genre } from "../models/genre";
import { GenresService } from "../services/genres.service";
import { Film } from '../models/film';
import { FilmsService } from '../services/films.service';

@Component({
  selector: 'app-edit-film',
  templateUrl: './edit-film.component.html',
  styleUrls: ['./edit-film.component.css']
})
export class EditFilmComponent implements OnInit {

  private id: number;

  public editForm: FormGroup;
  public genres: Observable<Genre[]>;

  constructor(private formBuilder: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute,
    private genresService: GenresService, private filmsService: FilmsService) {
  }

  ngOnInit() {
    this.activatedRoute.url.subscribe(url => {
      this.id = +this.activatedRoute.snapshot.paramMap.get('id');
      if (Number.isNaN(this.id) || this.id <= 0) {
        this.router.navigate(['films']);
      }

      this.filmsService.getFilm(this.id).subscribe(film => {
        this.genres = this.genresService.getGenres();
        this.genres.subscribe(gs => {
          var controls = [];
          gs.forEach(genre => {
            if (film.genres.find(x => x == genre.id) != null) {
              controls.push(new FormControl(true));
            }
            else {
              controls.push(new FormControl(false));
            }
          });

          this.editForm = this.formBuilder.group({
            title: [film.title, Validators.required],
            genres: [controls]
          });
        });
      });
    });
  }

  public onSubmit(value: any) {
    if (this.editForm.invalid) {
      return;
    }

    this.genres.subscribe(gs => {
      var genres: number[] = [];
      this.editForm.value['genres'].forEach((item, index) => {
        if (item.value) {
          genres.push(gs[index].id);
        }
      });
  
      const film: Film = { id: this.id, title: value.title, genres: genres, genresTitles: [] };
      this.filmsService.updateFilm(this.id, film).subscribe(data => {
        this.router.navigate(['films']);
      });
    });
  }

  public onChange(event: any) {
    var index: number = +event.source.name;
    this.editForm.value['genres'][index].value = event.checked;
  }

  public onCancel(event: any) {
    this.router.navigate(['films']);
  }
}
