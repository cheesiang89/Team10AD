using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;
using Team10AD_Web.App_Code.DTO;
namespace Team10AD_Web.App_Code {
    /// <summary>
    /// Summary description for BusinessLogic
    /// </summary>
    public static class PurvaBizLogic
    {


        public static Supplier GetSupplier(string supplierCode)
        {
            using (Team10ADModel tm = new Team10ADModel())
            {
                List<Supplier> result = tm.Suppliers.Where(x => x.SupplierCode == supplierCode).ToList();
                return result[0];
            }

        }

        public static List<Supplier> ShowSuppliers()
        {
            using (Team10ADModel tm = new Team10ADModel())
            {
                return tm.Suppliers.OrderBy(x => x.SupplierName).ToList();
            }
        }
        public static string GetDescriptionFromItemCode(string query)
        {
            string description = "";
            try
            {
                using (Team10ADModel tm = new Team10ADModel())
                {
                    description = tm.Catalogues.Where(x => x.ItemCode == query).Select(x => x.Description).First();
                    return description;
                }
            }
            catch (Exception)
            {

                return description;
            }
        }
        public static List<Catalogue> GetLowStockByStatus(string status)
        {
            using (Team10ADModel tm = new Team10ADModel())
            {
                return tm.Catalogues.Where(x => x.ShortfallStatus == status).Select(x => x).ToList();
            }

        }
        public static Catalogue GetItemByCode(string itemCode)
        {
            using (Team10ADModel tm = new Team10ADModel())
            {
                return tm.Catalogues.Where(x => x.ItemCode == itemCode).Select(x => x).First();
            }

        }
        public static void CreatePO()
        {
            //Get all data

            //1. Find unique suppliers
            //2. Create no of PO
            //3. Create PODetail objects -> Create PO

            //Create PO records

            //Update Catalogue "Shorfall" status

        }
        public static void SavePOInfo(List<POIntermediate> poList)
        {
            HashSet<string> supSet = new HashSet<string>();
            //Save supplier names in HashSet
            foreach (var item in poList)
            {
                supSet.Add(item.SupplierName);
            }
            //Create different PO objects depending on suppliers
            int count = supSet.Count;
            //TODO: Iterate through hashset to createPO 
            //PODetails: ItemCode,Quantity, UnitPrice, Status


            //Update the "Shorfall" status
        }

    }
}