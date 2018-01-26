using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.Model;

/// <summary>
/// Summary description for BusinessLogic
/// </summary>
namespace Team10AD_Web
{
    public class BusinessLogic
    {
        Team10ADModel tm = new Team10ADModel();

        public Employee GetEmployee(int employeeID)
        {
            Employee emp = tm.Employees.Where(x => x.EmployeeID == employeeID).First();
            return emp;
        }

        public string GetEmployeeName(int? employeeID)
        {
            string empName = tm.Employees.Where(x => x.EmployeeID == employeeID).Select(eid => eid.Name).First();
            return empName;
        }

        public void SelectCollection(string pointID, int employeeid)
        {
            string departmentCode = tm.Employees.Where(x => x.EmployeeID == employeeid).Select(dc => dc.DepartmentCode).First();
            Department department = tm.Departments.Where(x => x.DepartmentCode == departmentCode).First();
            department.PointID = Int32.Parse(pointID);
            department.RepresentativeID = employeeid;
            tm.SaveChanges();
        }

        public int ShowCollectionPointID(int employeeID)
        {
            string departmentCode = tm.Employees.Where(x => x.EmployeeID == employeeID).Select(dc => dc.DepartmentCode).First();
            Department department = tm.Departments.Where(x => x.DepartmentCode == departmentCode).First();
            return (int)department.PointID;
        }

        public string ShowCollectionPointName(int employeeID)
        {
            string departmentCode = tm.Employees.Where(x => x.EmployeeID == employeeID).Select(dc => dc.DepartmentCode).First();
            Department department = tm.Departments.Where(x => x.DepartmentCode == departmentCode).First();
            int pointID = (int)department.PointID;
            CollectionPoint collectionPoint = tm.CollectionPoints.Where(x => x.PointID == pointID).First();
            return collectionPoint.PointName;
        }

        public object DisbursementRecords()
        {
            var qry = (from d in tm.Disbursements orderby d.Status descending orderby d.CollectionDate descending select new { d.DisbursementID, d.CollectionDate, d.Department.DepartmentName, d.CollectionPoint.PointName, d.Department.Employee1.Name, d.Status }).ToList();
            return qry;
        }

        public object DisbursementRecordsByDepartment(string employeeDepCode)
        {
            var qry = (from d in tm.Disbursements.Where(x => x.DepartmentCode == employeeDepCode) orderby d.Status descending orderby d.CollectionDate descending select new { d.DisbursementID, d.CollectionDate, d.Department.DepartmentName, d.CollectionPoint.PointName, d.Department.Employee1.Name, d.Status }).ToList();
            return qry;
        }

        public Disbursement GetDisbursement(int disbursementID)
        {
            List<Disbursement> result = tm.Disbursements.Where(x => x.DisbursementID == disbursementID).ToList();
            return result[0];
        }

        public object ShowDisbursementDetails(int disbursementID)
        {
            var qry = (from dd in tm.DisbursementDetails.Where(x => x.DisbursementID == disbursementID) select new { dd.DisbursementID, dd.ItemCode, dd.Catalogue.Description, dd.QuantityRequested, dd.QuantityCollected, dd.Remarks }).ToList();
            return qry;
        }

        public object ShowStockFlow(string itemCode)
        {
            var qry = (from sf in tm.StockFlows.Where(x => x.ItemCode == itemCode) select new { sf.Date, sf.Entity, sf.Adjusted_Quantity, sf.Balance_Quantity }).ToList();
            return qry;
        }

        public Catalogue GetCatalogue(string itemCode)
        {
            List<Catalogue> result = tm.Catalogues.Where(x => x.ItemCode == itemCode).ToList();
            return result[0];
        }

        public object ShowPurchaseOrders()
        {
            var qry = (from p in tm.PurchaseOrders orderby p.Status descending select new { p.POID, p.CreationDate, p.Supplier.SupplierName, p.Status }).ToList();
            return qry;
        }

        public PurchaseOrder GetPurchaseOrder(int POID)
        {
            List<PurchaseOrder> result = tm.PurchaseOrders.Where(x => x.POID == POID).ToList();
            return result[0];
        }

        public List<PurchaseOrderDetailsView> ShowPurchaseOrderDetail(int itemCode)
        {
            return tm.PurchaseOrderDetailsViews.Where(x=>x.ItemCode == itemCode.ToString()).ToList();
        }

    }
}
