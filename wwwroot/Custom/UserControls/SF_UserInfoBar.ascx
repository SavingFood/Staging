<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SF_UserInfoBar.ascx.cs" Inherits="Custom_UserControls_SF_UserInfoBar" %>
<asp:HyperLink ID="registerLink" runat="server" CssClass="SkinObject" rel="nofollow" />
<div class="registerGroup" runat="server" id="registerGroup">
    <ul class="buttonGroup">
        <li class="userMessages alpha" runat="server" id="messageGroup">
            <asp:HyperLink ID="messageLink" runat="server" /></li>
        <li class="userNotifications omega" runat="server" id="notificationGroup">
            <asp:HyperLink ID="notificationLink" runat="server" /></li>
        <li class="userDisplayName">
            <asp:HyperLink ID="enhancedRegisterLink" runat="server" rel="nofollow" /></li>
        <li class="userProfileImg" runat="server" id="avatarGroup">
            <asp:HyperLink ID="avatar" runat="server" /></li>
    </ul>
</div>
