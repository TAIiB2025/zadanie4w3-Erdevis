import { Injectable } from '@angular/core';
import { Film } from '../models/film';
import { Observable, catchError, of, throwError } from 'rxjs';
import { FilmBody } from '../models/film-body';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ListaService {
  private readonly apiUrl = 'http://localhost:5013/api/films';

  constructor(private http: HttpClient) {}

  get(): Observable<Film[]> {
    return this.http.get<Film[]>(this.apiUrl)
      .pipe(catchError(this.handleError));
  }

  getByID(id: number): Observable<Film> {
    return this.http.get<Film>(`${this.apiUrl}/${id}`)
      .pipe(catchError(this.handleError));
  }

  post(body: FilmBody): Observable<Film> {
    return this.http.post<Film>(this.apiUrl, body)
      .pipe(catchError(this.handleError));
  }

  put(id: number, body: FilmBody): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, body)
      .pipe(catchError(this.handleError));
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.error('Błąd HTTP:', error);
    return throwError(() => new Error('Coś poszło nie tak; spróbuj ponownie później.'));
  }

//   private static idGen = 1;

//   private lista: Film[] = [
//   { id: ListaService.idGen++, tytul: "Incepcja", rezyser: "Christopher Nolan", gatunek: "Sci-Fi", rok_wydania: 2010 },
//   { id: ListaService.idGen++, tytul: "Parasite", rezyser: "Bong Joon-ho", gatunek: "Dramat", rok_wydania: 2019 },
//   { id: ListaService.idGen++, tytul: "Skazani na Shawshank", rezyser: "Frank Darabont", gatunek: "Dramat", rok_wydania: 1994 },
//   { id: ListaService.idGen++, tytul: "Matrix", rezyser: "Lana i Lilly Wachowski", gatunek: "Sci-Fi", rok_wydania: 1999 },
//   { id: ListaService.idGen++, tytul: "Gladiator", rezyser: "Ridley Scott", gatunek: "Historyczny", rok_wydania: 2000 }
// ];

//   get(): Observable<Film[]> {
//     return of(this.lista);
//   }

//   getByID(id: number): Observable<Film> {
//     const ksiazka = this.lista.find(k => k.id === id);
//     if(ksiazka == null) {
//       throw new Error('Nie znaleziono wskazanej książki');
//     }
//     return of(ksiazka);
//   }

//   delete(id: number): Observable<void> {
//     this.lista = this.lista.filter(k => k.id !== id);
//     return of(undefined);
//   }

//   put(id: number, body: FilmBody): Observable<void> {
//     const ksiazka = this.lista.find(k => k.id === id);
//     if(ksiazka == null) {
//       throw new Error('Nie znaleziono wskazanej książki');
//     }

//     ksiazka.rezyser = body.rezyser;
//     ksiazka.gatunek = body.gatunek;
//     ksiazka.rok_wydania = body.rok_wydania;
//     ksiazka.tytul = body.tytul;

//     return of(undefined);
//   }

//   post(body: FilmBody): Observable<void> {
//     const ksiazka: Film = {
//       id: ListaService.idGen++,
//       rezyser: body.rezyser,
//       gatunek: body.gatunek,
//       rok_wydania: body.rok_wydania,
//       tytul: body.tytul
//     };

//     this.lista.push(ksiazka);

//     return of(undefined);
//   }
}
