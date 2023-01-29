using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class Question
    {

        /* each question hold the right answer or rightAnswers( in case of chooseAll) */


        string header; // the question itself 
        string body; // hints about the question or code 
        double marks; // we will set each question to 1 mark maybe  

        AnswersList answers; // the question choices 

         


        /*  Question is constructed
            from a Body, Marks, and Header and ……..


        We want the application to accept different Question Types, True or False,
            Choose One and Choose All each has a different way off representation

        */

        /* Question has an asscociation relation with AnswerList 
           this means question have an object from answersList 
        */
        // this a a reference to an object from answers




        public Question(string header, string body, double marks, AnswersList answers)
        {
            this.Header = header;
            this.Body = body;
            this.Marks = marks;
            this.Answers = answers;
            //this.modelAnswer = modelAnswer;
        }

        public string Header { get => header; set => header = value; }
        public string Body { get => body; set => body = value; }
        public double Marks { get => marks; set => marks = value; }
        public AnswersList Answers { get => answers; set => answers = value; }



        public override string ToString()
        {
            return $"{Header}"; 
        }

        public virtual Object getModelAnswer()
        {
            Console.WriteLine("Hello from question");
            return answers;
        }
        

    }



}
