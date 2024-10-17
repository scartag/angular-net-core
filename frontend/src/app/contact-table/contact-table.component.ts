import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Contact } from "../services/contact.service";

@Component({
  selector: 'app-contact-table',
  templateUrl: './contact-table.component.html',
  styleUrls: ['./contact-table.component.scss']
})
export class ContactTableComponent implements OnChanges{
  @Input() contacts: Contact[] = [];
  paginatedContacts: Contact[] = [];
  pageSize: number = 4;
  currentPage: number = 1;
  totalPages: number = 0;

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['contacts'] && this.contacts) {
      this.totalPages = Math.ceil(this.contacts.length / this.pageSize);
      this.updatePaginatedContacts();
      console.log("Contacts updated", this.contacts);
    }
  }

  updatePaginatedContacts(): void {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.paginatedContacts = this.contacts.slice(startIndex, endIndex);
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.updatePaginatedContacts();
    }
  }

  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updatePaginatedContacts();
    }
  }
}
