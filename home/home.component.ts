import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { inputReceived } from '../models/inputReceived';
import { Country } from '../models/Country';
import { outGiven } from '../models/outGiven';
import { PenaltyserviceService } from '../Service/penaltyservice.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
    myForm: FormGroup;
    input: inputReceived;
    countryList: Country[];
    formOutput: outGiven;

    constructor(private fb: FormBuilder, private PenaltyService: PenaltyserviceService) { }

    ngOnInit(): void {
        this.myForm = this.fb.group({
            startDate: new FormControl('', [Validators.required]),
            returnDate: ['', [Validators.required]],
            Country: new FormControl('Please Select Country', [Validators.required])

        });
      

        this.PenaltyService.GetCountries().pipe(map((data: Country[]) => {
            if (data != null && data != undefined) {
                this.countryList = data;
                console.log(data)
                console.log(this.countryList)
            }
        })).subscribe();
        console.log(this.countryList);
    }

    onSubmit() {
        console.log('pressed')
        
        this.input = {
            startDate: this.myForm.get('startDate').value,
            returnDate: this.myForm.get('returnDate').value,
            id: (this.myForm.get('Country').value).countryID
        }
       
        console.log(this.input)
        this.PenaltyService.GetPenalty(this.input).pipe(map((data: outGiven) => {
            if (data != null && data != undefined) {
                this.formOutput = data;
            }
        })).subscribe();

        this.myForm.patchValue({
            startDate: '',
            returnDate: '',
            Country: 'Please Select Country'
        })
    }
}
