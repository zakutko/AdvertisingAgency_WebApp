import { Component, OnInit } from '@angular/core';
import { AdvertisementsService } from './services/advertisements.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'AdvertisingAgency';

  constructor(private advertisementsService: AdvertisementsService) {}

  ngOnInit(): void {
    setInterval(() => {
      const now = new Date();
      this.advertisementsService
        .checkPlannedRelease(now)
        .subscribe((result) => {
          console.log(result);
        });
    }, 10000);
  }
}
