using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class ChooseOne : Question
    {
        public ChooseOne(
            string header,
            string body,
            double marks,
            AnswersList answers,
            AnswersList modelAnswer
        )
            : base(header, body, marks, answers, modelAnswer) { }

        public override string ToString()
        {
            return $"{ModelAnswer[0].Choice} =====> {ModelAnswer[0].Text}";
        }
    }
}
