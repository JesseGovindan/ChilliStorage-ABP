import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UploadConsignmentDocument } from '../models/consignment-document.model';
import { environment } from 'src/environments/environment';
import { ConsignmentDocumentSummary } from '../models/consignemet-document-summary.model';

@Injectable({
  providedIn: 'root',
})
export class ConsignmentDocumentService {
  constructor(private http: HttpClient) {}

  uploadConsignmentDocument$(request: UploadConsignmentDocument) {
    const url = `${environment.apis.default.url}/api/app/document-consignment`;
    return this.http.post<void>(url, request);
  }

  getAllSupplierConsignmentDocuments$(supplierId: string) {
    const url = `${environment.apis.default.url}/api/app/document-consignment?supplierId=${supplierId}`;
    return this.http.get<ConsignmentDocumentSummary[]>(url);
  }
  getAllConsignmentDocuments$() {
    const url = `${environment.apis.default.url}/api/app/document-consignment`;
    return this.http.get<ConsignmentDocumentSummary[]>(url);
  }
}
