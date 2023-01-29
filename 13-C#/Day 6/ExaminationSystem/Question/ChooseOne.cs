using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{


    class ChooseOne : Question
    {

        Answer modelAnswer; // single answer still 
        public ChooseOne(string header, string body, double marks, AnswersList answers, Answer modelAnswer) : base(header, body, marks, answers)
        {
            this.ModelAnswer = modelAnswer;
        }

        public Answer ModelAnswer { get => modelAnswer; set => modelAnswer = value; }


        public override Answer getModelAnswer(
            ) => modelAnswer;
        public override string ToString()
        {
            return $"{ModelAnswer.Choice} =====> {ModelAnswer.Text}";
        }

    }

}
                    