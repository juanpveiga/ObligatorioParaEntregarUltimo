<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="listaRodajesMayorA.aspx.cs" Inherits="obligTallerObjWeb.listaRodajesMayorA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Listado de Rodajes Mayor a un Monto</h1>

    <asp:Label ID="LblMonto" runat="server" Text="Ingrese monto :"></asp:Label>
    <asp:TextBox ID="TxtMonto" runat="server"></asp:TextBox><br />

      <asp:GridView ID="grillaRodajesMayorA" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NroIden" HeaderText="Numero"></asp:BoundField>
            <asp:BoundField DataField="FechaInicioGrilla" HeaderText="FechaIni"></asp:BoundField>
            
            <asp:BoundField DataField="NombreObra" HeaderText="Obra"></asp:BoundField>
            <asp:BoundField DataField="NombreLugar" HeaderText="Lugar"></asp:BoundField>
            <asp:BoundField DataField="Costo" HeaderText="Costo"></asp:BoundField>
            
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnBuscar" runat="server" Text="Button" OnClick="btnBuscar_Click"/>

</asp:Content>
