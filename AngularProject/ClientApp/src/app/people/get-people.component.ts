import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-get-people',
  templateUrl: './get-people.component.html'
})

export class PeopleComponent {
  public people: Person[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Person[]>(baseUrl + 'people').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
  }

  addUser() {
    //TODO
  }

  edutUser() {
    //TODO
  }

  deleteUser() {
    //TODO
  }
}

interface Person {
  personId: string;
  firstName: number;
  surname: number;
  dateOfBirth: string; //Date
  address: string;
  phone: string;
  iban: string;
}
