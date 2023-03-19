namespace CourseSD.Model
{
    public class CourseList
    {

        public static List<Course> Courses = new List<Course>()
        {
        new Course() {id = 1 , name ="C" , Duration= 60 , Description ="intro to .net and c# Basics" },
        new Course() {id = 2 , name ="SQL" , Duration=50 , Description ="Structure Query Language" },
        new Course() {id = 3 , name ="Asp.net" , Duration= 36 , Description ="Server Side Programming" },
        new Course() {id = 4 , name ="MVC" , Duration= 30 , Description ="Server Side Programming" },
        };

    }
}
