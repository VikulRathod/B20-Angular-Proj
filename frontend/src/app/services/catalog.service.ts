import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { Catalog } from '../models/catalog';

@Injectable({
  providedIn: 'root'
})
export class CatalogService {
  httpHeaders: HttpHeaders;
  constructor(private httpClient: HttpClient) {
    this.httpHeaders = new HttpHeaders({ 'content-type': 'application/json' });
  }

  GetCatalog(): Observable<HttpResponse<Catalog[]>> {
    return this.httpClient.get<Catalog[]>(environment.apiAddress + "/catalog/getall", { observe: 'response' });
  }
}
