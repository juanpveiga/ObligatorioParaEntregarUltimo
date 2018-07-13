<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="CalendarioDeRodajes.aspx.cs" Inherits="obligTallerObjWeb.CalendarioDeRodajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Calendario de Rodajes</h1>

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
    <asp:GridView ID="grillaRodajes" runat="server" OnSelectedIndexChanged="grillaRodajes_SelectedIndexChanged" DataKeyNames="NroIden" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
            <asp:BoundField DataField="NroIden" HeaderText="NroIden"></asp:BoundField>
            <asp:BoundField DataField="Tipo" HeaderText="Tipo"></asp:BoundField>
            <asp:BoundField DataField="NomObra" HeaderText="NombreObra"></asp:BoundField>
            <asp:BoundField DataField="NomLugar" HeaderText="NombreLugar"></asp:BoundField>
            <asp:BoundField DataField="FechaInicioGrilla" HeaderText="FechaInicio"></asp:BoundField>
            <asp:BoundField DataField="FechaFinGrilla" HeaderText="FechaFin"></asp:BoundField>
            <asp:BoundField DataField="Hora" HeaderText="Hora"></asp:BoundField>
            <asp:BoundField DataField="Duracion" HeaderText="Duracion"></asp:BoundField>
            <asp:BoundField DataField="RealizadoGrilla" HeaderText="Realizado"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    <br />
    <asp:PlaceHolder ID="plcObraRodaje" runat="server">
        <asp:Label ID="lblObraRod" runat="server" Text="Obra del Rodaje"></asp:Label>
        <asp:GridView ID="grillaObra" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                <asp:BoundField DataField="FechaIniGrilla" HeaderText="FechaInicio"></asp:BoundField>
                <asp:BoundField DataField="FechaPromFinGrilla" HeaderText="FechaPromFin"></asp:BoundField>
                <asp:BoundField DataField="CostoBase" HeaderText="CostoBase"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </asp:PlaceHolder>
    <br />
    <asp:PlaceHolder ID="plcLugarRodaje" runat="server">
        <asp:Label ID="lblLugarRod" runat="server" Text="Lugar del Rodaje"></asp:Label>
        <asp:GridView ID="grillaLugar" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="NomLugar" HeaderText="Nombre"></asp:BoundField>
                <asp:BoundField DataField="Direccion" HeaderText="Direccion"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </asp:PlaceHolder>
    <br />
    <asp:PlaceHolder ID="plcUsuarioRodaje" runat="server">
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario que realizo la ultima modificacion"></asp:Label>
        <asp:GridView ID="grillaUsuario" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Cedula" HeaderText="Cedula"></asp:BoundField>
                <asp:BoundField DataField="PrimerNom" HeaderText="Nombre"></asp:BoundField>
                <asp:BoundField DataField="PrimerAp" HeaderText="Apellido"></asp:BoundField>
                <asp:BoundField DataField="Perfil" HeaderText="Perfil"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </asp:PlaceHolder>
    <br />
    <asp:PlaceHolder ID="plcEmpleadoRodaje" runat="server">
        <asp:Label ID="lblEmpRod" runat="server" Text="Empleados del Rodaje"></asp:Label>
        <asp:GridView ID="grillaEmpleados" runat="server"></asp:GridView>
    </asp:PlaceHolder>
    <asp:Label ID="lblMensajeEmp" runat="server" Text=""></asp:Label>
</asp:Content>
