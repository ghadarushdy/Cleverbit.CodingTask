import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders } from "@angular/common/http";
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
// import { timeStamp } from 'console';

@Injectable({
  providedIn: 'root'
})

export class HttpService {
  
  userData= new BehaviorSubject(null);
  applicationData= new BehaviorSubject(null); 
 
  headers:any = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',  
      'Accept': 'application/json', 
      'Access-Control-Allow-Origin': '*' ,
      'Access-Control-Allow-Headers':'Content-Type',
      'channelName':'Portal',
      observe: 'response'    
    })
  };

  result:any
  
  constructor(private httpClient:HttpClient) { 
  
   }

  Get(url:string, headers:any):Observable<any>
  {
    if(headers !=null)
    {
      return this.httpClient.get<any>(url,headers);
    }
    else
    return this.httpClient.get<any>(url,this.headers);

  }

  

  PostWithParams(url:string,params:any): Observable<any>
  {
    return this.httpClient.post(url,this.headers,{params:params});   
  }

  PostWithModel(url:string,data:any):Observable<any>
  {
    //debugger;
    return this.httpClient.post(url, data,this.headers); 
  }

  public getCookie(name: string) {
    let ca: Array<string> = document.cookie.split(';');
    let caLen: number = ca.length;
    let cookieName = `${name}=`;
    let c: string;

    for (let i: number = 0; i < caLen; i += 1) {
        c = ca[i].replace(/^\s+/g, '');
        if (c.indexOf(cookieName) == 0) {
            return c.substring(cookieName.length, c.length);
        }
    }
    return '';
}

}
