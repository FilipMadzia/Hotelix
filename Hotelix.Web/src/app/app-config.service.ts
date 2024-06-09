import { Injectable } from '@angular/core';
import { Config } from './models/config';
import * as data from '../assets/config.json';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
  config: Config = data;

  get apiBaseUrl(): string {
    return this.config.apiBaseUrl;
  }

  get coverImagesBaseUrl(): string {
    return this.config.coverImagesBaseUrl;
  }
}
