<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarEquipos.aspx.cs" Inherits="Presentacion.GestionarEquipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:HiddenField ID="hf_id_equipo" runat="server" Visible="False" />
    <h2>
        Gestión de Equipos
    </h2>
    <table align="center" style=" width: 70%;">
        <tr>
            <td> 
                <br />                           
                <asp:GridView ID="gv_equipos" runat="server" AutoGenerateColumns="False"
                    Width="100%" AllowPaging="True" onrowcommand="gv_equipos_RowCommand" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3">
                    <Columns>                        
                        <asp:BoundField DataField="EquipoID" HeaderText=" EQUIPO " />                                                                       
                        <asp:BoundField DataField="Nombre" HeaderText=" NOMBRE " />
                        <asp:BoundField DataField="Descripcion" HeaderText=" DESCRIPCION" />                        
                        <asp:ButtonField CommandName="mod" ButtonType="Button" Text="Modificar" >
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="eli" ButtonType="Button" Text="Eliminar" >
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
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
        <tr>            
            <td align="center">
                <br />
                <asp:Button ID="btn_add_equipo" runat="server" Text="Agregar Equipo" Width="150px" OnClick="btn_add_equipo_Click" />         
            </td>
        </tr>
        <tr>  
            <td align="center">
        <br />
        <asp:Panel ID="P_adi" runat="server" Visible="False" GroupingText="Agregar Ciclista" Width="350px" CssClass="Panel">
            <table style="text-align: left;width:100%">
                <tr>
                    <td style="text-align:right;">
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_nom" runat="server" MaxLength="50" Width="100px" ></asp:TextBox >                            
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="req_nom" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txt_nom" ValidationGroup="add"></asp:RequiredFieldValidator>                   
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        Descripcion:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_des" runat="server" MaxLength="150" Width="100px"></asp:TextBox >                            
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="req_ape" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txt_des" ValidationGroup="add"></asp:RequiredFieldValidator>                   
                    </td>
                </tr>                
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>               
                <tr style="text-align: center;">
                    <td colspan="3">                            
                        <asp:Button ID="btn_add" runat="server" Text="Agregar" onclick="btn_add_Click" ValidationGroup="add"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_can" runat="server" Text="Cancelar" OnClick="btn_can_Click"  CausesValidation="False" />
                    </td>
            </tr>
        </table>
    </asp:Panel>  
      </td>
        </tr>
    </table>
</asp:Content>
