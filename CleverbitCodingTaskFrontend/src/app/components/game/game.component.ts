import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpService } from '../../services/Http/http.service';
import * as $ from 'jquery';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  generatedNumber:any;
  expireTime:any;
  gameName: any;

  constructor(private httpService:HttpService) { 

    this.expireTime = "2021-05-25 00:05:00.0000000";
  }

  ngOnInit(): void {

    //check here if the user logged to be implemented


    //get the active game here
    this.httpService.Get(environment.GetActiveMatch,null).subscribe({
      next: data => {
        if(data.status==1)
        {
          this.gameName = data.activeMatch.matchName;
          this.expireTime = data.activeMatch.expireDate;
        }
        else
        {
          //display error
        }

        
        
      },
      error: error => {
       
      },
      complete: ()=> {     
        
       }
      });
  }

  SubmitNumber() {

    this.httpService.PostWithModel(environment.SaveUserRandomNumber,{
      "matchId":"1",
      "userName":"User1",
      "generatedNumber":this.generatedNumber
    }).subscribe({
      next: data => {
       
        if(data.status==1)
        {

        }
        else
        {
          //display error
        }
        
      },
      error: error => {
       
      },
      complete: ()=> {     
        
       }
      });


  }

  GenerateNumber()
  {
      this.httpService.Get(environment.GetRandomNumber+"?max=100",null).subscribe({
        next: data => {
           debugger;         

          this.generatedNumber = data;
          $('#result').show();
          
        },
        error: error => {
         
        },
        complete: ()=> {     
          
         }
        });
  }


}
