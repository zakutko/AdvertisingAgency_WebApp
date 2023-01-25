import { Component, OnInit } from '@angular/core';
import { Advertisement } from '../../models/advertisement';
import { AdvertisementsService } from '../../services/advertisements.service';

@Component({
  selector: 'advertisements',
  templateUrl: './advertisements.component.html',
  styleUrls: ['./advertisements.component.scss']
})
export class AdvertisementsComponent implements OnInit {
  advertisements!: Advertisement[];

  constructor(private advertisementsService: AdvertisementsService) { }

  ngOnInit(): void {
    this.advertisementsService.getAllBanners("get all banners")
      .subscribe(result => {
        this.advertisements = result;
      });
  }
}
