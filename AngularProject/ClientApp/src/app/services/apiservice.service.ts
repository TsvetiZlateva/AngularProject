import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ApiServiceService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPeopleList(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + 'people');
  }

  addPerson(person: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.baseUrl + 'people', person, httpOptions);
  }

  updatePerson(person: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.baseUrl + 'people', person, httpOptions);
  }

  deletePerson(personId: string): Observable<string> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<string>(this.baseUrl + `people/?personId=${personId}`, httpOptions);
  }
}
