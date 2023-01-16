namespace CoreDepartment.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
