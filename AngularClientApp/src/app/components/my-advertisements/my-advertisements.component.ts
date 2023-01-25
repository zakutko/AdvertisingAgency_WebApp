import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Advertisement } from 'src/app/models/advertisement';
import { AdvertisementsService } from 'src/app/services/advertisements.service';

@Component({
  selector: 'my-advertisements',
  templateUrl: './my-advertisements.component.html',
  styleUrls: ['./my-advertisements.component.scss']
})
export class MyAdvertisementsComponent implements OnInit {
  advertisementsByUserId!: Advertisement[];
  selectedSidebarMenu: string = "Released";

  jwtHelper = new JwtHelperService();

  constructor(private advertisementsService: AdvertisementsService) { }

  ngOnInit(): void {
    let token = localStorage.getItem('token');
    if (token != null){
      let decodedToken = this.jwtHelper.decodeToken(token);
      this.advertisementsService.getAllBannersByUserId(decodedToken.nameid)
        .subscribe(result => {
          this.advertisementsByUserId = result;
        })
    }
  }
}