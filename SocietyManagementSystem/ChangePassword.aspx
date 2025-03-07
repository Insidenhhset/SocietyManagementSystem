<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SocietyManagementSystem.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" />
     <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>


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
                <li class="breadcrumb-item active" aria-current="page">Change Password</li>
            </ol>
        </nav>

        <div class="d-flex justify-content-between align-items-center action-bar w-50">
            <h4 class=" m-0">Change Password</h4>
        </div>

        <div class="form-container mt-0 w-50">
           <div class="mb-3">
    <label for="TextBox1" class="form-label">Current Password</label>
    <div class="password-wrapper">
        <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
        <i class="fas fa-eye toggle-password" onclick="togglePassword('<%= TextBox1.ClientID %>', this)"></i>
    </div>
</div>

<div class="mb-3">
    <label for="TextBox2" class="form-label">New Password</label>
    <div class="password-wrapper">
        <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
        <i class="fas fa-eye toggle-password" onclick="togglePassword('<%= TextBox2.ClientID %>', this)"></i>
    </div>
</div>

<div class="mb-3">
    <label for="TextBox3" class="form-label">Confirm New Password</label>
    <div class="password-wrapper">
        <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
        <i class="fas fa-eye toggle-password" onclick="togglePassword('<%= TextBox3.ClientID %>', this)"></i>
    </div>
</div>


            <div class="mb-3">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="Button1_Click" />

            </div>
        </div>
    </div>
   
<script>
    function validatePasswords() {
        const newPassword = document.getElementById('<%= TextBox2.ClientID %>').value;
        const confirmPassword = document.getElementById('<%= TextBox3.ClientID %>').value;

        if (newPassword !== confirmPassword) {
            alert("Passwords do not match!");
            return false; // Prevent form submission
        }
        return true; // Proceed with submission
    }

    function togglePassword(inputId, icon) {
        const input = document.getElementById(inputId);

        if (input.type === "password") {
            input.type = "text";
            icon.classList.remove("fa-eye");
            icon.classList.add("fa-eye-slash");
        } else {
            input.type = "password";
            icon.classList.remove("fa-eye-slash");
            icon.classList.add("fa-eye");
        }
    }

</script>

</asp:Content>
