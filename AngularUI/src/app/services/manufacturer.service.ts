import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

export interface Manufacturer {
  id?: number;
  name: string;
}
export interface PagedResult<T> {
  data: T[];
  pageNumber: number;
  pageSize: number;
  totalRecords: number;
  totalPages: number;
}

@Injectable({ providedIn: 'root' })
export class ManufacturerService {
  private readonly base = '/manufacturer';

  constructor(private api: ApiService) {}

  getManufacturers(params?: Record<string, string | number>): Observable<PagedResult<Manufacturer>> {
    let url = `${this.base}/getall`;
    return this.api.get<PagedResult<Manufacturer>>(url, params);
  }

  getManufacturer(id: number): Observable<Manufacturer> {
    return this.api.get<Manufacturer>(`${this.base}/${id}`);
  }

  createManufacturer(payload: Partial<Manufacturer>): Observable<Manufacturer> {
    return this.api.post<Manufacturer>(this.base, payload);
  }

  updateManufacturer(id: number, payload: Partial<Manufacturer>): Observable<Manufacturer> {
    return this.api.put<Manufacturer>(`${this.base}/${id}`, payload);
  }

  deleteManufacturer(id: number): Observable<void> {
    return this.api.delete<void>(`${this.base}/${id}`);
  }
}
