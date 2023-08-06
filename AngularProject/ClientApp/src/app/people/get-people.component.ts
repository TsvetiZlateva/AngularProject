import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as moment from 'moment';

@Component({
  selector: 'app-get-people',
  templateUrl: './get-people.component.html'
})

export class PeopleComponent {
  public people: Person[] = [];
  public person: any;
  ModalTitle = "";
  ActivateAddEditPersonComp: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Person[]>(baseUrl + 'people').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
  }

  addUser() {
    this.person = {
      PersonId: "0",
      //FirstName: ""
    }
    this.ModalTitle = "Add New Person";
    this.ActivateAddEditPersonComp = true;
  }

  editUser(person: Person) {
    this.person = {
      PersonId: person.personId,
      FirstName: person.firstName,
      Surname: person.surname,
      DateOfBirth: moment(new Date(person.dateOfBirth)).format('YYYY-MM-DD') ,
      Address: person.address,
      Phone: person.phone,
      IBAN: person.iban,
    }
    this.ModalTitle = "Edit Person";
    this.ActivateAddEditPersonComp = true;
  }

  deleteUser(person: any) {
    if (confirm('Are you sure??')) {
      const httpOptions = {
        headers:new HttpHeaders({ 'Content-Type': 'application/json' }),
      };

      this.http.delete<string>(this.baseUrl + `people/?personId=${person.personId}`, httpOptions).subscribe(result => {
        alert("Succsess");
        //this.refreshList();
      }, error => console.error(error));
    }
  } 

  closeClick() {
    this.ActivateAddEditPersonComp = false;
  }
}

export interface Person {
  personId: string;
  firstName: string;
  surname: string;
  dateOfBirth: Date;
  address: string;
  phone: string;
  iban: string;
}
