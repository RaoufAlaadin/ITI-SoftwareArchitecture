namespace CompanySystem
{
    struct Employee
    {
        private Enums.SecurityLevels mySecurityLevel;

        private int id;
        private string name;

        private decimal salary;
        private HiringDate myHireDate;
        private Enums.Gender gender;

        public Employee(
            int _id,
            string _name,
            Enums.SecurityLevels _mySecurityLevel,
            decimal _salary,
            string _myHireDate,
            Enums.Gender _gender
        )
        {
            id = _id;
            name = _name;
            mySecurityLevel = _mySecurityLevel;
            salary = _salary;
            gender = _gender;
            myHireDate = Utility.setHireDate(_myHireDate);
        }

        #region GettersAndSetters-inProperty

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Enums.SecurityLevels MySecurityLevel
        {
            get { return mySecurityLevel; }
            set { mySecurityLevel = value; }
        }
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public HiringDate MyHireDate
        {
            get { return myHireDate; }
            set { myHireDate = Utility.setHireDate(Convert.ToString(value)); }
        }

        public Enums.Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        #endregion





        public void getEmployeeData()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"""
           
            Emp ID : {this.Id}
            Name : {this.Name}
            "SecurityLevel : {this.MySecurityLevel}
            "Salary : {this.Salary:C}
            "Hiring Date {MyHireDate.ToString()}
            "Gender : {this.Gender}
            "==============================
            
            """;

            /*          you can also use this
             *
             * return $"Emp ID : {this.id}\n" +
                $"SecurityLevel : {this.mySecurityLevel}\n" +
                $"Salary : {this.salary:C}\n" +
                $"{myHireDate.ToString()}\n" +
                $"Gender : {this.gender}\n" +
                $"==============================";*/
        }
    }
}
