import { Component, OnInit, Input, Inject, ViewChild } from '@angular/core';
import { ApiServiceService } from '../services/apiservice.service';

@Component({
  selector: 'app-add-edit-person',
  templateUrl: './add-edit-person.component.html',
})

export class AddEditPersonComponent implements OnInit {

  constructor(private service: ApiServiceService) { }

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
        
    this.service.addPerson(person).subscribe(result => {     
      this.SuccessMessage = "Success";
      
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
   
    this.service.updatePerson(person).subscribe(result => {
      this.SuccessMessage = "Success";      
    }, error => this.ErrorMessage = "Error"); //console.error(error));
  }
}
