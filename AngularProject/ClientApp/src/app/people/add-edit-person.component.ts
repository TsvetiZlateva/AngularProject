import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, Input, Inject, ViewChild } from '@angular/core';
import { Person } from './get-people.component'

@Component({
  selector: 'app-add-edit-person',
  templateUrl: './add-edit-person.component.html',
})

export class AddEditPersonComponent implements OnInit {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  @Input() person: any;
  PersonId = "";
  FirstName = "";
  Surname = "";
  DateOfBirth = null;
  Address = "";
  Phone = "";
  IBAN = "";
  SuccessMessage = "";
  ErrorMessage = "";

  ngOnInit(): void {
    this.PersonId = this.person.PersonId;
    this.FirstName = this.person.FirstName;
    this.Surname = this.person.Surname;
    this.DateOfBirth = this.person.DateOfBirth;
    this.Address = this.person.Address;
    this.Phone = this.person.Phone;
    this.IBAN = this.person.IBAN;
  }

  addPerson() {
    let person = {
      FirstName: this.FirstName,
      Surname: this.Surname,
      DateOfBirth: this.DateOfBirth,
      Address: this.Address,
      Phone: this.Phone,
      IBAN: this.IBAN,
    };

    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    this.http.post<Person>(this.baseUrl + 'people', person, httpOptions).subscribe(result => {     
      this.SuccessMessage = "Success";
      //this.refreshList();

      this.FirstName = "";
      this.Surname = "";
      this.DateOfBirth = null;
      this.Address = "";
      this.Phone = "";
      this.IBAN = "";      
    }, error => this.ErrorMessage = "Error"); //console.error(error));
  }

  updatePerson() {
    let person = {
      PersonId: this.PersonId,
      FirstName: this.FirstName,
      Surname: this.Surname,
      DateOfBirth: this.DateOfBirth,
      Address: this.Address,
      Phone: this.Phone,
      IBAN: this.IBAN,
    };

    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    this.http.put<Person>(this.baseUrl + 'people', person, httpOptions).subscribe(result => {
      this.SuccessMessage = "Success";
      //this.refreshList();
    }, error => this.ErrorMessage = "Error"); //console.error(error));
  }
}
