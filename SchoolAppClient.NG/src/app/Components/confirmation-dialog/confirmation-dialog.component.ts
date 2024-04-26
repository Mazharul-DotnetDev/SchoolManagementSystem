import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-confirmation-dialog',
  template: `
    <div>
      <h2>{{ title }}</h2>
      <p>{{ message }}</p>
     
    </div>
  `,
  styles: [`
    div {
      padding: 20px;
      border: 1px solid #ccc;
      border-radius: 4px;
      background-color: #fff;
    }
  `]
})
export class ConfirmationDialogComponent {
  @Input() title: string = 'Dialog';
  @Input() message: string = 'This is a custom dialog';

  close() {
    // Close dialog logic
  }
}
