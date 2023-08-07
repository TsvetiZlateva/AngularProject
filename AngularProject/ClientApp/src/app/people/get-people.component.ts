import { Component } from '@angular/core';
import * as moment from 'moment';
import { ApiServiceService } from '../services/apiservice.service';

@Component({
  selector: 'app-get-people',
  templateUrl: './get-people.component.html'
})

export class PeopleComponent {
  public people: Person[] = [];
  public person: any;
  ModalTitle = "";
  ActivateAddEditPersonComp: boolean = false;

  constructor(private service: ApiServiceService) { }

  ngOnInit(): void {
    this.refreshPeopleList();
  }

  addUser() {
    this.person = {
      PersonId: "0"
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
    if (confirm('Are you sure you want to delete this person?')) {
      
      this.service.deletePerson(person.personId).subscribe(result => {
        alert("Succsess");
        this.refreshPeopleList();
      }, error => console.error(error));
    }
  } 

  //TODO: add event listener for closing modal
  closeClick() {
    this.ActivateAddEditPersonComp = false;
    this.refreshPeopleList();
  }

  refreshPeopleList() {
    this.service.getPeopleList().subscribe(result => {
      this.people = result;
    }, error => console.error(error));
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
