import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FilmsComponent } from './films/films.component';
import { GenresComponent } from './genres/genres.component';
import { AddFilmComponent } from './add-film/add-film.component';
import { EditFilmComponent } from './edit-film/edit-film.component';

const routes: Routes = [
  { path: '', redirectTo: '/films', pathMatch: 'full' },
  { path: 'films', component: FilmsComponent },
  { path: 'genres', component: GenresComponent },
  { path: 'add-film', component: AddFilmComponent },
  { path: 'edit-film/:id', component: EditFilmComponent},
  { path: '**', redirectTo: 'films' } // not found page - should be at the end
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
