using System;
using System.Collections.Generic;

namespace WebApi_Ramya.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public int DeptId { get; set; }

    public string EmpName { get; set; } = null!;

    public decimal EmpSalary { get; set; }

    public string? EmpAddress { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
