import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";

@Injectable()
export class ForecastService {
    
    constructor(private http: Http) {
    
    }


    GetForecast(cityId: number): Observable<any[]> {
      return this.http.get(`api/forecast/${cityId}`)
        .pipe(map(res => 
          res.json()
        ));
    }
}
