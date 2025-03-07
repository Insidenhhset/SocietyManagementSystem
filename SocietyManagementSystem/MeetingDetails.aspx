<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="MeetingDetails.aspx.cs" Inherits="SocietyManagementSystem.MeetingDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .meeting-container {
            max-width: 600px;
            margin: 30px auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 12px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        .meeting-header {
            font-size: 24px;
            font-weight: bold;
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }

        .meeting-details {
            font-size: 16px;
            line-height: 1.6;
            color: #555;
        }

        .meeting-details label {
            font-weight: bold;
            color: #222;
        }

        .back-btn {
            display: inline-block;
            margin-top: 20px;
            padding: 10px 15px;
            background-color: #007bff;
            color: white;
            text-decoration: none;
            border-radius: 6px;
        }

        .back-btn:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="meeting-container">
        <div class="meeting-header">Meeting Details</div>
        <div class="meeting-details">
            <p><label>Title:</label> <asp:Label ID="lblTitle" runat="server" /></p>
            <p><label>Date & Time:</label> <asp:Label ID="lblDateTime" runat="server" /></p>
            <p><label>Location:</label> <asp:Label ID="lblLocation" runat="server" /></p>
            <p><label>Agenda:</label> <asp:Label ID="lblAgenda" runat="server" /></p>
        </div>

        <a href="User.aspx" class="back-btn">← Back to Home</a>
    </div>
</asp:Content>

