<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="SocietyManagementSystem.WebForm2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .dashboard-container {
            text-align: center;
            margin-top: 50px;
            padding: 30px;
            background: linear-gradient(to right, #4facfe, #00f2fe);
            color: white;
            border-radius: 10px;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.2);
        }

        .dashboard-container h2 {
            font-size: 28px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .dashboard-container h3 {
            font-size: 22px;
            font-weight: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="row column_title ">
        <div class="col-md-12">
            <div class="dashboard-container">
                <h2>Welcome to Your Dashboard</h2>
                <h3>Hello, <asp:Label ID="lblUsername" runat="server" Text="User"></asp:Label> 👋</h3>
            </div>
        </div>
    </div>
       <div class="row column1 mt-5">
      <div class="col-md-6 col-lg-3">
          <div class="full counter_section margin_bottom_30">
              <div class="couter_icon">
                  <div>
                      <i class="fa fa-building blue1_color" style="font-size: 40px;"></i>

                  </div>
                  <p class="head_couter">Total Flats</p>
              </div>
              <div class="counter_no">
                  <div>
                     <asp:Label ID="total_no_flats" CssClass="text-md" Style="font-size: 24px;color:black; font-weight: bold;" runat="server"></asp:Label>

                     

                  </div>
              </div>
          </div>
      </div>
      <div class="col-md-6 col-lg-3">
          <div class="full counter_section margin_bottom_30">
              <div class="couter_icon">
                  <div>
                      <i class="fa fa-file-text blue1_color" style="font-size: 40px;"></i>

                  </div>
                  <p class="head_couter">Total Bills</p>
              </div>
              <div class="counter_no">
                  <div>
                  
                       <asp:Label ID="total_no_bill" CssClass="text-md" Style="font-size: 24px;color:black; font-weight: bold;" runat="server"></asp:Label>

                     

                  </div>
              </div>
          </div>
      </div>
      <div class="col-md-6 col-lg-3">
          <div class="full counter_section margin_bottom_30">
              <div class="couter_icon">
                  <div>
                      <i class="fa fa-tasks green_color" style="font-size: 40px;"></i>
                  </div>
                  <p class="head_couter">Total Allotment</p>
              </div>
              <div class="counter_no">
                  <div>
                    
                         <asp:Label ID="total_no_allotment" CssClass="text-md" Style="font-size: 24px;color:black; font-weight: bold;" runat="server"></asp:Label>

                     
                  </div>
              </div>
          </div>
      </div>
      <div class="col-md-6 col-lg-3 ">
          <div class="full counter_section  ">
              <div class="couter_icon">
                  <div>
                      <i class="fa fa-spinner red_color" style="font-size: 40px;"></i>
                  </div>
                  <p class="head_couter">Total In-Process Complaints</p>
              </div>
              <div class="counter_no">
                  <div>
                    
                        <asp:Label ID="total_no_in_process_complaint" CssClass="text-md" Style="font-size: 24px;color:black; font-weight: bold;" runat="server"></asp:Label>


                  </div>
              </div>
          </div>
      </div>


      <div class="col-md-6 col-lg-3 margin_top_30">
          <div class="full counter_section margin_bottom_10">
              <div class="couter_icon">
                  <div>
                      <i class="fa fa-user-plus red_color" style="font-size: 40px;"></i>
                  </div>
                  <p class="head_couter">Total Visitors</p>
              </div>
              <div class="counter_no">
                  <div>
                         <asp:Label ID="total_no_visitor" CssClass="text-md" Style="font-size: 24px;color:black; font-weight: bold;" runat="server"></asp:Label>
                  </div>
              </div>
          </div>
      </div>
      <div class="col-md-6 col-lg-3 margin_top_30">
          <div class="full counter_section margin_bottom_10">
              <div class="couter_icon">
                  <div>
                      <i class="fa fa-exclamation-triangle red_color" style="font-size: 40px;"></i>
                  </div>
                  <p class="head_couter">Total Unresolved Complaints</p>
              </div>
              <div class="counter_no">
                  <div>
                   
                         <asp:Label ID="total_no_unresolved_comp" CssClass="text-md" Style="font-size: 24px;color:black; font-weight: bold;" runat="server"></asp:Label>


                  </div>
              </div>
          </div>
      </div>
      <div class="col-md-6 col-lg-3 margin_top_30">
          <div class="full counter_section margin_bottom_10">
              <div class="couter_icon">
                  <div>
                      <i class="fa fa-check-circle red_color" style="font-size: 40px;"></i>
                  </div>
                  <p class="head_couter">Total Resolved Complaints</p>
              </div>
              <div class="counter_no">
                  <div>
             
            <asp:Label ID="total_no_resolve_comp" CssClass="text-md" Style="font-size: 24px;color:black; font-weight: bold;" runat="server"></asp:Label>


                  </div>
              </div>
          </div>
      </div>
      <div class="col-md-6 col-lg-3 margin_top_30">
          <div class="full counter_section margin_bottom_10">
              <div class="couter_icon">
                  <div>
                      <i class="fa fa-list-alt red_color" style="font-size: 40px;"></i>
                  </div>
                  <p class="head_couter">Total Complaints</p>
              </div>
              <div class="counter_no">
                  <div>
                  
                      <asp:Label ID="total_no_complaint" CssClass="text-md" Style="font-size: 24px;color:black; font-weight: bold;" runat="server"></asp:Label>


                  </div>
              </div>
          </div>
      </div>
  </div>

</asp:Content>
