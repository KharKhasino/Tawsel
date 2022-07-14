import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { City } from 'src/Models/City.model';
import { Governorate } from 'src/Models/Governorate.model';

@Injectable({
  providedIn: 'root'
})
export class GovernService {

  constructor(private http: HttpClient) { }

  apiBaseUrl = environment.apiBaseUrl;
  govId: number;
  passParam(_id: number) {
    this.govId = _id;
    return this.govId;
  }

  getAllGoverns(): Observable<Governorate[]> {
    return this.http.get<Governorate[]>(this.apiBaseUrl + '/api/Governorates');
  }

  getCities(id: string): Observable<Governorate> {
    return this.http.get<Governorate>(this.apiBaseUrl + '/api/Governorates/' + id)
  }

  getCityById(id: string): Observable<City> {
    return this.http.get<City>(this.apiBaseUrl + '/api/Cities/' + id)
  }

  AddCity(item: City):Observable<City> {
    return this.http.post<City>(this.apiBaseUrl + '/api/Cities', item)
  }
  DeleteCity(id: string) {
    return this.http.delete(this.apiBaseUrl + '/api/Cities/' + id)
  }
}
