import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddAdvertisementCredentials } from '../credentials/add-advertisement-credentials';
import { Advertisement } from '../models/advertisement';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementsService {
  baseUrl = "https://localhost:62207/api";

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
}
