import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReleasePlannedCredentials } from 'src/app/credentials/release-planned-credentials';
import { Advertisement } from 'src/app/models/advertisement';
import { AdvertisementsService } from 'src/app/services/advertisements.service';

@Component({
  selector: 'approver-panel',
  templateUrl: './approver-panel.component.html',
  styleUrls: ['./approver-panel.component.scss']
})
export class ApproverPanelComponent implements OnInit {
  selectedSideBarMenu: string = 'Advertisements';
  advertisementsList!: Advertisement[];

  form = new FormGroup({
    releaseDate: new FormControl(null, [
      Validators.required
    ])
  });

  constructor(private advertisementsService: AdvertisementsService) { }

  get releaseDate() {
    return this.form.get("releaseDate");
  }

  ngOnInit(): void {
    this.advertisementsService.getAllBannersWhereStatusCheckSuccessful()
      .subscribe(result => {
        this.advertisementsList = result;
      });
  }

  onReleaseClick(bannerId: string){
    this.advertisementsService.setStatusReleased(bannerId)
      .subscribe(result => {
        console.log(result);
        location.reload();
      })
  }

  onPlanReleaseClick(bannerId: string, credentials: ReleasePlannedCredentials){
    credentials.bannerId = bannerId;
    this.advertisementsService.setStatusReleasePlanned(credentials)
      .subscribe(result => {
        console.log(result);
        location.reload();
      })
  }   
}
