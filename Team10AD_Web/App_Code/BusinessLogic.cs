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

    public string GetEmployeeName(int employeeID)
    {
        string empName = tm.Employees.Where(x => x.EmployeeID == employeeID).Select(eid=>eid.Name).First();
        return empName;
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

    public int ShowCollectionPointID(int employeeID)
    {
        //Employee emp = GetEmployee(employeeID);
        employeeID = 61;
        string departmentCode = tm.Employees.Where(x => x.EmployeeID == employeeID).Select(dc => dc.DepartmentCode).First();
        Department department = tm.Departments.Where(x => x.DepartmentCode == departmentCode).First();
        return (int) department.PointID;
    }

    public string ShowCollectionPointName(int employeeID)
    {
        //Employee emp = GetEmployee(employeeID);
        employeeID = 61;
        string departmentCode = tm.Employees.Where(x => x.EmployeeID == employeeID).Select(dc => dc.DepartmentCode).First();
        Department department = tm.Departments.Where(x => x.DepartmentCode == departmentCode).First();
        int pointID = (int)department.PointID;
        CollectionPoint collectionPoint = tm.CollectionPoints.Where(x => x.PointID == pointID).First();
        return collectionPoint.PointName;
    }
}