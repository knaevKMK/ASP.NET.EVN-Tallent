import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-candidate-details',
  templateUrl: './candidate-details.component.html',
  styles: [
  ]
})
export class CandidateDetailsComponent implements OnInit {

  id: string="";
  user = new ClassUser;
  url: string;

  constructor(private activateRouter: ActivatedRoute,
    private router:Router,
    private activateRoute: ActivatedRoute,
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
    ) {

      this.url = baseUrl+"api/candidate"
      this.id = this.activateRoute.snapshot.params['id'];
}


ngOnInit(): void {
    this.id= this.activateRouter.snapshot.params['id'];
    console.log(this.id)
    this.http.get(this.url+"/details/"+ this.id).subscribe(result=>{
      console.log(this.url)
      console.log(result);
      this.user=result['candidate'];
    });
  }
  onDelete(){
   
    this.http.delete(this.url+"/delete/"+ this.id).subscribe(result=>{console.log('Result from action delete: '+result)
    this.router.navigate(['/']);
    })
  }
 
}

 export class  ClassUser{
   constructor(){
     this.firstName="";
     this.lastName="";
     this.middleName="";
     this.id="";
     this.departmentName="";
     this.education="";
     this.birthDate= new Date("1978-02-03");
     this.user="";
     this.isOwner=false;
     this.score=0;
     this.isDeleted=false;
    }
    firstName:string;
    lastName:string;
    middleName:string;
    id:string;
    departmentName:string;
    education:string;
    birthDate: Date;
    score:number;
    user:string;
    isOwner:boolean;
    isDeleted:boolean;
}