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
        string header; // the question itself
        string body; // hints about the question or code
        double marks; // we will set each question to 1 mark maybe

        AnswersList answers; // the question choices
        AnswersList modelAnswer;

        public string Header
        {
            get => header;
            set => header = value;
        }
        public string Body
        {
            get => body;
            set => body = value;
        }
        public double Marks
        {
            get => marks;
            set => marks = value;
        }
        internal AnswersList Answers
        {
            get => answers;
            set => answers = value;
        }
        internal AnswersList ModelAnswer
        {
            get => modelAnswer;
            set => modelAnswer = value;
        }

        public Question(
            string header,
            string body,
            double marks,
            AnswersList answers,
            AnswersList modelAnswer
        )
        {
            this.Header = header;
            this.Body = body;
            this.Marks = marks;
            this.Answers = answers;
            this.ModelAnswer = modelAnswer;
        }

        public override string ToString()
        {
            return $"{Header}";
        }
    }
}
