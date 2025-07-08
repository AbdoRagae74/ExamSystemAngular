import { IQuestion } from "./IQuestion";

export interface IExam{
    id:number;
    name:string;
    duration:number;
    grade:number;
    minGrade:number;
    question:IQuestion[]
}