import { AuthService, ConfigStateService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  uploadForm: FormGroup;
  isTenant = this.config.getOne('currentUser')?.tenantId ? true : false;

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private config: ConfigStateService,
  ) {
    this.uploadForm = this.fb.group({
      consignmentNumber: ['', Validators.required],
      supplierName: ['', Validators.required],
      document: [null, Validators.required]
    });
  }

  login() {
    this.authService.navigateToLogin();
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.uploadForm.patchValue({
        document: file
      });
    }
  }

  onSubmit() {
    if (this.uploadForm.valid) {
      const formData = new FormData();
      formData.append('consignmentNumber', this.uploadForm.get('consignmentNumber')?.value);
      formData.append('supplierName', this.uploadForm.get('supplierName')?.value);
      formData.append('document', this.uploadForm.get('document')?.value);

      // Handle form submission, e.g., send formData to the server
      console.log('Form submitted', formData);
    }
  }
}
