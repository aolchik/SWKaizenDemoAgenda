<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Demo Agenda
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewBag.Message %></h2>
    <p>
        <%= Html.ValidationSummary() %>
        <% using (Html.BeginForm())
           { %>
            <p>Data: <%= Html.TextBox("Data") %></p>
            <p>Hora: <%= Html.TextBox("Hora") %></p>
            <p>Título: <%= Html.TextBox("Titulo") %></p>
            <p>Local: <%= Html.TextBox("Local") %></p>
            <p>Descrição: <%= Html.TextArea("Descricao") %></p>
            <input type="submit" value="Salvar Evento" />
        <% } %>
    </p>
</asp:Content>

