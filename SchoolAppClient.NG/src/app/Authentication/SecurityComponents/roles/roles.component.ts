import { Component, inject } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { AuthService } from '../../SecurityModels/auth.service';
import { AppRole } from '../../SecurityModels/auth-response';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.css'
})
export class RolesComponent {

  public roles: AppRole[] = [];

  model: AppRole = new AppRole();
  errorMessage!: string|null;
  state: string = 'list';

  private service = inject(AuthService);

  public pageSettings: PageSettingsModel = { pageSize: 5 };

  ngOnInit() {
    this.LoadData();
  }

  editRole(edit: AppRole) {
    this.model = edit;
    this.state = 'entry';

  }
  createNew() {
    this.state = 'entry';
    this.model = new AppRole();
  }
  cancel() {
    this.state = 'list';
    this.model = new AppRole();
  }
  deleteRole(id: string) {

    this.service.roleDelete(id).subscribe((response: any) => {
      console.log('Ok:' + JSON.stringify(response));
      this.LoadData();
    },
      (response:any) => {
        alert(response.error);
        this.errorMessage = response.error;
        console.log('Observable emitted an error:' + JSON.stringify(response));

      });



  }
  clearMessage() {
    this.errorMessage = null;
  }
  submitData(event: Event) {
    event.preventDefault();

    this.service.roleEntry(this.model).subscribe((response: any) => {
      this.LoadData();
    },
      (error) => {

        console.log('Observable emitted an error:' + JSON.stringify(error));

      });



  }
  LoadData() {
    this.state = 'list';
    this.service.roles().subscribe((response: AppRole[]) => {
      this.roles = response;
      //console.log(response);
    },
      (error) => {
        console.log('Observable emitted an error:' + error);

      });
  }



}
