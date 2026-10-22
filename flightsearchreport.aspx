<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="flightsearchreport.aspx.cs" Inherits="Viman.flightsearchreport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>

   

   
    <style>
     body {
         font-family: Arial;
     }

     .grid {
         width: 100%;
         border-collapse: collapse;
     }

         .grid th {
             background: #007bff;
             color: white;
             padding: 10px;
         }

         .grid td {
             padding: 8px;
             border: 1px solid #ddd;
         }
 </style>

 
</head>
<body>
    <form id="form1" runat="server">
          <div class="main-panel">
                <div class="content-wrapper">


                    <asp:ScriptManager ID="ScriptManager1" runat="server" />

                    <div class="row">
                        <div class="col-md-4 grid-margin stretch-card">
                            <div class="mobres">
                                <label for="txt_agent" style="margin-bottom: 10px;">Search By Booking ID:</label>
                                <div class="d-flex" style="flex: 1; gap: 10px;">

                                    <asp:TextBox ID="txt_bookingid" class="form-control form-control-lg txt_boxcss" runat="server" placeholder="Enter Booking ID"></asp:TextBox>

                                    <asp:Button ID="Button3" runat="server" Text="Search" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" Style="margin-top: auto;" OnClick="Button1_Click" />
                                    
                                </div>
                            </div>
                        </div>

                                               <div class="col-md-4 grid-margin stretch-card">
    <div class="mobres">
        <label for="txt_agent" style="margin-bottom: 10px;">Search By WebSite:</label>
        <div class="d-flex" style="flex: 1; gap: 10px;">

           <asp:DropDownList runat="server" ID="ddlwebsite" class="txt_boxcss" AutoPostBack="true" OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged"  >
                <asp:ListItem Value="0">Select Website</asp:ListItem>
               <asp:ListItem Value="Parallelfares">Parallelfares</asp:ListItem>
               <asp:ListItem Value="Faresbridge">Faresbridge</asp:ListItem>
               <asp:ListItem Value="Faresgator">Faresgator</asp:ListItem>
               <asp:ListItem Value="fareschoices">Fareschoices</asp:ListItem>
                <asp:ListItem Value="faresbracket">Faresbracket</asp:ListItem>
                <asp:ListItem Value="airfaretool">Airfaretool</asp:ListItem>
                <asp:ListItem Value="flightsearchradar">Flightsearchradar</asp:ListItem>

           </asp:DropDownList>

           
           
        </div>
    </div>
</div>

                        <div class="col-md-8 grid-margin stretch-card">
                            <div class="mobres">
                                <label for="txt_pnr" style="margin-bottom: 10px;">Search By Date:</label>
                                <div class="d-flex" style="gap: 10px;">
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtfdate" Format="dd-MM-yyyy" ID="CalendarExtender3"></ajaxToolkit:CalendarExtender>
                                    <asp:TextBox ID="txtfdate" runat="server" class="form-control form-control-lg txt_boxcss" placeholder="Enter first date"></asp:TextBox>

                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="txtscdate" Format="dd-MM-yyyy" ID="CalendarExtender4"></ajaxToolkit:CalendarExtender>
                                    <asp:TextBox ID="txtscdate" runat="server" class="form-control form-control-lg txt_boxcss" placeholder="Enter second date"></asp:TextBox>

                                    <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" OnClick="btn_fdate_Click" />
                                    <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" OnClick="Button2_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 grid-margin stretch-card">
                            <div class="card">
                                <div class="card-body">
                                    <p class="card-title" style="margin-bottom: 5px;">Flight Report</p>
                                    <div class="table-responsive">

                                        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="100000" />
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="id" AllowPaging="true" EnableViewState="false"
                                            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" CssClass="grid">
                                              <RowStyle BackColor="#bebee9" />
                                       <AlternatingRowStyle BackColor="#7080d8" />
                                            <Columns>
                                                <asp:BoundField DataField="BookingId" HeaderText="BookingId" />  
                                                 <asp:BoundField DataField="SiteCode" HeaderText="Website Name" />  
                                                <asp:BoundField DataField="FullName" HeaderText="Name" />
                                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" />
                                                <asp:BoundField DataField="DepDate" HeaderText="Departure Date" DataFormatString="{0:dd-MM-yyyy}" />
                                                <asp:TemplateField HeaderText="Return Date">
                                                    <ItemTemplate>
                                                        <%# Eval("RetDate") == DBNull.Value || Convert.ToDateTime(Eval("RetDate")) == DateTime.MinValue 
                                                            ? "" 
                                                             : Convert.ToDateTime(Eval("RetDate")).ToString("dd-MM-yyyy") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                                <asp:BoundField DataField="FinalTotalAmt" HeaderText="Amont" />
                                                <asp:BoundField DataField="FromCity" HeaderText="From City" />
                                                <asp:BoundField DataField="ToCity" HeaderText="To City" />
                                                <asp:BoundField DataField="Timestamp" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />
                                            </Columns>
                                            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Previous" NextPageText="Next" LastPageText="Last" />


                                        </asp:GridView>

                                        <asp:Label ID="Label2" runat="server" Text="Choose Pages No." Font-Bold="True"
                                            ForeColor="#7080d8"></asp:Label>
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">

                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                        </asp:DropDownList>





                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" OnClick="btnExport_Click" />



                </div>
                <!--Popup starts-->



            </div>
    </form>
</body>
</html>
