import { Injectable } from '@angular/core';
import {  HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { InvestorDetails } from './investor-details';
import { AppConfig } from '../app.config';

@Injectable()
export class InvestorService {
  apiBaseUrl: string = AppConfig.apiBaseUrl;
  constructor(
    private httpClient: HttpClient
  ) { }

  // Service method to retrieve Country list
  public getCountryList(): Observable<any> {
    return this.httpClient.get(this.apiBaseUrl + '/address/countryList');
  }

  // Service method to retrieve States
  public getStates(): Observable<any> {
    return this.httpClient.get(this.apiBaseUrl + '/address/states');
  }

  // Service method to save Investor details
  public saveApplication(investorDetails: InvestorDetails): Observable<any> {
    const httpOptions = {
      headers: this.setHeaders()
    };
    return this.httpClient.post(this.apiBaseUrl + '/investor/create', investorDetails, httpOptions);
  }

  // Service method to retrieve States
  public checkStateAndPostcode(state: string, postcode: string): Observable<any> {
    return this.httpClient.get(this.apiBaseUrl + `/address/isStateAndPostcodeValid?state=${state}&postcode=${postcode}`);
  }

  // Method to set Http Headers
  private setHeaders(): any {
    return new HttpHeaders({
      'Content-Type':  'application/json',
      'Access-Control-Allow-Origin': 'http://localhost:4200'
    });
  }
}