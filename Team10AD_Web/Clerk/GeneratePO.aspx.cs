using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;
using Team10AD_Web.App_Code.Model;
using Team10AD_Web.App_Code.DTO;

namespace Team10AD_Web.Clerk
{
    public partial class GeneratePO : System.Web.UI.Page
    {


        List<Catalogue> listSource;
        protected void Page_Load(object sender, EventArgs e)
        {
           listSource = (List<Catalogue>)Session["Shortfall"];
            lblTag.Visible = false;
                lblDescription.Visible = false;
            btnAddItem.Visible = false;
            
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
                    lblTag.Text = "Description: ";
                    lblDescription.Text = description;
                    lblTag.Visible = true;
                    lblDescription.Visible = true;
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
            //Generate PO DTO
            List<POIntermediate> poList = iterateItems();
            //Generate requisitions

            //TEST
            //string test = PurvaBizLogic.SavePOInfo(poList);
            //lblTest.Text = test;
            int storeStaffID = (int)Session["clerkid"];
            PurvaBizLogic.SavePOInfo(poList,storeStaffID);
            
        }
        protected List<POIntermediate> iterateItems()
        {

            List<POIntermediate> poList = new List<POIntermediate>();
            string itemCode = "";
            string firstSupName = "";
            string secondSupName = "";
            string thirdSupName = "";
            string firstSupQty = "";
            string secondSupQty = "";
            string thirdSupQty = "";

            foreach (RepeaterItem item in repeaterItems.Items)
            {
                POIntermediate temp1 = new POIntermediate();
                POIntermediate temp2 = new POIntermediate();
                POIntermediate temp3 = new POIntermediate();

                //Get Item Code
                itemCode = ((Label)item.FindControl("lblItemCode")).Text;

                //Get 1st supplier name
                firstSupName = ((Label)item.FindControl("lblHeaderS1")).Text.Substring(9,4);

                //Get 1st supplier quantity
                firstSupQty = ((TextBox)item.FindControl("txtSupp1")).Text;
                if (String.IsNullOrEmpty(firstSupQty))
                {
                    firstSupQty = "0";
                }
                //Make 1st DTO
                temp1.ItemCode = itemCode;
                temp1.SupplierName = firstSupName;
                temp1.Quantity = firstSupQty;
         
                //Get 2nd supplier name
                secondSupName = ((Label)item.FindControl("lblHeaderS2")).Text.Substring(9, 4);

                //Get 2nd supplier quantity
                secondSupQty = ((TextBox)item.FindControl("txtSupp2")).Text;
                if (String.IsNullOrEmpty(secondSupQty))
                {
                    secondSupQty = "0";
                }
                //Make 2nd DTO
                temp2.ItemCode = itemCode;
                temp2.SupplierName = secondSupName;
                temp2.Quantity = secondSupQty;

                //Get 3rd supplier name
                thirdSupName = ((Label)item.FindControl("lblHeaderS3")).Text.Substring(9, 4);

                //Get 3rd supplier quantity
                thirdSupQty = ((TextBox)item.FindControl("txtSupp3")).Text;
                if (String.IsNullOrEmpty(thirdSupQty))
                {
                    thirdSupQty = "0";
                }
                //Make 3rd DTO
                temp3.ItemCode = itemCode;
                temp3.SupplierName = thirdSupName;
                temp3.Quantity = thirdSupQty;

                //Push to list
                poList.Add(temp1);
                poList.Add(temp2);
                poList.Add(temp3);

            }
            //lblTest.Text = String.Format("ItemCode: "+itemCode+"1stName: "+firstSupName+"1stQty"+firstSupQty+"2ndName:"+secondSupName+"2ndQty"+secondSupQty+"3rdName:"+thirdSupName+"3rdqty"+thirdSupQty) ;
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
    }
}