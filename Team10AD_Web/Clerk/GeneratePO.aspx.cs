using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.Model;
using Team10AD_Web.DTO;

namespace Team10AD_Web.Clerk
{
    public partial class GeneratePO : System.Web.UI.Page
    {


        List<Catalogue> listSource;
        protected void Page_Load(object sender, EventArgs e)
        {
           listSource = (List<Catalogue>)Session["Shortfall"];
            lblTag.Visible = false;
             btnAddItem.Visible = false;
            lblTest.Text = "";

            if (!IsPostBack)
            {
                        
                dataRefresh();
            }
        
        }

        protected void dataRefresh()
        {
            repeaterItems.DataSource = listSource;
            repeaterItems.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Show Label with Item Description
            string itemQuery = txtItemCode.Text.ToUpper();
           string description = PurvaBizLogic.GetDescriptionFromItemCode(itemQuery);
            //lblDescription.Text = description;
            //Have check if duplicate item
            if (!checkDuplicates(itemQuery))
            {
                if (!String.IsNullOrEmpty(description))
                {
                    lblTag.Text = "Description: "+ description;
                    lblTag.Visible = true;
                    btnAddItem.Visible = true;

                }
                else
                {
                    lblTag.Text = "No such item";
                    lblTag.Visible = true;

                }
            }
            else
            {
                lblTag.Text = "Item already in list ";
                lblTag.Visible = true;
            }


        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            listSource.Add(PurvaBizLogic.GetItemByCode(txtItemCode.Text));
            Session["Shortfall"] = listSource;
            lblTag.Visible = false;
            txtItemCode.Text = "";
            dataRefresh();
        }
      

        protected void repeaterItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                listSource.RemoveAt(Convert.ToInt32(e.CommandArgument));
                Session["Shortfall"] = listSource;
                dataRefresh();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void btnGeneratePO_Click(object sender, EventArgs e)
        {
            Page.Validate("Supplier1");
            Page.Validate("Supplier2");
            Page.Validate("Supplier3");
            //Check all non-zero qty is above Min Order qty - Check done in iterateItems()
            List<POIntermediate> poList = iterateItems();

            //Generate PO DTO
            if (Page.IsValid)
            {
                
                //Generate requisitions
                             //TEST
                //string test = PurvaBizLogic.SavePOInfo(poList);
                //lblTest.Text = test;
                int storeStaffID = (int)Session["clerkid"];
               // if (PurvaBizLogic.SavePOInfo(poList, storeStaffID))
               // {
                //    //Response.Redirect("PurchaseOrderPage.aspx");
                //}
            }

            

        }
        protected List<POIntermediate> iterateItems()
        {

            List<POIntermediate> poList = new List<POIntermediate>();
            string itemCode = "";
            string firstSupName = "";
            string secondSupName = "";
            string thirdSupName = "";
            int firstSupQty = 0;
            int secondSupQty =0;
            int thirdSupQty = 0;

            foreach (RepeaterItem item in repeaterItems.Items)
            {
                //Get Item Code
                itemCode = ((Label)item.FindControl("lblItemCode")).Text;
                
                //Get 1st supplier quantity, show error msg if qty<minOrderQty'
                
                bool result1 = Int32.TryParse(((TextBox)item.FindControl("txtSupp1")).Text, out firstSupQty);
                if (result1)
                {
                    if (checkAboveMinQty(itemCode, firstSupQty) && firstSupQty > 0)
                    {
                        POIntermediate temp1 = new POIntermediate();
                        //Get 1st supplier name
                        firstSupName = ((Label)item.FindControl("lblHeaderS1")).Text.Substring(9, 4);

                        //Make 1st DTO
                        temp1.ItemCode = itemCode;
                        temp1.SupplierName = firstSupName;
                        temp1.Quantity = firstSupQty;

                        //Push to list
                        poList.Add(temp1);
                    }
                    else
                    {
                        ((Label)item.FindControl("lblMinQty1")).Visible = true;
                    }
                }
                
               
                //Get 2nd supplier quantity
         
                bool result2 = Int32.TryParse(((TextBox)item.FindControl("txtSupp2")).Text, out secondSupQty);
                if (result2)
                {
                    POIntermediate temp2 = new POIntermediate();
                    //Get 2nd supplier name
                    secondSupName = ((Label)item.FindControl("lblHeaderS2")).Text.Substring(9, 4);

                    if (checkAboveMinQty(itemCode, secondSupQty) && secondSupQty > 0)
                    {
                        //Make 2nd DTO
                        temp2.ItemCode = itemCode;
                        temp2.SupplierName = secondSupName;
                        temp2.Quantity = secondSupQty;
                        //Push to list
                        poList.Add(temp2);
                    }
                    else
                    {
                        ((Label)item.FindControl("lblMinQty2")).Visible = true;
                    }
                }
                     
                //Get 3rd supplier quantity
            
                bool result3 = Int32.TryParse(((TextBox)item.FindControl("txtSupp3")).Text, out thirdSupQty);
                if (result3)
                {
                    POIntermediate temp3 = new POIntermediate();

                    //Get 3rd supplier name
                    thirdSupName = ((Label)item.FindControl("lblHeaderS3")).Text.Substring(9, 4);

                    if (checkAboveMinQty(itemCode, thirdSupQty) && thirdSupQty > 0)
                    {
                        //Make 3rd DTO
                        temp3.ItemCode = itemCode;
                        temp3.SupplierName = thirdSupName;
                        temp3.Quantity = thirdSupQty;
                        //Push to list
                        poList.Add(temp3);
                    }
                    else
                    {
                        ((Label)item.FindControl("lblMinQty3")).Visible = true;
                    }
                }

            }
            //lblTest.Text += String.Format("ItemCode: "+itemCode+"1stName: "+firstSupName+"1stQty"+firstSupQty+"2ndName:"+secondSupName+"2ndQty"+secondSupQty+"3rdName:"+thirdSupName+"3rdqty"+thirdSupQty) ;
            return poList;
        }
        protected bool checkDuplicates(string itemCode)
        {
            bool isDuplicate = false;
            //Iterate list in sessionState
            foreach (Catalogue item in listSource)
            {
                if (itemCode==item.ItemCode)
                {
                    isDuplicate = true;
                }
            }
            return isDuplicate;
        }
        protected bool checkAboveMinQty(string itemCode,  int qty)
        {
            bool isAboveMin = false;
            int? minOrderQty = 0;
            minOrderQty = PurvaBizLogic.GetMinOrderQty(itemCode);
            if (qty>= minOrderQty)
            {
                isAboveMin = true;
            }
            return isAboveMin;
        }

           }
}