using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExaminationSystem.Enums;

namespace ExaminationSystem
{
    class QuestionsBank
    {
        public static Exam generateExam(
            int numberOfquestions,
            Enums.subjectName subjectName,
            string ExamType
        )
        {
            QuestionsList questionBank = new QuestionsList();

            #region Exam Questions Bank

            Answer[] answers1 =
            {
                new Answer("a", "SQL"),
                new Answer("b", "MySQL"),
                new Answer("c", "Oracle"),
                new Answer("d", "MongoDB")
            };


            questionBank.Add(new ChooseOne(
                "Which of the following is a relational database management system?",
                "",
                1,
                new AnswersList(answers1),
                new AnswersList(answers1[0])
            ));

            ////////////////////////////////

            Answer[] answers2 =
            {
                new Answer("a", "SELECT"),
                new Answer("b", "FROM"),
                new Answer("c", "WHERE"),
                new Answer("d", "ALL")
            };
            questionBank.Add( new ChooseOne(
                "Which of the following is a SQL keyword used to select specific columns from a table?",
                "",
                2,
                new AnswersList(answers2),
                new AnswersList(answers2[0])
            ));

            ////////////////////////////////

            Answer[] answers3 =
            {
                new Answer("a", "TRUNCATE"),
                new Answer("b", "DROP"),
                new Answer("c", "DELETE"),
                new Answer("d", "CLEAR")
            };
            questionBank.Add(new ChooseOne("Which of the following SQL commands is used to delete all data in a table, but not the table itself?", "", 3, new AnswersList(answers3), new AnswersList(answers3[0])));

            ////////////////////////////////

            Answer[] answers4 =
            {
                new Answer("a", "JOIN"),
                new Answer("b", "UNION"),
                new Answer("c", "GROUP BY"),
                new Answer("d", "HAVING")
            };
            questionBank.Add(new ChooseOne("Which of the following SQL keywords is used to combine rows from two or more tables based on a related column between them?", "", 4, new AnswersList(answers4), new AnswersList(answers4[0]))   );

            ////////////////////////////////

            Answer[] answers5 = { new Answer("a", "True"), new Answer("b", "False") };
            questionBank.Add( new TrueOrFalse(
                "SQL stands for Structured Query Language.",
                "True",
                5,
                new AnswersList(answers5),
                new AnswersList(answers5[0])
            ));

            ////////////////////////////////

            Answer[] answers6 =
            {
                new Answer("a", "Primary key"),
                new Answer("b", "Foreign key"),
                new Answer("c", "Index"),
                new Answer("d", "Unique key")
            };
            questionBank.Add(new ChooseOne("Which of the following is a column or set of columns in a database table that uniquely identifies each row in the table?", "", 6, new AnswersList(answers6), new AnswersList(answers6[0])));

            ////////////////////////////////

            ////////////////////////////////

            Answer[] answers7 = { new Answer("a", "True"), new Answer("b", "False") };
            questionBank.Add(new TrueOrFalse(
                "SQL databases use a fixed schema.",
                "True",
                1,
                new AnswersList(answers7),
                new AnswersList(answers7[0])
            ));

            ////////////////////////////////

            Answer[] answers8 =
            {
                new Answer("a", "ACID"),
                new Answer("b", "BASE"),
                new Answer("c", "Both ACID and BASE"),
                new Answer("d", "Neither ACID nor BASE")
            };

            Answer[] modelAnswer1 = { answers8[0], answers8[1] };
            questionBank.Add( new ChooseAll(
                "Which of the following are properties of a database?",
                "ACID and BASE are properties of a database",
                1,
                new AnswersList(answers8),
                new AnswersList(modelAnswer1)
            ));
            #endregion

            

            // Choosing the questions we want from the questionBank
            Question[] qE1 = new Question[numberOfquestions];

            for (int i = 0; i < numberOfquestions; i++)
            {
                qE1[i] = questionBank[i];
            }

            // Calling the QuestionsList constructor will Print the selected Exam with it's choices.
            QuestionsList examQuestionsList = new QuestionsList("Exam1", qE1);

           
            Subject subject = new Subject(subjectName, 100);

            //Creating this exam's dictionary
            Dictionary<Question, AnswersList> ExamDictionary = new Dictionary<Question, AnswersList>();


            // Returning an Exam Object based on the type that has been requested.
            if (ExamType == "Practice")
            {
                return new PracticeExam(numberOfquestions, 1, examQuestionsList, ExamDictionary, subject);
            }
            else
            {
                return new FinalExam(numberOfquestions, 1, examQuestionsList, ExamDictionary, subject);
            }
        }
    }
}
