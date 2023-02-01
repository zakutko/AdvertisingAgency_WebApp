import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Advertisement } from '../../models/advertisement';
import { AdvertisementsService } from '../../services/advertisements.service';
import { MoreInformationComponent } from '../more-information/more-information.component';

@Component({
  selector: 'advertisements',
  templateUrl: './advertisements.component.html',
  styleUrls: ['./advertisements.component.scss'],
})
export class AdvertisementsComponent implements OnInit {
  advertisements!: Advertisement[];

  constructor(
    private advertisementsService: AdvertisementsService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.advertisementsService
      .getAllBanners('get all banners')
      .subscribe((result) => {
        this.advertisements = result;
      });
    setInterval(() => {
      this.advertisementsService
        .getAllBanners('get all banners')
        .subscribe((result) => {
          this.advertisements = result;
        });
    }, 3000);
  }

  open(advertisement: Advertisement) {
    const modalRef = this.modalService.open(MoreInformationComponent, {
      size: 'lg',
      backdrop: 'static',
      centered: true,
    });
    modalRef.componentInstance.advertisement = advertisement;
  }
}
