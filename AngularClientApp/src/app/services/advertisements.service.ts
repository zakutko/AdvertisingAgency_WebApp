import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddAdvertisementCredentials } from '../credentials/add-advertisement-credentials';
import { RejectCredentials } from '../credentials/reject-credentials';
import { ReleasePlannedCredentials } from '../credentials/release-planned-credentials';
import { UpdateAdvertisementCredentials } from '../credentials/update-advertisement-credentials';
import { Advertisement } from '../models/advertisement';
import { UpdateAdvertisementResponse } from '../models/update-advertisement-reponse';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementsService {
  baseUrl = "https://localhost:56782/api";

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(private http: HttpClient) { }

  getAllBanners(message: string){
    return this.http.get<Advertisement[]>(this.baseUrl + `/Advertisements/getAllBanners?message=${message}`);
  }

  getAllBannersByUserId(userId: string) {
    return this.http.get<Advertisement[]>(this.baseUrl + `/Advertisements/getAllBannersByUserId?userId=${userId}`);
  }

  addBanner(credentials: AddAdvertisementCredentials){
    return this.http.post<string>(this.baseUrl + '/Advertisements/addBanner', credentials, this.httpOptions);
  }

  deleteBannerByUserIdAndBannerId(userId: string, bannerId: string) {
    return this.http.delete(this.baseUrl + `/Advertisements/deleteBanner?userId=${userId}&&bannerId=${bannerId}`);
  }

  addToQueueToCheck(bannerId: string){
    return this.http.put(this.baseUrl + '/Advertisements/addToQueueToCheck', { 'BannerId': bannerId }, this.httpOptions);
  }

  getAllBannersWhereStatusInQueueToCheck() {
    return this.http.get<Advertisement[]>(this.baseUrl + '/Advertisements/getAllBannersWhereStatusInQueueToCheck');
  }

  setStatusCheckSuccessfull(bannerId: string) {
    return this.http.put(this.baseUrl + '/Advertisements/setStatusCheckSuccessfull', { 'BannerId': bannerId }, this.httpOptions);
  }

  setStatusCheckNotSuccessfull(credentials: RejectCredentials) {
    return this.http.put(this.baseUrl + '/Advertisements/setStatusCheckNotSuccessful', { 'BannerId': credentials.bannerId, 'Comment': credentials.comment }, this.httpOptions);
  }

  setStatusReleased(bannerId: string){
    return this.http.put(this.baseUrl + '/Advertisements/setStatusReleased', { 'BannerId': bannerId }, this.httpOptions);
  }

  setStatusReleasePlanned(credentials: ReleasePlannedCredentials) {
    return this.http.put(this.baseUrl + '/Advertisements/setStatusReleasePlanned', { 'BannerId': credentials.bannerId, 'ReleaseDate': credentials.releaseDate.toString() }, this.httpOptions);
  }

  getAllBannersWhereStatusCheckSuccessful() {
    return this.http.get<Advertisement[]>(this.baseUrl + '/Advertisements/getAllBannersWhereStatusCheckSuccessful');
  }

  updateBanner(credentials: UpdateAdvertisementCredentials){
    return this.http.put<UpdateAdvertisementResponse>(this.baseUrl + '/Advertisements/updateBanner', credentials, this.httpOptions);
  }
}