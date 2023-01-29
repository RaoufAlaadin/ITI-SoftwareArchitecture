using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class Answer
    {
        string choice;
        string text;

        public Answer()
        {
        }

        public Answer(string _choice)
        {
            this.choice = _choice;
        }

        //bool isCorrect;

        public Answer(string choice, string text)
        {
            this.choice = choice;
            this.text = text;
            //this.isCorrect = isCorrect;
        }

        public string Choice { get => choice; set => choice = value; }
        public string Text { get => text; set => text = value; }
        //public bool IsCorrect { get => isCorrect; set => isCorrect = value; }


        public override bool Equals(object obj)
        {
            Answer right = obj as Answer;
            if (right == null) return false;
            if (this.GetType() != right.GetType()) return false;
            if (Object.ReferenceEquals(this, right)) return true;

            return (this.choice == right.choice);
        }


        public override string ToString()
        {
            return $"({Choice}) - {Text}";
        }
    }
}
