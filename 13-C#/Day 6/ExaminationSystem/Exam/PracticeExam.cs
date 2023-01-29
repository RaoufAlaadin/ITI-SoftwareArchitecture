using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ExaminationSystem
{
    class PracticeExam : Exam
    {
        public PracticeExam(
            int numberOfQuestions,
            int time,
            Question[] examQuestions,
            AnswersList[] qE1_StudentAnswers,
            Subject subject
        )
            : base(numberOfQuestions, time, examQuestions, qE1_StudentAnswers, subject) { }

        /*        Practice exam
                    shows the right answer after finishing taking the Exam , while the Final
                     Exam Only Shows The Question and Answers*/



        public override void showExam()
        {
            // shows the rightAnswer after finishing taking the exam.

            // so a table containing the questions, your answers and the the correct answer for each question.
            //int i = 0;

            Console.WriteLine(
                "\n \t\t\t Exam Notes: choose one or more answers in the following format a/b/c/d \n"
            );

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                // 1- display question
                displayQuestions(this, i);

                // display answers
                displayAnswers(this, i);

                // register student's choice
                studentAnswerParsing(this, i);
            }

            displayExamModelAnswers(this);

            //examCorrection(this, out int correctAnswers);

            //displayExamResults(this, correctAnswers);

            Console.WriteLine("==========================================");

            Console.WriteLine("\n \t\t\t Questions Ended, Goodluck \n\n");
   
            Console.ReadKey();
        }

    }
}
