namespace CompanySystem
{
    internal class EmployeeSearch
    {
        int[] nationalIDs;
        Employee[] employees;
        readonly int size;

        public EmployeeSearch(int _Size)
        {
            size = _Size;
            nationalIDs = new int[size];
            employees = new Employee[size];
        }

        public void setEmployeeSearch(int index, int Number, ref Employee temp)
        {
            if ((index >= 0) && (index < size))
            {
                nationalIDs[index] = Number;

                // here, this means we are assigning the reference to another variable for an object already created in memory
                // so now temp and employee[index] point to the same object.
                employees[index] = temp;
            }
        }

        public Employee[] Employee
        {
            set { }
            get { return employees; }
        }

        /* Class EmployeeSearch
{ int[] NationalIDs ; Employee[] Employees ….}
I need to support Searching By NationalID , Hiring Dates , Name (return Employee(s) Object)
Implement All Necessary Indexers


 */
        public Employee this[int nationalID]
        {
            get
            {
                for (int i = 0; i < this.nationalIDs.Length; i++)
                {
                    if (this.nationalIDs[i] == nationalID)
                    {
                        return employees[i];
                    }
                }
                throw new IndexOutOfRangeException();
            }
        }

        public Employee this[HiringDate date]
        {
            get
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].MyHireDate.Equals(date))
                    {
                        return employees[i];
                    }
                }
                throw new IndexOutOfRangeException();
            }
        }

        public Employee this[string name]
        {
            get
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].Name == name)
                    {
                        return employees[i];
                    }
                }
                throw new IndexOutOfRangeException();
            }
        }
    }
}


/*
struct PhoneBook
{
    string[] Names;
    long[] Numbers;
    readonly int size;

    public int Size { get { return size; } }

    public PhoneBook(int _Size)
    {
        size = _Size;
        Names = new string[size];
        Numbers = new long[size];
    }

    public void SetEntry(int index, string Name, long Number)
    {
        if ((index >= 0) && (index < size))
        {
            Names[index] = Name;
            Numbers[index] = Number;
        }
    }

    public long GetNumber(string Name)
    {
        for (int i = 0; i < size; i++)
            if (Names[i] == Name)
                return Numbers[i];
        return -1;
    }

    ///set (long value , string Name) ,, long get(string Name)
    public long this[string Name]
    {
        set
        {
            for (int i = 0; i < size; i++)
                if (Names[i] == Name)
                    Numbers[i] = value;
        }
        get
        {
            for (int i = 0; i < size; i++)
                if (Names[i] == Name)
                    return Numbers[i];
            return -1;

        }
    }

    public string this[int index]
    {
        get
        {
            if ((index >= 0) && (index < size))
                return $"{Names[index]}:::{Numbers[index]}";
            return "NA";
        }
    }

    public long this[int index, string Name]
    {
        set
        {
            if ((index >= 0) && (index < size))
            {
                Names[index] = Name;
                Numbers[index] = value;
            }
        }
    }

}*/
