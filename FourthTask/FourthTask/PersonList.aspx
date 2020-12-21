<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="PersonList.aspx.cs" Inherits="FourthTask.PersonList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:Button class="btn btn-primary" ID="BlockUser" runat="server" Text="Block" OnClick="BlockUser_Click" />
            <asp:Button class="btn btn-primary" ID="UnblockUser" runat="server" Text="Unblock" OnClick="UnblockUser_Click" />
            <asp:Button class="btn btn-danger" ID="DeleteUser" runat="server" Text="Delete" OnClick="DeleteUser_Click" />
            <asp:GridView ID="PersonGridView" runat="server" GridLines="None" class="table" 
            SelectMethod="GetPersons" AutoGenerateColumns="False" DataKeyNames="PersonID">
            <Columns>
                <asp:templatefield>
                    <HeaderTemplate>
                        <asp:checkbox ID="SelectCheckboxAll" OnCheckedChanged="ChckedChanged" AutoPostBack="true"
                         CssClass="gridCB" runat="server"></asp:checkbox>
                    </HeaderTemplate>
                    <itemtemplate>
                        <asp:checkbox ID="SelectCheckbox"
                         CssClass="gridCB" runat="server"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
                <asp:TemplateField>
                    <HeaderTemplate>ID</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="PersonIDLabel" runat="server" Text='<%# Eval("PersonID")%>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PersonName" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="RegisterDate" HeaderText="Register Date" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="LastLoginDate" HeaderText="Last Login Date" DataFormatString="{0:dd.MM.yyyy}"/>
                <asp:TemplateField>
                    <HeaderTemplate>Blocked</HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="BlockedCheckbox" runat="server" Enabled="false" Checked='<%# Eval("Blocked").ToString().ToLower().Equals("true")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
         </div>
    </section>
</asp:Content>