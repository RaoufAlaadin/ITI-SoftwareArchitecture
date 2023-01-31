using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class QuestionsList : List<Question>
    {
        string? fileName;

        public QuestionsList(string _fileName, Question[] questions)
        {
            // this constructor will take all the questions from the array and log them into the file.

            this.fileName = _fileName;
            for (int i = 0; i < questions.Length; i++)
            {
                // because we made the new add method to take only one question at a time.
                // so we needed a for loop to log all the questions
                this.Add(questions[i]);
            }
            this.fileName = _fileName;
        }

        public QuestionsList() // this parameterless is useful when creating the question bank
        { }

        public QuestionsList(string _fileName)
        {
            this.fileName = _fileName;
        }

        public new void Add(Question Q)
        {
            // Keep the default behavior
            base.Add(Q);

            using (StreamWriter sw = new($"{fileName}.txt", true))
            {
                // this will write to the file we just created.
                sw.WriteLine(Q.Header);
                sw.WriteLine(Q.Answers);
            }
        }
    }
}
