using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Designation { get; set; }
    public decimal Salary { get; set; }
    public string? Department { get; set; }

    public Employee(int id, string? name, string? email, string? phone, string? designation, decimal salary, string? department)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));
        }
        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentException("Phone cannot be null or empty.", nameof(phone));
        }
        if (string.IsNullOrWhiteSpace(designation))
        {
            throw new ArgumentException("Designation cannot be null or empty.", nameof(designation));
        }
        if (salary < 0)
        {
            throw new ArgumentException("Salary cannot be negative.", nameof(salary));
        }
        if (string.IsNullOrWhiteSpace(department))
        {
            throw new ArgumentException("Department cannot be null or empty.", nameof(department));
        }
        Name = name;
        Email = email;
        Phone = phone;
        Designation = designation;
        Salary = salary;
        this.Department = department;
    }

}