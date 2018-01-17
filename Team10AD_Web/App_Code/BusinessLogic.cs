using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;

/// <summary>
/// Summary description for BusinessLogic
/// </summary>
public class BusinessLogic
{
     Team10ADModel tm = new Team10ADModel();
 
    public Employee GetEmployee(int employeeID)
    {
        Employee emp = tm.Employees.Where(x => x.EmployeeID == employeeID).First();
        return emp;
    }

    public void SelectCollection(string pointID)
    {
        //Employee emp = GetEmployee(employeeID);
        int employeeID = 61;
        string representativeID = "61";
        string departmentCode = tm.Employees.Where(x => x.EmployeeID == employeeID).Select(dc => dc.DepartmentCode).First();
        Department department = tm.Departments.Where(x => x.DepartmentCode == departmentCode).First();
        department.PointID = Int32.Parse(pointID);
        department.RepresentativeID = Int32.Parse(representativeID);
        tm.SaveChanges();
    }

    public int ShowCollectionPoint(int employeeID)
    {
        //Employee emp = GetEmployee(employeeID);
        employeeID = 61;
        string departmentCode = tm.Employees.Where(x => x.EmployeeID == employeeID).Select(dc => dc.DepartmentCode).First();
        Department department = tm.Departments.Where(x => x.DepartmentCode == departmentCode).First();
        return (int) department.PointID;
    }
}