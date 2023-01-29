using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class TrueOrFalse : Question
    {
        Answer modelAnswer; // single answer -  true or false 
        /* Answer it self have (text and choice) */
        public TrueOrFalse(string header, string body, double marks, AnswersList answers, Answer modelAnswer) : base(header, body, marks, answers)
        {
            this.ModelAnswer= modelAnswer;
        }

        public Answer ModelAnswer { get => modelAnswer; set => modelAnswer = value; }

        public override string ToString()
        {
            return $"{ModelAnswer.Choice} =====> {ModelAnswer.Text}"; 
        }

        public override Answer getModelAnswer(
            ) => modelAnswer;
    }


}
