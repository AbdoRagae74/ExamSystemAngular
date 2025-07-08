import { Routes } from '@angular/router';
import { TakeExam } from './Components/take-exam/take-exam';
import { showexams } from './Components/showexams/showexams';
import { Result } from './Components/result/result';
import { AddExam } from './Components/add-exam/add-exam';
import { AdminAllExams } from './Components/admin-all-exams/admin-all-exams';
import { ExamQuestions } from './Components/exam-questions/exam-questions';

export const routes: Routes = [

{path:'exam/:id/:stid',component:TakeExam },
{path:"exams",component:showexams},
{path:"newExam",component:AddExam},
{path:"result",component:Result},
{path:"adminexams",component:AdminAllExams},
{path:"examquestions/:id",component:ExamQuestions}


];
