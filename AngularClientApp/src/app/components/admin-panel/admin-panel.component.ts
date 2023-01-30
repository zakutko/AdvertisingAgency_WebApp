import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DeleteUserCredentials } from '../../credentials/delete-user-credentials';
import { Advertisement } from '../../models/advertisement';
import { RoleRequest } from '../../models/role-request';
import { UserInfo } from '../../models/user-info';
import { AdvertisementsService } from '../../services/advertisements.service';
import { AuthService } from '../../services/auth.service';
import { UpdateAdvertisementComponent } from '../update-advertisement/update-advertisement.component';

@Component({
  selector: 'admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {
  selectedSideBarMenu!: string;
  usersInfo!: UserInfo[];
  roleRequests!: RoleRequest[];
  advertisementsList!: Advertisement[];

  constructor(
    private authService: AuthService, 
    private advertisementsService: AdvertisementsService,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    let token = localStorage.getItem('token');
    if(token != null){
      this.authService.getAllUsers(token)
        .subscribe(result => {
          this.usersInfo = result;
        })
    }
    this.selectedSideBarMenu = "Users";
  }

  getAllUsers() {
    let token = localStorage.getItem('token');
    if(token != null){
      this.authService.getAllUsers(token)
        .subscribe(result => {
          this.usersInfo = result;
        })
    };
  }

  getAllRoleRequests() {
    let token = localStorage.getItem('token');
    if(token != null){
      this.authService.getAllRoleRequests(token)
        .subscribe(result => {
          this.roleRequests = result;
        });
    };
  }

  getAllAdvertisements() {
    let token = localStorage.getItem('token');
    if(token != null){
      this.advertisementsService.getAllBanners("get all advertisements")
        .subscribe(result => {
          this.advertisementsList = result;
        })
    }
  }

  onDeleteButtonClick(username: string, email: string) {
    let credentials: DeleteUserCredentials = {username, email};
    this.authService.deleteUser(credentials)
      .subscribe(result => {
        console.log(result);
      });
  }

  open(advertisement: Advertisement) {
    const modalRef = this.modalService.open(UpdateAdvertisementComponent);
    modalRef.componentInstance.advertisement = advertisement;
  }

  onAcceptClick(userId: string) {
    this.authService.acceptRoleRequest(userId)
      .subscribe(result => {
        console.log(result);
        this.getAllRoleRequests();
      })
  }

  onRejectClick(userId: string) {
    this.authService.rejectRoleRequest(userId)
      .subscribe(result => {
        console.log(result);
        this.getAllRoleRequests();
      })
  }

  onDeleteAdvClick(userId: string, bannerId: string) {
    this.advertisementsService.deleteBannerByUserIdAndBannerId(userId, bannerId)
      .subscribe(result => {
        console.log(result);
        this.getAllAdvertisements();
      });
  }
}