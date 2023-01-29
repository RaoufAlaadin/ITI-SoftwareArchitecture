using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{


    struct Enums
    {
        /* here I can set the Enum to being internal or public depending on the level of encapsulation I want. */
        
        public enum ExamType : byte
        {
            PracticeExam = 1,
            FinalExam = 2
        }

        public enum QuestionType : byte
        {
            TrueOrFalse = 1,
            ChooseOne = 2,
            ChooseAll = 3
        }

        public enum subjectName : byte
        {
            html = 1,
            DB = 2,
            css = 3
        }
    }
}
