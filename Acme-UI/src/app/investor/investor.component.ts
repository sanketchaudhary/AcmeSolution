import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvestorService } from './investor.service';
import { Country } from './country';
import { InvestorDetails } from './investor-details';
import { Router } from '@angular/router';

@Component({
  selector: 'app-investor',
  templateUrl: './investor.component.html',
  styleUrls: ['./investor.component.css']
})
export class InvestorComponent implements OnInit {
  public investorFormGroup: FormGroup;
  public countryList: Country[] = [];
  public states: string[] = [];
  public countrySelectedIsAustralia: boolean = false;
  public investorDetails: InvestorDetails;
  public isStateAndPostcodeValid: boolean = true;

  constructor(
    private formBuilder: FormBuilder,
    private investorService: InvestorService,
    private router: Router
  ) { }

  // Get to access properties in template
  get postcode() { return this.investorFormGroup.get('postcode'); };
  get countryOfResidence() { return this.investorFormGroup.get('countryOfResidence'); };
  get fullName() { return this.investorFormGroup.get('fullName'); };
  get state() { return this.investorFormGroup.get('state'); };
  

  // Initialise Component
  public ngOnInit(): void {
    // Build Investor Form
    this.buildForm();

    // Get Country list
    this.getCountryList();
  }

  // Handler for Country selection change
  public onCountrySelect(): void {
    // Check if Country of residence is selected as Australia
    if (this.investorFormGroup.controls['countryOfResidence'].value === "1" || this.investorFormGroup.controls['countryOfResidence'].value === "6") {
      // Get States
      this.getStates();

      // Set validation on state and postcode field
      this.setStateAndPostcodeValidation();

      // Set Australia flag to true
      this.countrySelectedIsAustralia = true;
    } else {
      // Clear validation on State and postcode field
      this.clearStateAndPostcodeValidation();

      // Clear State and Postcode value
      this.investorFormGroup.controls['state'].setValue('');
      this.investorFormGroup.controls['postcode'].setValue('');

      // Set Australia flag to false
      this.countrySelectedIsAustralia = false;
    }
  }

  // Method to handle change event for State and Postcode
  public onStateAndPostcodeChange() {
    // Get State and Postcode value
    const state = this.investorFormGroup.controls['state'].value;
    const postcode = this.investorFormGroup.controls['postcode'].value;

    // Check if State and Postcode values are valid
    if (state && postcode) {
      // Call service method to check if State and postcode combination is valid
      this.investorService.checkStateAndPostcode(state, postcode).subscribe((response) => {
        if (response !== undefined) {
          this.isStateAndPostcodeValid = response;
        }
      }, (error) => {
        console.log(error);
      });
    }

  }

  // Method to save Investor application
  public submit() {
    if (this.investorFormGroup.valid) {
      // Copy the form values over the User object values
      const investorDetails = Object.assign({}, this.investorDetails, this.investorFormGroup.value);

      // Check if User object is not null or undefined
      if (investorDetails) {
        this.investorService.saveApplication(investorDetails).subscribe((response) => {

          if (response) {

          }
          // Redirect user to Success page
          this.router.navigate(['/success']);
        }, (error) => {
          console.log(error);
        });
      }
    }
  }

  // Method to build Investor Form group
  protected buildForm(): void {
    this.investorFormGroup = this.formBuilder.group({
        countryOfResidence: [null, [Validators.required]],
        state: [null, []],
        postcode: [],
        fullName: ['', [Validators.required, Validators.maxLength(120), Validators.pattern('[A-Za-z]{1,50}')]]
    });
  }

  // Get Country list from database
  public getCountryList(): void {
    // Get Country list
    this.investorService.getCountryList().subscribe((response) => {
      if(response) {
        this.countryList = response;
      }
    }, (error) => {
      console.log(error);
    });
  }

  // Method to retrieve states from database
  private getStates(): void {
    // Get States
    this.investorService.getStates().subscribe((response) => {
      if (response) {
        // Set states
        this.states = response;
      }
    }, (error) => {
      console.log(error);
    });
  }

  // Method to set Required validation on State and Postcode field
  private setStateAndPostcodeValidation(): void {
    // Add Required validation on State and Postcode field
    this.investorFormGroup.controls['state'].setValidators([Validators.required]);
    this.investorFormGroup.controls['state'].updateValueAndValidity();
    this.investorFormGroup.controls['postcode'].setValidators([Validators.required, Validators.maxLength(4)]);
    this.investorFormGroup.controls['postcode'].updateValueAndValidity();
  }

  // Method to clear Required validation on State and Postcode field
  private clearStateAndPostcodeValidation(): void {
    // Clear validation on State and postcode field
    this.investorFormGroup.controls['state'].clearValidators();
    this.investorFormGroup.controls['state'].updateValueAndValidity();
    this.investorFormGroup.controls['postcode'].clearValidators();
    this.investorFormGroup.controls['postcode'].updateValueAndValidity();
  }
}
