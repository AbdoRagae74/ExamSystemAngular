import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IExam } from '../../Models/IExam';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-admin-all-exams',
  imports: [HttpClientModule,RouterModule],
  templateUrl: './admin-all-exams.html',
  styleUrl: './admin-all-exams.css'
})
export class AdminAllExams implements OnInit {
  mySub1!: Subscription;
  baseurl:string = "https://localhost:7191/api/Exam";
  

  constructor(private http:HttpClient,private cdr:ChangeDetectorRef) {}
  allExams:IExam[]=[];
  ngOnInit(): void {

    this.mySub1 = this.http.get<Array<IExam>>(this.baseurl).subscribe({
      next:(resp)=>{        
        this.allExams = resp;
        console.log(this.allExams);
        this.cdr.detectChanges();
      },
      error:(err)=>{
        console.log(err);
      }
    },
  )

  }

}
