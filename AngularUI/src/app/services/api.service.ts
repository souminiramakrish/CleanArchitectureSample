import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class ApiService {
  constructor(private http: HttpClient) {}

  get<T>(url: string, params?: Record<string, string | number>): Observable<T> {
    let httpParams = new HttpParams();
    if (params) {
      Object.keys(params).forEach((k) => {
        httpParams = httpParams.set(k, String(params[k]));
      });
    }
    return this.http.get<T>(this.buildUrl(url), { params: httpParams }).pipe(catchError(this.handleError));
  }

  post<T>(url: string, body: any): Observable<T> {
    return this.http.post<T>(this.buildUrl(url), body).pipe(catchError(this.handleError));
  }

  put<T>(url: string, body: any): Observable<T> {
    return this.http.put<T>(this.buildUrl(url), body).pipe(catchError(this.handleError));
  }

  delete<T>(url: string): Observable<T> {
    return this.http.delete<T>(this.buildUrl(url)).pipe(catchError(this.handleError));
  }

  private buildUrl(url: string): string {
    if (/^https?:\/\//i.test(url)) {
      return url;
    }

    const base = environment.apiUrl.replace(/\/$/, '');
    const path = url.replace(/^\//, '');
    return `${base}/${path}`;
  }

  private handleError(error: any) {
    console.error('ApiService error', error);
    return throwError(() => error);
  }
}
