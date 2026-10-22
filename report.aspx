<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="Viman.report" EnableEventValidation="false" %>

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
   
     <div class="container">
        <div class="row">
            <div class="column">
                <h2>Flight Search Report</h2>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="column">
                <form id="form2" runat="server">                 

                    <asp:GridView ID="gridview1" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="FlightWay" HeaderText="Trip Type" />
                            <asp:BoundField DataField="FromCity" HeaderText="From" />
                            <asp:BoundField DataField="ToCity" HeaderText="To" />
                            <asp:BoundField DataField="FromDate" HeaderText="Departure" />
                            <asp:BoundField DataField="ToDate" HeaderText="Return" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                            <asp:BoundField DataField="Adult" HeaderText="Adult" />
                            <asp:BoundField DataField="Child" HeaderText="Child" />
                            <asp:BoundField DataField="Infant" HeaderText="Infant" />
                            <asp:BoundField DataField="FlightClass" HeaderText="Class" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />
                        </Columns>
                    </asp:GridView>

                </form>

            </div>
        </div>
        
    </div>
   
</body>
</html>
