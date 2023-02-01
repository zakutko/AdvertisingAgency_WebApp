import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Advertisement } from 'src/app/models/advertisement';
import { Username } from 'src/app/models/username';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-more-information',
  templateUrl: './more-information.component.html',
  styleUrls: ['./more-information.component.scss'],
})
export class MoreInformationComponent implements OnInit {
  @Input() advertisement!: Advertisement;
  resultUsername!: Username;

  constructor(
    public activeModal: NgbActiveModal,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.authService
      .getUsername(this.advertisement.userId)
      .subscribe((result) => {
        this.resultUsername = result;
      });
  }
}
