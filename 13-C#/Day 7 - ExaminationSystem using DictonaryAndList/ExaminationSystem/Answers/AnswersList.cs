using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class AnswersList: List<Answer>
    {
        

        public AnswersList() { }


        // Adding Question choices and the ChooseAll answer
        public AnswersList(Answer[] answersList)
        {
            // passing an array of answers is a quick way to add values to a List
            // In this case we use AddRange() instead of Add() 
            base.AddRange(answersList);
        }

        // Useful when adding ModelAnswers of T/F and ChooseOne
        public AnswersList(Answer answer)
        {
           base.Add(answer);
        }

        public AnswersList(string[] answer)
        {
            foreach (var item in answer)
            {
                base.Add(new Answer(item));
            }
            
            
        }

        


        /*    
         *    AnswersList right = obj as AnswersList;
                if (right == null) return false;
                if (this.GetType() != right.GetType()) return false;
                if (Object.ReferenceEquals(this, right)) return true;

                return (this.choice == right.choice);
        */

        public override bool Equals(object obj)
        {
            // 1- check that 
            if (obj is not AnswersList answersList) return false;

            if (object.ReferenceEquals(this, answersList)) return true;

            if (this.GetType() != answersList.GetType()) return false;

            if (Count != answersList.Count) return false;

            for (int i = 0; i < Count; i++)
            {
                if (!this[i].Equals(answersList[i]))
                    return false;
            }

            return true;
        }




        public override string ToString()
        {   
            // if it's not null then we have 4 choices 
            if (this[0].Text != "True" ) {

                return $""" 
                {this[0]?.ToString() ?? "  "} 
                {this[1]?.ToString() ?? "  "} 
                {this[2]?.ToString() ?? "  "} 
                {this[3]?.ToString() ?? "  "} 

                """;

            }

            else
            {
                return $""" 
                {this[0]?.ToString() ?? "  "} 
                {this[1]?.ToString() ?? "  "} 
               

                """;
            }
            
        }
    }
}
