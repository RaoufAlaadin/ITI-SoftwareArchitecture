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
        int time; // I think this means duration // if it means today's date then we need to change the type to Date

        QuestionsList examQuestions;
        Dictionary<Question, AnswersList> examDictionary; // this stores the Question and student Answer
        Subject subject;

        public int NumberOfQuestions
        {
            get => numberOfQuestions;
            set => numberOfQuestions = value;
        }
        public int Time
        {
            get => time;
            set => time = value;
        }
        internal QuestionsList ExamQuestions
        {
            get => examQuestions;
            set => examQuestions = value;
        }
        internal Dictionary<Question, AnswersList> ExamDictionary
        {
            get => examDictionary;
            set => examDictionary = value;
        }
        internal Subject Subject
        {
            get => subject;
            set => subject = value;
        }

        public Exam(
            int numberOfQuestions,
            int time,
            QuestionsList examQuestions,
            Dictionary<Question, AnswersList> examDictionary,
            Subject subject
        )
        {
            this.NumberOfQuestions = numberOfQuestions;
            this.Time = time;
            this.ExamQuestions = examQuestions;
            this.ExamDictionary = examDictionary;
            this.Subject = subject;
        }

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

        public static void readAndCheckInput(out string[] studentChoices, out string answerInput)
        {
            Regex checkChoice = new Regex(@"^[abcd](/[abcd])*$");
            do
            {
                Console.Write("Enter your Answer: ");
                /*
                 using ToLower() is important for extra safety
                    but note that we already have only lowerCase letters allowed inside the Regex
                */
                answerInput = Console.ReadLine()?.ToLower() ?? "";
                studentChoices = answerInput.Split('/');

                // used the discard symbol (_) because I only need the True/False return
            } while (!checkChoice.IsMatch(answerInput));
        }

        public static void studentAnswerParsing(Exam obj, int i)
        {
            readAndCheckInput(out string[] studentChoices, out string answerInput);

            // this will store all the student choices for that specific question no matter how many.
            obj.ExamDictionary.TryAdd(obj.ExamQuestions[i], new AnswersList(studentChoices));
        }

        public static void displayExamModelAnswers(Exam obj)
        {
            Console.WriteLine("\n \t\t\t ======= Exam's Model Answer ===== \n");
            for (int i = 0; i < obj.NumberOfQuestions; i++)
            {
                // note that when interpolate a variable it automatically calls it's toString()
                // that's why it's displaying that writing ToString here is redundent

                // very Important: it's going to call the ToString() of the dervied classes not the base question
                //                everytime ExamQuestions[i] gives us a new Data Type. 
                Console.WriteLine(
                    $"Question ({i + 1}) model Answer: {obj.ExamQuestions[i].ToString()}\n"
                );
            }
        }

        public static void examCorrection(Exam obj, out int correctAnswers)
        {
            correctAnswers = 0;

            foreach (KeyValuePair<Question, AnswersList> item in obj.ExamDictionary)
            {
                item.Key.ModelAnswer.Sort();
                item.Value.Sort();

                if (item.Key.ModelAnswer.Equals(item.Value))
                {
                    if (item.Key.GetType().Name != "ChooseAll")
                        correctAnswers++;
                    else
                        correctAnswers += item.Value.Count;
                    // This adds 1 mark for each extra choice
                    // The logic isn't great, but it's fine for testing.




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
