import { Component, OnInit } from '@angular/core';
import { Standard } from '../../../Models/standard';
import { StandardService } from '../../../Services/standard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-standard-create',
  templateUrl: './standard-create.component.html',
  styleUrl: './standard-create.component.css'
})
export class StandardCreateComponent implements OnInit {

  public model: Standard = new Standard;


  constructor(private standardService: StandardService, private router: Router) { }

  ngOnInit(): void {

  }

  createStandard(): void {
    this.standardService.createStandard(this.model).subscribe(() => {
      // After successful creation, navigate back to fee type list
      this.router.navigate(['/standards']);
    });
  }

}
