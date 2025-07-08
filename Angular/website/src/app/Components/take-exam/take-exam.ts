import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IQuestion } from '../../Models/IQuestion';
import { IExam } from '../../Models/IExam';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-take-exam',
  imports: [HttpClientModule,ReactiveFormsModule],
  templateUrl: './take-exam.html',
  styleUrl: './take-exam.css'
})
export class TakeExam implements OnInit {


  mySub1!: Subscription;
  baseUrl: string = 'https://localhost:7191/api/Student/student/{studentId}/Exam/{id}';

 
  baseUrl2: string = 'https://localhost:7191/api/StudentAnswer';
  protected title = 'website';
  q:IQuestion[]=[];
  constructor(private http: HttpClient,private cdr:ChangeDetectorRef,private r:ActivatedRoute,private router: Router) {}
examid:string|null='';
stid:string|null='';
  startTime=this.getFormattedDate();
examForm = new FormGroup({});

  ngOnInit(): void {
    this.r.params.subscribe(params=>{
      this.examid = params['id'];
      this.stid = params['stid'];
    })

    console.log(this.examid);
    console.log(this.stid);
     this.baseUrl = `https://localhost:7191/api/Student/student/${this.stid}/Exam/${this.examid}`;

    this.mySub1 = this.http.get<IExam>(this.baseUrl).subscribe({
      next:(resp)=>{
        this.q = resp.question;
        console.log(this.q);
         this.buildForm();
         this.cdr.detectChanges();
      },
      error:(error)=>{
        console.log(error);
      }
    });
  
  }


    buildForm(): void {
    const group: { [key: string]: FormControl } = {};

    this.q.forEach(question => {
      group[question.id.toString()] = new FormControl(null,Validators.required); 
    });

    this.examForm = new FormGroup(group);
  }



saveAnswers(): void {
 if (this.examForm.invalid) {
    alert("Please answer all questions.");
    this.examForm.markAllAsTouched(); 
    return;
  }

    let endTime =this.getFormattedDate();
console.log(this.startTime);
console.log(endTime);
const correctAnswers = this.q.map(q => ({
  questionId: q.id,
  answerId: q.answers.find(a => a.isCorrect)?.id ?? null,
  grade:q.grade
}));
    const result = Object.entries(this.examForm.value).map(([questionId, answerId]) => ({
      StudentId:1,
      QuestionId: Number(questionId),
      AnswerId: Number(answerId)
    }));

    correctAnswers.sort((a, b) => a.questionId - b.questionId);
    result.sort((a, b) => a.QuestionId - b.QuestionId);
    

    console.log('Formatted to send:', result);
    console.log('Answers:', correctAnswers);
    let g = 0;
    for(var i=0 ; i<correctAnswers.length;i++){
      if(correctAnswers[i].answerId == result[i].AnswerId) g+=correctAnswers[i].grade;
    }
    console.log(g);

    this.http.post(this.baseUrl2,result).subscribe({
      next:(res)=>{
        console.log(res)
      },
      error:(err)=>{
        console.log(err);
      }
    });
    const stExamData = {
      studentid:this.stid,
      examid:this.examid,
      studentgrade:g,
      StartTime:this.startTime,
      EndTime:endTime
    }
    console.log(stExamData);
    this.http.post("https://localhost:7191/api/StudentExam",stExamData).subscribe({
      next:(res)=>{
         this.router.navigate(['/result'], { state: { grade: g } });
      },
      error:(err)=>{
        console.log(err);
      }
    });
    console.log("Done");

  }




   getFormattedDate() {
     const now = new Date();
  const pad = (n: number) => n.toString().padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}T${pad(now.getHours())}:${pad(now.getMinutes())}:${pad(now.getSeconds())}`;

}
}
