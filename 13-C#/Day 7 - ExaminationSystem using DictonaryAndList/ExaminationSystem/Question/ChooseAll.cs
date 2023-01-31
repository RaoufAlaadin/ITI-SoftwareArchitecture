using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class ChooseAll : Question
    {
        public ChooseAll(
            string header,
            string body,
            double marks,
            AnswersList answers,
            AnswersList modelAnswer
        )
            : base(header, body, marks, answers, modelAnswer) { }

        public override string ToString()
        {
            string result = "Correct multi-Choices: ";
            for (int i = 0; i < ModelAnswer.Count; i++)
            {
                result += $"\n{ModelAnswer[i].Choice} =====> {ModelAnswer[i].Text}";
            }
            return result;
        }
    }
}
