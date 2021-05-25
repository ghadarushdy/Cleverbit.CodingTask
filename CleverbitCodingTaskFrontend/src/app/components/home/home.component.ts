import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpService } from '../../services/Http/http.service';
import {matchWinners} from '../../interfaces/matchWinners';
import { Router } from '@angular/router';
import * as $ from 'jquery';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  matchList:any;  

  constructor(private httpService:HttpService,private router: Router) { 

    this.httpService.Get(environment.GetAllMatchesWinners,null).subscribe({
      next: data => {
         debugger;
       
        if(data.status==1)
        {
           this.matchList = data.matchesWinners as matchWinners;
        }
        else
        {
          //display error msg for the user
        }
      },
      error: error => {
       
      },
      complete: ()=> {     
        
       }
      });

  }

  ngOnInit(): void {
  }
  

  Login()
  {
    this.router.navigate(['playNow']); 
  }
}
