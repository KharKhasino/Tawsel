import { KeyValuePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GovernService } from 'src/Services/govern.service';
import { OrderService } from 'src/Services/order.service';
import { GovernsComponent } from '../governs/governs.component';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {

  constructor(private route: ActivatedRoute, private serv: GovernService) { }

  resp: any;
  cities = {};
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      param => {
        const id = param.get('id');

        if (id) {
          this.serv.getCities(id).subscribe(
            response => {
              this.resp = response;
              this.cities = this.resp.cities
            },
            err => console.log(err)
          )
        }
      }
    )
  }

  passId(_id:number){
    this.serv.passParam(_id);
  }
}
