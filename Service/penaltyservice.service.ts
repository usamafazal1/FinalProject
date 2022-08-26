import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../models/Country';
import { inputReceived } from '../models/inputReceived';
import { outGiven } from '../models/outGiven';


@Injectable({
  providedIn: 'root'
})
export class PenaltyserviceService {


    constructor(private http: HttpClient) { }

    GetCountries(): Observable<Country[]> {
        return this.http.get<Country[]>('api/Penalty/GetCountry');
    }

    GetPenalty(input: inputReceived): Observable<outGiven> {
        return this.http.post<outGiven>('api/Penalty/GetPenalty', input)
    }
}
