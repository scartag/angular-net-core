import {Component, OnInit} from '@angular/core';
import { Contact, ContactService } from '../services/contact.service';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss'],
})
export class ContactFormComponent implements OnInit {
  submittedContacts: Contact[] = [];
  isLoading: boolean = false;
  showError: boolean = false;
  contact: Contact = { name: '', address: '' };
  myForm: FormGroup = new FormGroup({});

  constructor(
    private contactService: ContactService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.myForm = this.formBuilder.group({
      name: new FormControl(this.contact.name, [Validators.required]),
      address: new FormControl(this.contact.address),
    });
  }

  get name() {
    return this.myForm.get('name');
  }


  get address() {
    return this.myForm.get('address');
  }

  onSubmit() {
    if(this.myForm.valid){
      this.isLoading = true;
      const nameValue = this.myForm.get('name')?.value;
      const addressValue = this.myForm.get('address')?.value;
      const contact : Contact = { name: nameValue, address: addressValue };
      this.contactService.createContact(contact).subscribe({
        next: (response) => {
          this.submittedContacts = [response, ...this.submittedContacts];
          this.myForm.reset();
        },
        error: (error) => {
          this.showError = true;
          setTimeout(() => {
            this.showError = false;
          }, 3000);
          this.isLoading = false;
          console.error('Error submitting contact', error);
        },
        complete: () => {
          this.isLoading = false;
          console.log('Submission complete');
        },
      });
    }
  }
}
