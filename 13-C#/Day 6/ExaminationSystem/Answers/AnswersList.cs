using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    class AnswersList
    {
        Answer[] answersList;

        public AnswersList() { }

        public AnswersList(Answer[] answersList)
        {
            this.AnswersListx = answersList;
        }

        public Answer[] AnswersListx
        {
            get => answersList;
            set => answersList = value;
        }


        
        public override string ToString()
        {   
            // if it's not null then we have 4 choices 
            if (AnswersListx[0].Text != "True" ) {

                return $""" 
                {AnswersListx[0]?.ToString() ?? "  "} 
                {AnswersListx[1]?.ToString() ?? "  "} 
                {AnswersListx[2]?.ToString() ?? "  "} 
                {AnswersListx[3]?.ToString() ?? "  "} 

                """;

            }

            else
            {
                return $""" 
                {AnswersListx[0]?.ToString() ?? "  "} 
                {AnswersListx[1]?.ToString() ?? "  "} 
               

                """;
            }
            
        }
    }
}
