import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { City } from 'src/Models/City.model';
import { GovernService } from 'src/Services/govern.service';

@Component({
  selector: 'app-form-city',
  templateUrl: './form-city.component.html',
  styleUrls: ['./form-city.component.css']
})
export class FormCityComponent implements OnInit {

  city: City = { name: '', price: '', govId:'' };
  GovId: any;
  addRecord: FormGroup;
  constructor(private route: ActivatedRoute, private myserv: GovernService, private nav: Router, private fb: FormBuilder) {
  }


  ngOnInit(): void {
    this.GovId = this.route.snapshot.paramMap.get('id')
    // this.emptyForm();

  }

  onSubmit() {
    this.myserv.AddCity (this.addRecord.value).subscribe(
      response => {
        console.log(response);
        this.nav.navigate(['/governs/' + this.GovId]);

      },
      err=>console.log(err)
    )
  }

  emptyForm() {
    this.addRecord = this.fb.group({
      id:[0],
      name:['', [Validators.required]],
      price:[0, [Validators.min(1)]],
      govId:[]
    })
  }

get registerFormControl():{[key:string]:AbstractControl}{
  return this.addRecord.controls;
}

  AddNew(name: any, price: any) {
    let item = { name, price, govId :this.GovId };
    if (item && price) {
      this.myserv.AddCity(item).subscribe(
        response=>{
          console.log(response)
          this.nav.navigate(['/governs/' + this.GovId]);
        }
      );
    } else {
      this.nav.navigate(['/governs/' + this.GovId + '/Add']);
    }
  }
}
