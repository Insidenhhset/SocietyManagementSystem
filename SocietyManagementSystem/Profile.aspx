﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SocietyManagementSystem.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" />



    <style>
        .custom-heading {
            font-size: 2rem;
            font-weight: bold;
            margin-bottom: 1rem;
        }

        .form-container {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            margin-top: 20px;
        }

        .form-label {
            font-weight: 600;
            margin-bottom: 0.5rem;
        }

        .form-control {
            border-radius: 8px;
            padding: 10px;
        }

        .btn-custom {
            padding: 10px 20px;
            font-size: 1rem;
            border-radius: 8px;
        }

        .action-bar {
            background-color: #e9ecef;
            padding: 10px 15px;
            border-radius: 8px;
            margin-top: 20px;
        }

        .password-wrapper {
            position: relative;
        }

        .toggle-password {
            position: absolute;
            top: 50%;
            right: 10px;
            transform: translateY(-50%);
            cursor: pointer;
            color: #6c757d;
        }

        .toggle-password:hover {
            color: #495057;
        }

        /* Toast positioning */
        .toast-container {
            position: fixed;
            top: 20px;
            right: 20px;
            z-index: 1055;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        <h1 class="custom-heading">Profile</h1>

        <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb pl-0 bg-transparent">
                <li class="breadcrumb-item active" aria-current="page">Edit Profile</li>
            </ol>
        </nav>

        <div class="d-flex justify-content-between align-items-center action-bar w-50">
            <h4 class=" m-0">Edit Profile</h4>
        </div>

        <div class="form-container mt-0 w-50">
            <div class="mb-3">
                <label for="TextBox1" class="form-label">Name</label>
                <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Enter name" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox2" class="form-label">Email</label>
                <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Enter email" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Save"  onclick="Button1_Click" />


            </div>
        </div>
    </div>
</asp:Content>
