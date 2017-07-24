import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class MakerService {

  constructor(private http: Http) { }

  getMakers(){
    return this.http.get('/api/maker').map(
      res => res.json()
    );
  }
}
