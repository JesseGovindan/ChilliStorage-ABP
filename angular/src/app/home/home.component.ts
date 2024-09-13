import { AuthService, ConfigStateService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsignmentDocumentService } from '../services/consignment-document.service';
import { UploadConsignmentDocument } from '../models/consignment-document.model';
import { SupplierService } from '../services/supplier.service';
import { Supplier } from '../models/supplier.model';
import { ConsignmentDocumentSummary } from '../models/consignment-document-summary.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  uploadForm: FormGroup;
  filterForm: FormGroup;

  isTenant = this.config.getOne('currentUser')?.tenantId ? true : false;
  fileBuffer: Promise<string>;
  suppliers: Supplier[] = [];
  formReady: boolean = false;

  toasts: { title: string; message: string }[] = [];

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  consignmentDocuments: ConsignmentDocumentSummary[] = [];
  filteredConsignmentDocuments: ConsignmentDocumentSummary[] = [];

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

    this.filterForm = this.fb.group({
      filterString: [''],
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

    this.getConsignmentDocuments();
  }

  private getConsignmentDocuments() {
    this.consignmentDocumentService.getConsignmentDocuments$().subscribe({
      next: response => {
        this.consignmentDocuments = response;
        this.filteredConsignmentDocuments = response;
        this.formReady = true;
      },
      error: () => {},
    });
  }

  onFilterSupplier(): void {
    const filterString = this.filterForm.value.filterString;
    if (filterString) {
      this.filteredConsignmentDocuments = this.consignmentDocuments.filter(document =>
        document.consignmentNumber.includes(filterString)
      );
      return;
    }
    this.filteredConsignmentDocuments = this.consignmentDocuments;
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

  download(consignmentNumber: string): void {
    this.consignmentDocumentService
      .downloadConsignmentDocument$(consignmentNumber)
      .subscribe(response => {
        this.decodeAndDownloadPdf(response.file, consignmentNumber + '.pdf');
      });
  }

  decodeAndDownloadPdf(base64String: string, fileName: string) {
    const link = document.createElement('a');
    const binaryData = this.base64ToArrayBuffer(base64String);
    const blob = new Blob([binaryData], { type: 'application/pdf' });
    const url = window.URL.createObjectURL(blob);

    link.href = url;
    link.download = fileName;
    link.click();

    // Clean up URL
    window.URL.revokeObjectURL(url);
  }

  base64ToArrayBuffer(base64: string) {
    const binaryString = window.atob(base64);
    const len = binaryString.length;
    const bytes = new Uint8Array(len);

    for (let i = 0; i < len; i++) {
      bytes[i] = binaryString.charCodeAt(i);
    }

    return bytes.buffer;
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

    this.consignmentDocumentService.uploadConsignmentDocument$(request).subscribe({
      next: () => {
        alert('Document uploaded successfully!');

        this.getConsignmentDocuments();
      },
      error: () => {
        alert('Failed to upload document!');
      },
    });
  }

  showToast(title: string, message: string) {
    this.toasts.push({ title, message });
    setTimeout(() => this.removeToast(this.toasts[0]), 5000); // Remove toast after 5 seconds
  }

  removeToast(toast: { title: string; message: string }) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}
