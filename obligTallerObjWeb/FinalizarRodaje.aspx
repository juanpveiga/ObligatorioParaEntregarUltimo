<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="FinalizarRodaje.aspx.cs" Inherits="obligTallerObjWeb.FinalizarRodaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Finalizar Rodaje</h1>

    <asp:Label ID="lblFiltros" runat="server" Text="Seleccione los filtros"></asp:Label>
    <br />
    <asp:CheckBoxList ID="chkFiltros" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>Tipo</asp:ListItem>
        <asp:ListItem>Obra</asp:ListItem>
        <asp:ListItem>Fechas</asp:ListItem>
        <asp:ListItem>Lugar</asp:ListItem>
    </asp:CheckBoxList>


    <br />
    <asp:PlaceHolder ID="plcTipo" runat="server">
        <asp:DropDownList ID="DDLTipo" runat="server">
            <asp:ListItem>Estudio</asp:ListItem>
            <asp:ListItem>Locacion</asp:ListItem>
        </asp:DropDownList>
    </asp:PlaceHolder>
    <br />
    <br />
    <asp:PlaceHolder ID="plcObra" runat="server">
        <asp:DropDownList ID="DDLObra" runat="server"></asp:DropDownList>
    </asp:PlaceHolder>
    <br />
    <br />
    <asp:PlaceHolder ID="plcFecha" runat="server">
        <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Desde"></asp:Label>
        <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha Hasta"></asp:Label>
        <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date"></asp:TextBox>
    </asp:PlaceHolder>
    <br />
    <br />
    <asp:PlaceHolder ID="plcLugar" runat="server">
        <asp:DropDownList ID="DDLLugar" runat="server"></asp:DropDownList>
    </asp:PlaceHolder>
    <br />
    <br />
    <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="btnMostrar_Click" />
    <br />
    <br />
    <asp:GridView ID="grillaRodajes" runat="server" DataKeyNames="NroIden" OnRowDeleting="grillaRodajes_RowDeleting" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Finalizar"></asp:CommandField>
            <asp:BoundField DataField="Tipo" HeaderText="Tipo"></asp:BoundField>
            <asp:BoundField DataField="NomObra" HeaderText="NombreObra"></asp:BoundField>
            <asp:BoundField DataField="NomLugar" HeaderText="NombreLugar"></asp:BoundField>
            <asp:BoundField DataField="FechaInicioGrilla" HeaderText="FechaInicio"></asp:BoundField>
            <asp:BoundField DataField="Hora" HeaderText="Hora"></asp:BoundField>
            <asp:BoundField DataField="Duracion" HeaderText="Duracion"></asp:BoundField>
            <asp:BoundField DataField="RealizadoGrilla" HeaderText="Realizado"></asp:BoundField>
            <asp:BoundField DataField="NroIden" HeaderText="NroIden"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</asp:Content>
