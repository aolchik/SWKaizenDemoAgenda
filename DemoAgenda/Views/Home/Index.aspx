<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewBag.Message %></h2>
    <p>
        Para adicionar um evento clique em <%: Html.ActionLink("Novo evento", "Create", "Evento")%>
    </p>

    <table>
    <tr>
    <th>Data</th>
    <th>Título</th>
    </tr>
    <% foreach (var item in (IEnumerable<DemoAgenda.Models.Evento>)Model)
       { %>
    <tr>
        <td><%= Html.DisplayFor(c => item.Data) %></td>
        <td><%= Html.DisplayFor(c => item.Titulo) %></td>
    </tr>
    <% } %>

</table>

</asp:Content>

 