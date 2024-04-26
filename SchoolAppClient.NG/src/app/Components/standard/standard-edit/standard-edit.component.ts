import { Component, OnInit } from '@angular/core';
import { Standard } from '../../../Models/standard';
import { ActivatedRoute, Router } from '@angular/router';
import { StandardService } from '../../../Services/standard.service';

@Component({
  selector: 'app-standard-edit',
  templateUrl: './standard-edit.component.html',
  styleUrl: './standard-edit.component.css'
})
export class StandardEditComponent implements OnInit {
  public model: Standard = new Standard();
  public standardId!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private standardServices: StandardService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.standardId = +params['id'];
      this.getStandardDetails(this.standardId);
    });
  }

  getStandardDetails(id: number): void {
    this.standardServices.getStandardById(id).subscribe(
      (data: Standard) => {
        this.model = data;
      },
      error => {
        console.error(error);
      }
    );
  }

  updateStandard(): void {
    this.standardServices.updateStandard(this.model).subscribe(
      () => {
        this.router.navigate(['/standards']);
      },
      error => {
        console.error(error);
      }
    );
  }
}
