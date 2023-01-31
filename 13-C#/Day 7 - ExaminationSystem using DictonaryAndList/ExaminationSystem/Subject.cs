namespace ExaminationSystem
{
    class Subject
    {
       Enums.subjectName subjectName;
        int evaluationMark;

        public Subject(Enums.subjectName subjectName, int evaluationMark)
        {
            this.SubjectName = subjectName;
            this.evaluationMark = evaluationMark;
        }

        public Enums.subjectName SubjectName { get => subjectName; set => subjectName = value; }
    }
}