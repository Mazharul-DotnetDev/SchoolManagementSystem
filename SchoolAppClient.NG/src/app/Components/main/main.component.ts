import { Component } from '@angular/core';
import { CommonServices } from '../../Services/common.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent {

  isSidebarVisible = true;
  constructor(private sidebarService: CommonServices) { }


  ngOnInit() {
    this.sidebarService.sidebarVisibility$.subscribe((isVisible) => {
      console.log(isVisible)
      this.isSidebarVisible = isVisible;
    });
  }
}
