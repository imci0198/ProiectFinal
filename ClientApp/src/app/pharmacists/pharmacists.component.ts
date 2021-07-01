import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pharmacist } from './pharmacist.model';

@Component({
  selector: 'app-pharmacists',
  templateUrl: './pharmacists.component.html',
  styleUrls: ['./pharmacists.component.css']
})
export class PharmacistsComponent implements OnInit {

  public pharmacists: Pharmacist[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Pharmacist[]>(apiUrl + 'pharmacist').subscribe(result => {
      this.pharmacists = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
