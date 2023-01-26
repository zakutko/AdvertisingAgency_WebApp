import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RejectCredentials } from 'src/app/credentials/reject-credentials';
import { Advertisement } from 'src/app/models/advertisement';
import { AdvertisementsService } from 'src/app/services/advertisements.service';

@Component({
  selector: 'editor-panel',
  templateUrl: './editor-panel.component.html',
  styleUrls: ['./editor-panel.component.scss']
})
export class EditorPanelComponent implements OnInit {
  selectedSideBarMenu: string = 'Advertisements';
  advertisementsList!: Advertisement[];

  form = new FormGroup({
    comment: new FormControl('', [
      Validators.required
    ])
  });

  constructor(private advertisementsService: AdvertisementsService) { }

  get comment() {
    return this.form.get('comment');
  }

  ngOnInit(): void {
    this.advertisementsService.getAllBannersWhereStatusInQueueToCheck()
      .subscribe(result => {
        this.advertisementsList = result;
      });
  }

  onAcceptClick(bannerId: string) {
    this.advertisementsService.setStatusCheckSuccessfull(bannerId)
      .subscribe(result => {
        console.log(result);
        location.reload();
      })
  }

  onRejectClick(bannerId: string, credentials: RejectCredentials) {
    credentials.bannerId = bannerId;
    this.advertisementsService.setStatusCheckNotSuccessfull(credentials)
      .subscribe(result => {
        console.log(result);
        location.reload();
      })
  }
}