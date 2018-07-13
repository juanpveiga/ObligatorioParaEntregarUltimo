<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListadoRodajesPorCosto.aspx.cs" Inherits="obligTallerObjWeb.ListadoRodajesPorCosto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Listado de Rodajes por Costo</h1>

    <asp:GridView ID="grillaCostoRodajes" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NroIden" HeaderText="NroIden"></asp:BoundField>
            <asp:BoundField DataField="NomObra" HeaderText="NomObra"></asp:BoundField>
            <asp:BoundField DataField="NomLugar" HeaderText="NomLugar"></asp:BoundField>
            <asp:BoundField DataField="Costo" HeaderText="Costo"></asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
