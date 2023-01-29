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
        //Question[] questionStorage;


        public static Exam generateExam(
            int numberOfquestions,
            Enums.subjectName subjectName,
            string ExamType
        )
        {
            Question[] questionBank = new Question[100];
            AnswersList[] studentAnswerBank = new AnswersList[100];

            //AnswersList[] answerBank = new AnswersList[100];
            //AnswersList[] modelAnswerBank = new AnswersList[100];

            // intiliziting the array that will store the student answers
            for (int i = 0; i < numberOfquestions; i++)
            {
                Answer[] answers =
                {
                    new Answer("", ""),
                    new Answer("", ""),
                    new Answer("", ""),
                    new Answer("", "")
                };

                studentAnswerBank[i] = new AnswersList(answers);
            }

            #region Exam Questions Bank

            Answer[] answers1 =
            {
                new Answer("a", "SQL"),
                new Answer("b", "MySQL"),
                new Answer("c", "Oracle"),
                new Answer("d", "MongoDB")
            };
            questionBank[0] = new ChooseOne(
                "Which of the following is a relational database management system?",
                "",
                1,
                new AnswersList(answers1),
                answers1[0]
            );

            ////////////////////////////////

            Answer[] answers2 =
            {
                new Answer("a", "SELECT"),
                new Answer("b", "FROM"),
                new Answer("c", "WHERE"),
                new Answer("d", "ALL")
            };
            questionBank[1] = new ChooseOne(
                "Which of the following is a SQL keyword used to select specific columns from a table?",
                "",
                2,
                new AnswersList(answers2),
                answers2[0]
            );

            ////////////////////////////////

            Answer[] answers3 =
            {
                new Answer("a", "TRUNCATE"),
                new Answer("b", "DROP"),
                new Answer("c", "DELETE"),
                new Answer("d", "CLEAR")
            };
            questionBank[2] = new ChooseOne(
                "Which of the following SQL commands is used to delete all data in a table, but not the table itself?",
                "",
                3,
                new AnswersList(answers3),
                answers3[0]
            );

            ////////////////////////////////

            Answer[] answers4 =
            {
                new Answer("a", "JOIN"),
                new Answer("b", "UNION"),
                new Answer("c", "GROUP BY"),
                new Answer("d", "HAVING")
            };
            questionBank[3] = new ChooseOne(
                "Which of the following SQL keywords is used to combine rows from two or more tables based on a related column between them?",
                "",
                4,
                new AnswersList(answers4),
                answers4[0]
            );

            ////////////////////////////////

            Answer[] answers5 = { new Answer("a", "True"), new Answer("b", "False") };
            questionBank[4] = new TrueOrFalse(
                "SQL stands for Structured Query Language.",
                "True",
                5,
                new AnswersList(answers5),
                answers5[0]
            );

            ////////////////////////////////

            Answer[] answers6 =
            {
                new Answer("a", "Primary key"),
                new Answer("b", "Foreign key"),
                new Answer("c", "Index"),
                new Answer("d", "Unique key")
            };
            questionBank[5] = new ChooseOne(
                "Which of the following is a column or set of columns in a database table that uniquely identifies each row in the table?",
                "",
                6,
                new AnswersList(answers6),
                answers6[0]
            );

            ////////////////////////////////

            ////////////////////////////////

            Answer[] answers7 = { new Answer("a", "True"), new Answer("b", "False") };
            questionBank[6] = new TrueOrFalse(
                "SQL databases use a fixed schema.",
                "True",
                1,
                new AnswersList(answers7),
                answers7[0]
            );

            ////////////////////////////////

            Answer[] answers8 =
            {
                new Answer("a", "ACID"),
                new Answer("b", "BASE"),
                new Answer("c", "Both ACID and BASE"),
                new Answer("d", "Neither ACID nor BASE")
            };

            Answer[] modelAnswer3 = { answers8[0], answers8[1] };
            questionBank[7] = new ChooseAll(
                "Which of the following are properties of a database?",
                "ACID and BASE are properties of a database",
                1,
                new AnswersList(answers8),
                modelAnswer3
            );
            #endregion





            // Exam questions
            Question[] qE1 = new Question[numberOfquestions];

            for (int i = 0; i < numberOfquestions; i++)
            {
                qE1[i] = questionBank[i];
            }

            // Student Answers
            //Answer[] studentAnswers = new Answer[numberOfquestions];

            /* I will take the choice as a user input then write the text next to it*/



            //AnswersList qE1_StudentAnswers = new AnswersList(studentAnswers);

            Subject subject = new Subject(subjectName, 100);

            if (ExamType == "Practice")
            {
                return new PracticeExam(numberOfquestions, 1, qE1, studentAnswerBank, subject);
            }
            else
            {
                return new FinalExam(numberOfquestions, 1, qE1, studentAnswerBank, subject);
            }
        }
    }
}
