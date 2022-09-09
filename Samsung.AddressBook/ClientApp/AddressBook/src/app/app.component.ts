import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact, ContactAddress } from './models';
import { ContactService } from './services/contact.service';
import { AlertsService } from './shared/alerts/alerts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'AddressBook';


  selectedId: number | null = null;
  previousSelectedId: number | null = null;

  searchText: string | null = null;
  onlyFavorites: boolean = false;

  contacts: Contact[] = []

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private contactsService: ContactService,
    private alertsService: AlertsService) { }
  ngOnInit(): void {
    this.fetchData()
    this.activatedRoute.queryParamMap.subscribe(query => {
      let idQuery = query.get('id')
      this.selectedId = idQuery == null ? idQuery : parseInt(idQuery);


      this.searchText = query.get('search');
      this.onlyFavorites = query.get('favorites') == 'true' ? true : false;
      if (this.selectedId == this.previousSelectedId) {
        this.fetchData();
      }
      this.previousSelectedId = this.selectedId;
    })
  }
  fetchData() {
    this.contactsService.getContacts(this.onlyFavorites, this.searchText).subscribe(response => {
      if (response === undefined) { return; }
      this.contacts = response;
    })
  }
  toggleFavorites(checked: boolean) {

    this.router.navigate([],
      {
        relativeTo: this.activatedRoute,
        queryParams: {
          favorites: checked === true ? true : null
        },
        queryParamsHandling: 'merge',
      });

  }
  searchChanged() {
    if (this.searchText === '') this.searchText = null;
    this.router.navigate([],
      {
        relativeTo: this.activatedRoute,
        queryParams: {
          search: this.searchText
        },
        queryParamsHandling: 'merge',
      });
  }

  selectId(id: number) {
    this.router.navigate([],
      {
        relativeTo: this.activatedRoute,
        queryParams: {
          id
        },
        queryParamsHandling: 'merge',
      });
  }

  deleteContact(id: number) {
    this.contactsService.deleteContact(id)
      .subscribe(data => {
        this.alertsService.addSuccessAllert("Deleted Contact");
        this.fetchData();
      })
  }
}
