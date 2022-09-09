import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { LoaderService } from '../shared/loader/loader.service';
import { AlertsService } from '../shared/alerts/alerts.service';
@Injectable({
  providedIn: 'root',
})
export class HttpService {

  constructor(
    private http: HttpClient,
    private readonly loader: LoaderService,
    private readonly alerts: AlertsService) {
  }

  uploadWithLoader(url: string, formData: FormData, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }) {
    this.loader.showLoader();
    return this.http.post<{ path: string }>(
      url,
      formData, options
    ).pipe(finalize(() => {
      this.loader.hideLoader();
    }));
  }

  public get<T>(url: string, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {

    return this.http.get<T>(url, options);
  }

  public getWithLoader<T>(url: string, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    this.loader.showLoader();

    return this.http.get<T>(url, options)
      .pipe(finalize(() => {
        this.loader.hideLoader();
      }));
  }

  public post<T>(url: string, body: any | null, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    return this.http.post<T>(url, body, options);
  }

  public postWithLoader<T>(url: string, body: any | null, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    this.loader.showLoader();

    return this.http.post<T>(url, body, options)
      .pipe(finalize(() => {
        this.loader.hideLoader();
      }));
  }

  public put<T>(url: string, body: any | null, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    return this.http.put<T>(url, body, options);
  }

  public putWithLoader<T>(url: string, body: any | null, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    this.loader.showLoader();

    return this.http.put<T>(url, body, options)
      .pipe(finalize(() => {
        this.loader.hideLoader();
      }));
  }

  public patch<T>(url: string, body: any | null, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    return this.http.patch<T>(url, body, options);
  }

  public patchWithLoader<T>(url: string, body: any | null, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    this.loader.showLoader();

    return this.http.patch<T>(url, body, options)
      .pipe(finalize(() => {
        this.loader.hideLoader();
      }));


  }
  public deleteWithLoader<T>(url: string, options?: {
    headers?: HttpHeaders | {
      [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
      [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
  }): Observable<T> {
    this.loader.showLoader();

    return this.http.delete<T>(url, options)
      .pipe(finalize(() => {
        this.loader.hideLoader();
      }));
  }
}