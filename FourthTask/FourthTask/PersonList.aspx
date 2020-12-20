<%@ Page Title="Persons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="PersonList.aspx.cs" Inherits="FourthTask.PersonList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <table> 
                <asp:Repeater ID="rpt" runat="server"
                ItemType="FourthTask.Models.Person" SelectMethod="GetPersons"> 
                    <HeaderTemplate>
                        <tr>
                            <td>ID</td>
                            <td>Name</td>
                            <td>Email</td>
                            <td>RegisterDate</td>
                            <td>LastLoginDate</td>
                            <td>Blocked</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("PersonID")%></td>
                            <td><%# Eval("PersonName")%></td>
                            <td><%# Eval("Email")%></td>
                            <td><%# Eval("RegisterDate")%></td>
                            <td><%# Eval("LastLoginDate")%></td>
                            <td><%# Eval("Blocked")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>  

        </div>
    </section>
</asp:Content>