import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Contact } from '../models';
import { AddAddressRequest, UpdateAddressRequest } from '../models/api/address';
import { CreateContactRequest, UpdateContactRequest } from '../models/api/contact';
import { AddPhoneRequest, UpdatePhoneRequest } from '../models/api/phone';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(
    private http: HttpService) {
  }


  getContacts(favorites: boolean, searchText: string | null) {
    console.log(favorites, searchText)
    let params = new HttpParams();
    if (favorites === true) {
      params = params.append('favorites', true);
    }
    if (searchText !== null && searchText !== '') {
      params = params.append('search', searchText)
    }

    return this.http.getWithLoader<Contact[] | undefined>(environment.contactsUri, { params: params });
  }

  getContact(id: number) {
    return this.http.getWithLoader<Contact | undefined>(`${environment.contactsUri}/${id}`);
  }

  createPhone(body: AddPhoneRequest) {
    return this.http.postWithLoader(environment.phonesUri, body);
  }
  createAddress(body: AddAddressRequest) {
    return this.http.postWithLoader(environment.addressesUri, body);
  }
  deletePhone(id: number) {
    return this.http.deleteWithLoader(`${environment.phonesUri}/${id}`)
  }

  deleteAddress(id: number) {
    return this.http.deleteWithLoader(`${environment.addressesUri}/${id}`)
  }
  deleteContact(id: number) {
    return this.http.deleteWithLoader(`${environment.contactsUri}/${id}`)
  }

  updatePhone(body: UpdatePhoneRequest) {
    return this.http.patchWithLoader(environment.phonesUri, body);
  }

  updateAddress(body: UpdateAddressRequest) {
    return this.http.patchWithLoader(environment.addressesUri, body);
  }
  updateContact(body: UpdateContactRequest) {
    return this.http.patchWithLoader(environment.contactsUri, body);
  }

  createContact(body: CreateContactRequest) {
    return this.http.postWithLoader(environment.contactsUri, body);
  }
}
