<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DropDownTimeEdit.ascx.cs" Inherits="Custom_UserControls_DropDownTimeEdit" %>
<table>
    <tr>
        <td style="padding: 2px 2px 2px 2px;">
            <dx:ASPxComboBox ID="drpHours" runat="server" EnableViewState="false" ValueType="System.Int32" Width="40px">
                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                </ValidationSettings>
            </dx:ASPxComboBox>
        </td>
        <td style="padding: 2px 2px 2px 2px">
            <dx:ASPxComboBox ID="drpMinutes" runat="server" EnableViewState="false" ValueType="System.Int32" Width="40px">
                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                </ValidationSettings>
            </dx:ASPxComboBox>
        </td>
        <td style="padding: 2px 2px 2px 2px">
            <dx:ASPxComboBox ID="drpAmPm" runat="server" EnableViewState="false" ValueType="System.String" Width="40px">
                <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                </ValidationSettings>
            </dx:ASPxComboBox>
        </td>
    </tr>
</table>
<asp:Literal ID="ltScript" ViewStateMode="Disabled" runat="server"></asp:Literal>
