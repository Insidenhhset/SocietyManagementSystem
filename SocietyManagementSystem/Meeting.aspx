<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Meeting.aspx.cs" Inherits="SocietyManagementSystem.Meeting" %>

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
        }

        .form-control {
            border-radius: 8px;
            padding: 10px;
        }

      

        .action-bar {
            background-color: #e9ecef;
            padding: 12px 18px;
            border-radius: 10px;
            margin: 20px auto;
            max-width: 600px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .toast-container {
            position: fixed;
            top: 20px;
            right: 20px;
            
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        <h1 class="custom-heading">Meeting Management</h1>

        <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb bg-transparent">
                <li class="breadcrumb-item"><a href="Admin.aspx">Dashboard</a></li>
                <li class="breadcrumb-item active" aria-current="page">Add Meeting</li>
            </ol>
        </nav>

        <div class="form-container w-50">
            <div class="mb-3">
                <label for="TextBox1" class="form-label">Meeting Title</label>
                <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Enter Meeting Title" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox2" class="form-label">Meeting Date & Time</label>
                <asp:TextBox ID="TextBox2" CssClass="form-control" TextMode="DateTimeLocal" placeholder="Select Date and Time" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox3" class="form-label">Meeting Location</label>
                <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Enter Location" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox4" class="form-label">Agenda</label>
                <asp:TextBox ID="TextBox4" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Enter Agenda" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3 text-center">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary " Text="Save & Notify" OnClick="Button1_Click" />
            </div>
        </div>
    </div>

    <!-- Toastr JS -->
  <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
<script>
    // Toastr global settings
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "100",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "show",
        "hideMethod": "hide"
       
    };

    // Success notification function
    function showSuccessNotification(message) {
        toastr.success(message, 'Success');
    }

    // Error notification function
    function showErrorNotification(message) {
        toastr.error(message, 'Error');
    }
</script>


</asp:Content>
