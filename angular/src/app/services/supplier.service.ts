import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Supplier } from '../models/supplier.model';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(
    private http: HttpClient
  ) {}

  getSupplier$() {
    const url = `${environment.apis.default.url}/api/app/supplier/suppliers`;
    return this.http.get<Supplier[]>(url );
  }
}
