import { Component, OnInit } from '@angular/core';
import { GenresService } from '../genres.service';
import { Genre } from '../models/genre';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  genres: Genre[];

  constructor(private genresService: GenresService) { }

  ngOnInit() {
    this.getGenres();
  }

  private getGenres(): void {
    if (this.genres == null || this.genres.length == 0) {
      this.genresService.getGenres().subscribe(genres => {
        this.genres = genres;
      });
    }
  }
}
