using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExaminationSystem
{

    class Exam
    {
        int numberOfQuestions;
        int time; // I think this means duration

        Question[] examQuestions;
        Subject subject;

        AnswersList[] studentAnswers;

      

        public Exam(int numberOfQuestions, int time, Question[] examQuestions, AnswersList[] studentAnswers,  Subject subject )
        {
            this.numberOfQuestions = numberOfQuestions;
            this.time = time;
            this.examQuestions = examQuestions;
            this.subject = subject;
            this.StudentAnswers = studentAnswers;
        }


        /* exam class describe the common attributes
        concerning the exam, Time, number of Questions, Question Answer
        Dictionary(Which will be used for Exam Correction) , a Show Exam
        Functionality that it’s implementations will be differed to the further
        classes in the hierarchy*/




        public int NumberOfQuestions { get => numberOfQuestions; set => numberOfQuestions = value; }
        public int Time { get => time; set => time = value; }
        public Question[] ExamQuestions { get => examQuestions; set => examQuestions = value; }
        public Subject Subject { get => subject; set => subject = value; }
        public AnswersList[] StudentAnswers { get => studentAnswers; set => studentAnswers = value; }

        public virtual void showExam()
        {
            // will be overriden by other classes in the hierarchy
            Console.WriteLine("This is the base exam virtual method");

        }



        public static void displayQuestions(Exam obj, int i)
        {
            Console.Write(
                $"Question ({i + 1}) {obj.ExamQuestions[i].Header} ====> Q.type ({obj.ExamQuestions[i].GetType().Name}) \n"
            );
        }

        public static void displayAnswers(Exam obj, int i)
        {
            Console.WriteLine(obj.ExamQuestions[i].Answers.ToString());
            Console.WriteLine("=========================");
        }

        public static void studentAnswerParsing(Exam obj, int i)
        {
            //string answerInput;
            //string[] studentChoices;

            readAndCheckInput(out string[] studentChoices, out string answerInput);

            // storing the student choice for this question in the offical answerList
            for (int j = 0; j < studentChoices.Length; j++)
            {
                obj.StudentAnswers[i].AnswersListx[j] = new Answer(studentChoices[j]);
            }
        }

        public static void readAndCheckInput(out string[] studentChoices, out string answerInput)
        {
            Regex checkChoice = new Regex(@"^[abcd](/[abcd])*$");
            do
            {
                Console.Write("Enter your Answer: ");
                answerInput = Console.ReadLine() ?? "";
                studentChoices = answerInput.Split('/');

                // used the discard symbol (_) because I only need the True/False return
            } while (!checkChoice.IsMatch(answerInput));
        }

        public static void displayExamModelAnswers(Exam obj)
        {
            Console.WriteLine("\n \t\t\t ======= Exam's Model Answer ===== \n");
            for (int i = 0; i < obj.NumberOfQuestions; i++)
            {
                // note that when interpolate a variable it automatically calls it's toString()
                // that's why it's displaying that writing ToString here is redundent
                Console.WriteLine(
                    $"Question ({i + 1}) model Answer: {obj.ExamQuestions[i].ToString()}\n"
                );
            }
        }

        public static void examCorrection(Exam obj, out int correctAnswers)
        {
            correctAnswers = 0;

            for (int i = 0; i < obj.NumberOfQuestions; i++)
            {
                if (obj.ExamQuestions[i].GetType().Name != "ChooseAll")
                {
                    if (
                        obj.StudentAnswers[i].AnswersListx[0].Equals(
                            obj.ExamQuestions[i].getModelAnswer()
                        )
                    )
                    {
                        correctAnswers++;
                    }
                }
                else
                {
                    // checking if our answer is available in any of the correct answers.

                    for (int j = 0; j < obj.StudentAnswers[i].AnswersListx.Length; j++)
                    {
                        foreach (Answer item in obj.ExamQuestions[i].getModelAnswer() as Answer[])
                        {
                            if (obj.StudentAnswers[i].AnswersListx[j].Equals(item))
                            {
                                correctAnswers++;
                            }
                        }
                    }
                }
            }
        }

        public static void displayExamResults(Exam obj, int correctAnswers)
        {
            Console.WriteLine("\n \t\t\t ======= Exam's Result  ===== \n");

            Console.WriteLine(
                $"\n \t\t\t You scored {correctAnswers} out of {9}  in {obj.Subject.SubjectName}\n"
            );
        }





    }
}
