import { Component, OnInit } from '@angular/core';
import { ForecastService } from './core/services/forecast.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  result: any[] = [];

  constructor(private fserv: ForecastService) {
  }

  ngOnInit(): void {
  }

  onSubmit(cityId: number): void {
    this.fserv.GetForecast(cityId).subscribe(response => this.result = response);
  }
}
