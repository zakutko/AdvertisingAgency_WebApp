import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UpdateAdvertisementCredentials } from 'src/app/credentials/update-advertisement-credentials';
import { Advertisement } from 'src/app/models/advertisement';
import { Storage, ref, uploadBytesResumable, getDownloadURL } from '@angular/fire/storage';
import { AdvertisementsService } from 'src/app/services/advertisements.service';

@Component({
  selector: 'update-advertisement',
  templateUrl: './update-advertisement.component.html',
  styleUrls: ['./update-advertisement.component.scss']
})
export class UpdateAdvertisementComponent implements OnInit {
  @Input() advertisement!: Advertisement;

  file!: any;
  progressPercent = 0;
  imageUrl: string | null = null;
  resultMessage!: string;

  form = new FormGroup({
    title: new FormControl(''),
    subTitle: new FormControl(''),
    description: new FormControl(''),
    linkToBrowserPage: new FormControl('')
  });
  constructor(
    public activeModal: NgbActiveModal,
    private storage: Storage,
    private advertisementsService: AdvertisementsService
  ) { }

  ngOnInit(): void {

  }

  onChange(event: any) {
    this.file = event.target.files[0];
  }

  onUploadClick() {
    const storageRef = ref(this.storage, this.file.name);
    const uploadTask = uploadBytesResumable(storageRef, this.file);

    uploadTask.on('state_changed',
      (snapshot) => {
        const progress = Math.round((snapshot.bytesTransferred / snapshot.totalBytes) * 100);
        this.progressPercent = progress;
      },
      (error) => {
        console.log(error);
      },
      () => {
        getDownloadURL(uploadTask.snapshot.ref).then((dowloadURL) => {
          this.imageUrl = dowloadURL;
          console.log(this.imageUrl);
        })
      }
    );
  }

  updateAdvertisement(credentials: UpdateAdvertisementCredentials){
    if (credentials.title === '') {
      credentials.title = this.advertisement.title;
    }
    if (credentials.subTitle === '') {
      credentials.subTitle = this.advertisement.subTitle;
    }
    if (credentials.description === '') {
      credentials.description = this.advertisement.description;
    }
    if (credentials.linkToBrowserPage === '') {
      credentials.linkToBrowserPage = this.advertisement.linkToBrowserPage;
    }
    if (this.imageUrl != null) {
      credentials.photoUrl = this.imageUrl;
    }
    else {
      credentials.photoUrl = this.advertisement.photoUrl;
    }
    credentials.bannerId = this.advertisement.bannerId;
    this.advertisementsService.updateBanner(credentials)
      .subscribe(result => {
        this.resultMessage = result.message;
      });
  }

  reloadPage(){
    location.reload();
  }
}