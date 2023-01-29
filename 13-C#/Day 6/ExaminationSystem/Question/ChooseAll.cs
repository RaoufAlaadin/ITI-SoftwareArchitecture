using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{


    class ChooseAll : Question
    {
            /* Here we start to notice a difference , as we have more than one answer available. */
        Answer [] modelAnswer; 
        public ChooseAll(string header, string body, double marks, AnswersList answers, Answer[] modelAnswer) : base(header, body, marks, answers)
        {
            this.ModelAnswer = modelAnswer;
        }

        public Answer[] ModelAnswer { get => modelAnswer; set => modelAnswer = value; }

        public override string ToString()
        {
            string result = "Correct multi-Choices: ";
            for (int i = 0; i < ModelAnswer.Length; i++)
            {
                result += $"\n{ModelAnswer[i].Choice} =====> {ModelAnswer[i].Text}";
            }
            return result;
        }

        public override Answer[] getModelAnswer(
            ) => modelAnswer;
    }
}
