namespace Demo.DTO
{
    public class EmployeeDataWithDepartmentNameDTO
    {
            /* Extra Secuirty by hiding the original names in my
             Model Structure. 
            
             And solve serialization problem cycle. 
            */
        public int ID { get; set; }
        public string StudentName { get; set; }

        public string Address { get; set; }

        public string DepartmentName { get; set; }  
    }
}
