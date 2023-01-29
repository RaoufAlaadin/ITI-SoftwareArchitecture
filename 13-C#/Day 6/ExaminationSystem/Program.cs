using System.Diagnostics;
using static ExaminationSystem.Enums;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "\n  ============= Welcome to MIT's Examination System ============== \n"
            );

            Enums.ExamType examType;
            do
            {
                Console.Write("\n Enter the Exam Type (PracticeExam : 1 , FinalExam :  2 ) : ");

                /* Validation Steps ==> 1- tryParse takes the input and store it in a form similar to our enum type
                                           but it doesn't make sure that we have that enum in our list
                                       2-  IsDefined will verify for sure that we have that enum in our ExamType
                note: here we can enter 1 or "PracticeExam" and both will work.
                 */
            } while (
                !Enum.TryParse(Console.ReadLine(), out examType)
                || !Enum.IsDefined(typeof(Enums.ExamType), examType)
            );

            // General Exam Data 

            // 1- number of questions wanted 
            Console.Write("\nEnter the number of questions: ");

            int.TryParse(Console.ReadLine(), out int numberOfquestions);

            /*  no. of [Available Questions] can be updated,
            if we added more quesitons to the questions Bank */

            int numberOfAvailableQuestions = 8; // we currently have 8 registered questions for DB 

            /*  This part compares both values and takes the smaller one
                This makes sure, that we won't access a place where we don't have questions yet*/
            numberOfquestions = Math.Min(numberOfquestions, numberOfAvailableQuestions);

            // 2- subject name ==> might have hand in the type of questions used later on.
            Console.Write("\nEnter the subject name ( DB / HTML/ C#) : ");
            Enum.TryParse(Console.ReadLine(), out subjectName subjectName);




            switch (examType)
            {
                case Enums.ExamType.PracticeExam:

                    Console.WriteLine("\n ======= Practice Exam is being loaded..... ====");

                    PracticeExam p1 = (PracticeExam) QuestionsBank.generateExam(numberOfquestions, subjectName,"Practice");
                    p1.showExam();
                    break;
                case Enums.ExamType.FinalExam:

                    //FinalExam f1 = new FinalExam();
                    Console.WriteLine("\n ======= Final Exam is being loaded..... ====");

                    /* We should be storing the answers of the user, as we are going to display it at the end */
                    FinalExam f1 = (FinalExam)QuestionsBank.generateExam(numberOfquestions, subjectName, "Final");
                    f1.showExam();


                    break;
                default:
                    break;
            }

            /*Exam Data */

            

            /*      We need the end user to select the Exam Type , and upon this choice we
                    will show the Exam .*/

            /*      consider overriding ToString , Equals ,
                        GetHashCode all the constructors use chaining .*/
        }
    }
}
