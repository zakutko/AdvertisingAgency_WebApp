import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AddAdvertisementCredentials } from '../../credentials/add-advertisement-credentials';
import { AdvertisementsService } from '../../services/advertisements.service';
import { Storage, ref, uploadBytesResumable, getDownloadURL } from '@angular/fire/storage';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'add-advertisement',
  templateUrl: './add-advertisement.component.html',
  styleUrls: ['./add-advertisement.component.scss']
})
export class AddAdvertisementComponent implements OnInit {
[x: string]: any;
  resultMessage!: string;
  file!: any;
  imageUrl: string | null = null;
  progressPercent = 0;

  jwtHelper = new JwtHelperService();

  form = new FormGroup({
    title: new FormControl(null, [
      Validators.required
    ]),
    subtitle: new FormControl(null, [
      Validators.required
    ]),
    description: new FormControl(null, [
      Validators.required
    ]),
    linkToBrowserPage: new FormControl(null, [
      Validators.required
    ]),
  });

  constructor(private advertisementService: AdvertisementsService, private storage: Storage, private router: Router) { }

  get title() {
    return this.form.get('title');
  }

  get subtitle() {
    return this.form.get('subtitle');
  }

  get description() {
    return this.form.get('description');
  }

  get linkToBrowserPage() {
    return this.form.get('linkToBrowserPage');
  }

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
        })
      }
    );
  }

  addAdvertisement(credentials: AddAdvertisementCredentials) {
    if (this.imageUrl != null) {
      credentials.imageUrl = this.imageUrl;
      let token = localStorage.getItem('token');
      if (token != null){
        let decodedToken = this.jwtHelper.decodeToken(token);
        credentials.userId = decodedToken.nameid;
      }
      this.advertisementService.addBanner(credentials)
        .subscribe(result => {
          this.resultMessage = result;
          this.router.navigate(['my-advertisements']);
        });
    }
  }
}