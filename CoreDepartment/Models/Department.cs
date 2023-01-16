namespace CoreDepartment.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}
