import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IExam } from '../../Models/IExam';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';

@Component({
  selector: 'app-showexams',
imports: [HttpClientModule,ReactiveFormsModule,RouterLink],
  templateUrl: './showexams.html',
  styleUrl: './showexams.css'
})
export class showexams implements OnInit {
    
mySub1!: Subscription;
  baseUrl: string = 'https://localhost:7191/api/Student/1/available';
  protected title = 'website';
  constructor(private http:HttpClient,private cdr:ChangeDetectorRef,private actr:ActivatedRoute) {}
  exams:IExam[]=[];
  ngOnInit(): void {
    this.mySub1 = this.http.get<Array<IExam>>(this.baseUrl).subscribe({
      next:(resp)=>{
        this.exams=resp;
        this.cdr.detectChanges();
        console.log(resp);
      },
      error:(error)=>{
        console.log(error);
      }
    });
  
  }
 
  gotoExam(){

  }

}
