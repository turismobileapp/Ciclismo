<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Presentacion._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Ciclismo
    </h2>
    <table align="center" style=" width: 70%;">
        <tr>
            <td> 
                <br />                           
                <asp:GridView ID="gv_ciclistas" runat="server" AutoGenerateColumns="False"
                    Width="100%" AllowPaging="True" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="Nombres" HeaderText=" NOMBRE " />
                        <asp:BoundField DataField="Apellidos" HeaderText=" APELLIDO" />
                        <asp:BoundField DataField="Edad" HeaderText=" EDAD " />
                        <asp:BoundField DataField="Nombre" HeaderText=" EQUIPO " />                        
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>                                                      
            </td>
        </tr>
    </table>
</asp:Content>
