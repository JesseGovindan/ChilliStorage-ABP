import { AuthService, ConfigStateService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsignmentDocumentService } from '../services/consignment-document.service';
import { UploadConsignmentDocument } from '../models/consignment-document.model';
import { SupplierService } from '../services/supplier.service';
import { Supplier } from '../models/supplier.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  uploadForm: FormGroup;
  isTenant = this.config.getOne('currentUser')?.tenantId ? true : false;
  fileBuffer: Promise<string>;
  suppliers: Supplier[] = [];
  formReady: boolean = false;

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private config: ConfigStateService,
    private consignmentDocumentService: ConsignmentDocumentService,
    private supplierService: SupplierService
  ) {
    this.uploadForm = this.fb.group({
      consignmentNumber: ['', Validators.required],
      supplierId: ['', Validators.required],
    });
  }
  ngOnInit(): void {
    this.supplierService.getSupplier$().subscribe({
      next: response => {
        this.suppliers = response;
        this.formReady = true;
      },
      error: () => {},
    });
  }

  login() {
    this.authService.navigateToLogin();
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.fileBuffer = new Promise<string>(resolve => {
        const reader = new FileReader();
        reader.onloadend = () => {
          resolve(this.arrayBufferToBase64(reader.result as ArrayBuffer));
        };
        reader.readAsArrayBuffer(file);
      });
    }
  }

  arrayBufferToBase64(buffer: ArrayBuffer): string {
    let binary = '';
    const bytes = new Uint8Array(buffer);
    const len = bytes.byteLength;
    for (let i = 0; i < len; i++) {
      binary += String.fromCharCode(bytes[i]);
    }
    return btoa(binary);
  }

  async onSubmit() {
    if (!this.uploadForm.valid) {
      return;
    }

    const request: UploadConsignmentDocument = {
      consignmentNumber: this.uploadForm.value.consignmentNumber,
      document: await this.fileBuffer,
      supplierId: this.uploadForm.value.supplierId,
    };
    console.log(request);
    this.consignmentDocumentService.uploadConsignmentDocument$(request).subscribe({
      next: () => {
        alert('document has been uploaded!');
      },
      error: () => {
        alert('failed to upload document!');
      },
    });
  }
}
