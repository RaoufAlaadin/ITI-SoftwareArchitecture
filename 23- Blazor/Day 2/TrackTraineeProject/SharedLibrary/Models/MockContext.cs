using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class MockContext
    {


        public static List<Track> Tracks = new List<Track>()
        {
            new Track
            {
                Name = "Web Development",
                Description = "Learn how to create web applications"
            },
            new Track
            {
                Name = "Mobile Development",
                Description = "Learn how to create mobile applications"
            },
            new Track
            {
                Name = "Data Science",
                Description = "Learn how to analyze and interpret data"
            },
            new Track
            {
                Name = "Cloud Computing",
                Description = "Learn how to deploy and manage cloud applications"
            },
            new Track
            {
                Name = "Artificial Intelligence",
                Description = "Learn how to build intelligent machines"
            },
            new Track
            {
                Name = "Game Development",
                Description = "Learn how to develop games for different platforms"
            },
            new Track
            {
                Name = "Blockchain",
                Description =
                    "Learn how to build decentralized applications using blockchain technology"
            },
            new Track
            {
                Name = "UI/UX Design",
                Description = "Learn how to create user-friendly interfaces"
            }
        };



        public static List<Trainee> Trainees = new List<Trainee>()
        {
            new Trainee
            {
                Name = "Sara",
                Gender = Gender.Female,
                Email = "sara@gmail.com",
                MobileNo = "01234567890",
                Birthdate = new DateTime(1995, 10, 5),
                IsGraduated = true,
                TrackId = 2
            },
            new Trainee
            {
                Name = "Ahmed",
                Gender = Gender.Male,
                Email = "ahmed@yahoo.com",
                MobileNo = "01098765432",
                Birthdate = new DateTime(1998, 3, 12),
                IsGraduated = false,
                TrackId = 3
            },
            new Trainee
            {
                Name = "Fatma",
                Gender = Gender.Female,
                Email = "fatma@hotmail.com",
                MobileNo = "01555566677",
                Birthdate = new DateTime(2000, 1, 1),
                IsGraduated = true,
                TrackId = 5
            },
            new Trainee
            {
                Name = "Ali",
                Gender = Gender.Male,
                Email = "ali@gmail.com",
                MobileNo = "01188899900",
                Birthdate = new DateTime(1997, 7, 20),
                IsGraduated = false,
                TrackId = 7
            },
            new Trainee
            {
                Name = "Yara",
                Gender = Gender.Female,
                Email = "yara@yahoo.com",
                MobileNo = "01234567890",
                Birthdate = new DateTime(1998, 5, 10),
                IsGraduated = true,
                TrackId = 4
            }
        };


    }
}
