import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pacient } from './pacient.model';

@Component({
  selector: 'app-pacients',
  templateUrl: './pacients.component.html',
  styleUrls: ['./pacients.component.css']
})
export class PacientsComponent implements OnInit {

  public pacients: Pacient[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Pacient[]>(apiUrl + 'pacient').subscribe(result => {
      this.pacients = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
