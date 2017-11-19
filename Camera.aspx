<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Camera.aspx.cs" Inherits="Risk_Management_at_Airports.Camera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        <asp:GridView ID="gvKamera" CssClass="footable" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvKamera_SelectedIndexChanged" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:BoundField DataField="Visual_Angle" HeaderText="Visual Angle" />
                <asp:BoundField DataField="Explanation" HeaderText="Explanation" />
            </Columns>
        </asp:GridView>
        <div class="panel panel-default">
            <div class="panel-heading">
                Camera
            </div>
            <div class="panel-body">
                <div class="col-md-12">
                    <asp:TextBox ID="txtId" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div class="col-md-2 lbl">Name *:</div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtAdi" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2 lbl">Location *:</div>
                <div class="col-md-10 text-left">
                    <asp:TextBox ID="txtAdres" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2 lbl">Visual Angle *:</div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtAngle" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2 lbl">Explanation *:</div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtAciklama" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="panel-footer text-right">
                <asp:Button ID="btnYeni" CssClass="btn btn-info" runat="server" Text="New" OnClick="btnYeni_Click" />
                <asp:Button ID="btnKaydet" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnKaydet_Click" />
                <asp:Button ID="btnSil" CssClass="btn btn-danger" runat="server" Text="Delete" OnClick="btnSil_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
