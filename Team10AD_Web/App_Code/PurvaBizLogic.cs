﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;

/// <summary>
/// Summary description for BusinessLogic
/// </summary>
public class PurvaBizLogic
{
    Team10ADModel tm = new Team10ADModel();

    public Supplier GetSupplier(string supplierCode)
    {
        List<Supplier> result = tm.Suppliers.OrderBy(x=>x.SupplierName).Where(x => x.SupplierCode == supplierCode).ToList();
        return result[0];
    }

    public List<Supplier> ShowSuppliers()
    {
        return tm.Suppliers.OrderBy(x => x.SupplierName).ToList();
    }
}