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
                Id = 1,
                Name = "Web Development",
                Description = "Learn how to create web applications"
            },
            new Track
            {
                Id = 2,
                Name = "Mobile Development",
                Description = "Learn how to create mobile applications"
            },
            new Track
            {
                Id = 3,
                Name = "Data Science",
                Description = "Learn how to analyze and interpret data"
            },
            new Track
            {
                Id = 4,
                Name = "Cloud Computing",
                Description = "Learn how to deploy and manage cloud applications"
            },
            new Track
            {
                Id = 5,
                Name = "Artificial Intelligence",
                Description = "Learn how to build intelligent machines"
            },
            new Track
            {
                Id = 6,
                Name = "Game Development",
                Description = "Learn how to develop games for different platforms"
            },
            new Track
            {
                Id = 7,
                Name = "Blockchain",
                Description =
                    "Learn how to build decentralized applications using blockchain technology"
            },
            new Track
            {
                Id = 8,
                Name = "UI/UX Design",
                Description = "Learn how to create user-friendly interfaces"
            }
        };



        public static List<Trainee> Trainees = new List<Trainee>()
        {
            new Trainee
            {
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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
                Id = 4,
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
                Id = 5,
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
