import { Component, OnInit } from '@angular/core';
import { Governorate } from 'src/Models/Governorate.model';
import { GovernService } from 'src/Services/govern.service';
import { OrderService } from 'src/Services/order.service';
declare var $: any;

@Component({
  selector: 'app-governs',
  templateUrl: './governs.component.html',
  styleUrls: ['./governs.component.css']
})
export class GovernsComponent implements OnInit {

  constructor(private serv: GovernService) { }

  Govs: Governorate[] = [];
  ngOnInit(): void {

    // $("td").on('click', function () {
    //   $("ul").not($(this).siblings("ul")).slideUp();
    //   $(this).siblings("ul").slideToggle("1800");
    // })
    this.serv.getAllGoverns().subscribe(
      response => {
        this.Govs = response;
      },
      err => {
        console.log(err)
      }
    )
  }

}
