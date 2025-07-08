import { IAnswer } from "./IAnswer";

export interface IQuestion{
    type:string;
    body:string;
    grade:number;
    id:number;
    answers:IAnswer[];
}