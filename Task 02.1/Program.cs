using System;
class Employee
{
    public string EmployeeName { get; set; }
    public int EmployeeID { get; set; }
    public double Salary { get; set; }
    public Employee(string employeeName,int employeeId, double salary)
    {
        EmployeeName = employeeName;
        EmployeeID = employeeId;
        Salary = salary;
    }
    public virtual double GetSalary()
    { return Salary; }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Employee Name: {EmployeeName}");
        Console.WriteLine($"Employee ID: {EmployeeID}");
    }
}
class ParmanentEmployee : Employee
{
    public string Department { get; set; }
    public double Bonus { get; set; }
    public ParmanentEmployee(string employeeName, int employeeId, double salary, string department, double bonus)
        : base(employeeName, employeeId, salary)
    {
        Department = department;
        Bonus = bonus;
    }
    public override double GetSalary()
    {
        return base.GetSalary() + Bonus;
    }
    public override void DisplayInfo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Parmanent Employee Information");
        Console.WriteLine("______________________________");
        Console.ForegroundColor = ConsoleColor.White;
        base.DisplayInfo();
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Base Salary: {Salary:C}");
        Console.WriteLine($"Bonus: {Bonus:C}");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Month Salary: {GetSalary():C}");
        Console.ResetColor();
    }
}
class ContractEmployee : Employee
{
    public int WorkHours { get; set; }
    public double PaidbyHours { get; set; }
    public ContractEmployee(string employeeName, int employeeId, int workHours, double paidbyHours)
        : base(employeeName, employeeId, 0)
    {
        WorkHours = workHours;
        PaidbyHours = paidbyHours;
    }
    public override double GetSalary()
    {
        return WorkHours * PaidbyHours;
    }
    public override void DisplayInfo()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Contract Employee Information");
        Console.WriteLine("______________________________");
        Console.ForegroundColor = ConsoleColor.Yellow;
        base.DisplayInfo();
        Console.WriteLine($"Work Hours: {WorkHours}H");
        Console.WriteLine($"Payment per Hour: {PaidbyHours:C}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Total Salary: {GetSalary():C}");
        Console.ResetColor();
    }
}
class EmployeeManagementSystem
{
    static void Main()
    {
        DrawHeader();
        ParmanentEmployee parmanentEmployee = new ParmanentEmployee("Maksud", 22103265, 7000, "Software Development", 1000);
        ContractEmployee contractEmployee = new ContractEmployee("Max", 11003290, 5, 1000);
        parmanentEmployee.DisplayInfo();
        contractEmployee.DisplayInfo();
        Console.ResetColor();
        Console.ReadKey();
    }
    static void DrawHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("=====================================");
        Console.WriteLine("      Employee Management System      ");
        Console.WriteLine("=====================================");
        Console.ResetColor();
    }
}

