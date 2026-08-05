import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../models/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private http = inject(HttpClient);

  private api = 'https://localhost:7020/api/produtos';

  buscar(termo:string):Observable<Produto[]>{

      return this.http.get<Produto[]>(
        `${this.api}?busca=${termo}`
      );

  }
}
