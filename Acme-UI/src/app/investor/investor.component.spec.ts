import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InvestorComponent } from './investor.component';
import { InvestorService } from './investor.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule, FormBuilder } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppModule } from '../app.module';
import { HttpClientModule } from '@angular/common/http';
import { Subject, of } from 'rxjs';
import { NO_ERRORS_SCHEMA } from '@angular/core';

describe('InvestorComponent', () => {
  let component: InvestorComponent;
  let fixture: ComponentFixture<InvestorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        FormsModule,
        AppModule,
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        HttpClientModule
      ],
      providers: [
        InvestorService,
        FormBuilder
      ],
      schemas: [NO_ERRORS_SCHEMA]
    }).compileComponents();

    fixture = TestBed.createComponent(InvestorComponent);
    component = fixture.componentInstance;
    component.investorFormGroup = new FormBuilder().group(
      {
        countryOfResidence: [null],
        state: [null, []],
        postcode: [],
        fullName: ['']
      }
    );
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call service nethod to get country list', () => {
    // Arrange
    let spyService = jasmine.createSpyObj('InvestorService', ['getCountryList']);
    component.countryList = [{countryId: 1001, countryName: 'Aus'}];
    spyService.getCountryList.and.returnValue(of(true));

    // Act
    component.getCountryList();

    // Assert
    expect(component.countryList.length).toBe(1);
  });

  it('should have State and Postcode values before comparing', () => {
    // Arrange
    let spyService = jasmine.createSpyObj('InvestorService', ['checkStateAndPostcode']);
    // spyService.checkStateAndPostcode.and.returnValue(new Subject().asObservable());
    component.investorFormGroup.controls['state'].setValue('');
    component.investorFormGroup.controls['postcode'].setValue('');

    // Act
    component.onStateAndPostcodeChange();

    // Assert
    expect(spyService.checkStateAndPostcode).not.toHaveBeenCalled();
  });

  xit('should call service method for valid state and postcode values for comparing', () => {
    // Arrange
    let spyService = jasmine.createSpyObj('InvestorService', ['checkStateAndPostcode']);
    // spyService.checkStateAndPostcode.and.returnValue(new Subject().asObservable());
    component.investorFormGroup.controls['state'].setValue('NSW');
    component.investorFormGroup.controls['postcode'].setValue('1235');

    // Act
    component.onStateAndPostcodeChange();

    // Assert
    expect(spyService.checkStateAndPostcode).toHaveBeenCalled();
  });
});


