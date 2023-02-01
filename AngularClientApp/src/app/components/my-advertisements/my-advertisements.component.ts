import { Component, Input, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Advertisement } from 'src/app/models/advertisement';
import { AdvertisementsService } from 'src/app/services/advertisements.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UpdateAdvertisementComponent } from '../update-advertisement/update-advertisement.component';

@Component({
  selector: 'my-advertisements',
  templateUrl: './my-advertisements.component.html',
  styleUrls: ['./my-advertisements.component.scss'],
})
export class MyAdvertisementsComponent implements OnInit {
  advertisementsByUserId!: Advertisement[];
  selectedSidebarMenu: string = 'InQueueToCheck';

  jwtHelper = new JwtHelperService();

  constructor(
    private advertisementsService: AdvertisementsService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getAllBannersByUserId();
  }

  open(advertisement: Advertisement) {
    const modalRef = this.modalService.open(UpdateAdvertisementComponent);
    modalRef.componentInstance.advertisement = advertisement;
  }

  onDeleteClick(userId: string, bannerId: string) {
    this.advertisementsService
      .deleteBannerByUserIdAndBannerId(userId, bannerId)
      .subscribe((result) => {
        this.getAllBannersByUserId();
      });
  }

  addToQueueToCheck(bannerId: string) {
    this.advertisementsService
      .addToQueueToCheck(bannerId)
      .subscribe((result) => {
        this.getAllBannersByUserId();
      });
  }

  getAllBannersByUserId() {
    let token = localStorage.getItem('token');
    if (token != null) {
      let decodedToken = this.jwtHelper.decodeToken(token);
      this.advertisementsService
        .getAllBannersByUserId(decodedToken.nameid)
        .subscribe((result) => {
          this.advertisementsByUserId = result;
        });
    }
  }
}
