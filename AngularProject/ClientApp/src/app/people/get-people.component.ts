import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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

  edutUser() {
    //TODO
  }

  deleteUser() {
    //TODO
  }

  closeClick() {
    this.ActivateAddEditPersonComp = false;    
  }
}

export interface Person {
  personId: string;
  firstName: string;
  surname: string;
  dateOfBirth: Date; //Date
  address: string;
  phone: string;
  iban: string;
}
