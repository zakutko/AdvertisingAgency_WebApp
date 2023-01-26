import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  selectedSidebarMenu: string = "Created";

  jwtHelper = new JwtHelperService();

  constructor(private advertisementsService: AdvertisementsService, private router: Router) { }

  ngOnInit(): void {
    this.getAllBannersByUserId();
  }

  onDeleteClick(userId: string, bannerId: string){
    this.advertisementsService.deleteBannerByUserIdAndBannerId(userId, bannerId)
      .subscribe(result => {
        this.getAllBannersByUserId();
      });
  }

  addToQueueToCheck(bannerId: string) {
    this.advertisementsService.addToQueueToCheck(bannerId)
      .subscribe(result => {
        this.getAllBannersByUserId();
      });
  }

  getAllBannersByUserId() {
    let token = localStorage.getItem('token');
    if (token != null){
      let decodedToken = this.jwtHelper.decodeToken(token);
      this.advertisementsService.getAllBannersByUserId(decodedToken.nameid)
        .subscribe(result => {
          this.advertisementsByUserId = result;
        });
    };
  }
}