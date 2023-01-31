using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class TrueOrFalse : Question
    {
        public TrueOrFalse(string header, string body, double marks, AnswersList answers, AnswersList modelAnswer) : base(header, body, marks, answers, modelAnswer)
        {
        }

        //Answer modelAnswer; // single answer -  true or false 
        /* Answer it self have (text and choice) */




        public override string ToString()
        {
            return $"{ModelAnswer[0].Choice} =====> {ModelAnswer[0].Text}"; 
        }

       
    }


}
