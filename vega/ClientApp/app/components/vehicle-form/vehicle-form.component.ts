import { MakerService } from './../../services/maker.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  makers: Array<any>;
  makerNames: Array<string>;
  models: Array<string>; 
  selectedMaker: string;

  constructor(private makerService: MakerService) { }

  ngOnInit() {
    this.models = ['Choose a Model'];
    this.makerService.getMakers().subscribe(makers => {
      this.makers = makers;
      this.makerNames = this.makers.map(maker => maker.name);
      this.makerNames.unshift('Choose a Maker');
    });
  }

  onChange(){

  }

}
