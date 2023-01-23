namespace CompanySystem
{
    struct HiringDate
    {
        public string day;
        public string month;
        public string year;

        public HiringDate(string _day, string _month, string _year)
        {
            day = _day;
            month = _month;
            year = _year;
        }

        public string MyHireDate
        {
            get { return $"{this.day}/{this.month}/{this.year}"; }
            set
            {
                string[] parsedDate = value.Split('/');
                day = parsedDate[0];
                month = parsedDate[1];
                year = parsedDate[2];
            }
        }

        public override string ToString()
        {
            return $"{this.day}/{this.month}/{this.year}";
        }
    }
}
