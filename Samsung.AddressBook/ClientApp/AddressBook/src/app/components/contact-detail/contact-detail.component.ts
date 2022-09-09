import { Component, OnChanges, Input, Output, SimpleChanges } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AddressType, Contact, ContactAddress, ContactPhone, PhoneType } from 'src/app/models';
import { CreateContactRequest } from 'src/app/models/api/contact';
import { ContactService } from 'src/app/services/contact.service';
import { AlertsService } from 'src/app/shared/alerts/alerts.service';

@Component({
  selector: 'app-contact-detail',
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.scss']
})
export class ContactDetailComponent implements OnChanges {
  PhoneType = PhoneType;
  AddressType = AddressType;
  @Input() contactId: number = 0;
  @Output() shouldRefresh = new EventEmitter<void>();

  contact: Contact | undefined;
  phones: ContactPhone[] = [];
  addresses: ContactAddress[] = [];

  editMode = false;
  nameEdit: undefined | string;
  isFavoriteEdit: boolean = false;
  phoneEdit: string | undefined;
  addressEdit: string | undefined;
  phoneType: PhoneType | undefined;
  addressType: AddressType | undefined;

  constructor(private contactsService: ContactService, private activatedRoute: ActivatedRoute,
    private router: Router, private alertsService: AlertsService) { }
  ngOnChanges(changes: SimpleChanges) {

    if (this.contactId === 0) {
      console.log(this.contactId)
      this.initializeEdits();
      this.editMode = true;
    }
    else {
      this.editMode = false;
      this.fetchData();
    }
  }
  initializeEdits() {
    this.nameEdit = '';
    this.isFavoriteEdit = false;
    this.addressType = undefined;
    this.phoneType = undefined;
    this.addressEdit = undefined;
    this.phoneEdit = undefined;
    this.phones = [];
    this.addresses = [];
  }
  fetchData() {
    this.phones = []
    this.addresses = [];
    if (this.contactId === 0) return;
    this.contactsService.getContact(this.contactId).subscribe(response => {
      if (response === undefined) return;
      this.contact = response;
      this.addresses = this.contact?.addresses ?? [];
      this.phones = this.contact?.phones ?? [];

      this.nameEdit = this.contact.name;
      this.isFavoriteEdit = this.contact.isFavorite;

    });
  }

  cancelClicked() {
    if (this.editMode == true && this.contactId !== 0) {
      this.editMode = false;
      return
    }

    this.router.navigate([],
      {
        relativeTo: this.activatedRoute,
        queryParams: {
          id: null
        },
        queryParamsHandling: 'merge',
      });
  }
  saveClicked() {
    if (this.nameEdit === undefined || this.nameEdit === '') return;
    if (this.contactId !== 0) {
      let body = {
        id: this.contactId,
        name: this.nameEdit,
        isFavorite: this.isFavoriteEdit
      }

      this.contactsService.updateContact(body).subscribe(response => {
        this.alertsService.addSuccessAllert("Updated contact");
        this.fetchData();
        this.shouldRefresh.emit();
      });
    }
    else {
      let body: CreateContactRequest = {
        name: this.nameEdit,
        isFavorite: this.isFavoriteEdit,
        phones: undefined,
        addresses: undefined
      }
      if (!(this.phoneEdit === undefined || this.phoneType === undefined || this.phoneEdit === '')) {
        body['phones'] = { value: this.phoneEdit.toString(), type: this.phoneType };
      }

      if (!(this.addressEdit === undefined || this.addressType === undefined || this.addressEdit === '')) {
        body['addresses'] = { value: this.addressEdit, type: this.addressType };
      }

      this.contactsService.createContact(body).subscribe(response => {
        this.alertsService.addSuccessAllert("Created contact");
        this.fetchData();
        this.shouldRefresh.emit();
        this.cancelClicked();
      });

    }
  }

  addPhone() {
    if (this.phoneEdit === undefined || this.phoneType === undefined || this.contactId === 0) return;
    let body = {
      contactId: this.contactId,
      type: this.phoneType,
      value: this.phoneEdit.toString()
    }

    this.contactsService.createPhone(body).subscribe(response => {
      this.alertsService.addSuccessAllert("Added Phone");
      this.fetchData();
      this.phoneEdit = undefined;
      this.phoneType = undefined;
    })
  }
  addAddress() {
    if (this.addressEdit === undefined || this.addressType === undefined || this.contactId === 0) return;
    let body = {
      contactId: this.contactId,
      type: this.addressType,
      value: this.addressEdit
    }

    this.contactsService.createAddress(body).subscribe(response => {
      this.alertsService.addSuccessAllert("Added Address");
      this.addressEdit = undefined;
      this.addressType = undefined
      this.fetchData();
    })
  }

  deletePhone(id: number) {
    this.contactsService.deletePhone(id).subscribe(response => {
      this.alertsService.addSuccessAllert("Deleted Phone");
      this.fetchData();

    })
  }
  deleteAddress(id: number) {
    this.contactsService.deleteAddress(id).subscribe(response => {
      this.alertsService.addSuccessAllert("Deleted Address");
      this.fetchData();
    })
  }

  updatePhone(phone: ContactPhone) {
    if (phone.value === '' || phone.value === undefined) return;
    let body = {
      id: phone.id,
      value: phone.value.toString(),
      type: phone.type
    }
    this.contactsService.updatePhone(body).subscribe(response => {
      this.alertsService.addSuccessAllert("Updated Phone");
      this.fetchData();
    })
  }

  updateAddress(address: ContactAddress) {
    if (address.value === '' || address.value === undefined) return;
    let body = {
      id: address.id,
      value: address.value,
      type: address.type
    }
    this.contactsService.updateAddress(body).subscribe(response => {
      this.alertsService.addSuccessAllert("Updated Address");
      this.fetchData();
    })
  }

}
