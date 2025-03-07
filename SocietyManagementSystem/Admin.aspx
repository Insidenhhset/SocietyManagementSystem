<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SocietyManagementSystem.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField ID="allotmentChartData" runat="server" />
    <asp:HiddenField ID="billPieChartData" runat="server" />

  
    <div class="row column1 mt-4">
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

    <div class="row d-flex mt-4" style="height: 300px;"> <!-- Set row height -->
    <div class="col-md-6 d-flex align-items-center justify-content-center">
        <canvas id="allotmentChart"></canvas>
    </div>
    <div class="col-md-6 d-flex align-items-center justify-content-center">
        <canvas id="billChart"></canvas>
    </div>
</div>

<script>
    document.addEventListener("DOMContentLoaded", function () {
        var allotmentDataElem = document.getElementById('<%= allotmentChartData.ClientID %>');
        var billDataElem = document.getElementById('<%= billPieChartData.ClientID %>');

        if (allotmentDataElem && billDataElem) {
            var allotmentData = allotmentDataElem.value ? JSON.parse(allotmentDataElem.value) : [];
            var billData = billDataElem.value ? JSON.parse(billDataElem.value) : [];

            var allotmentCtx = document.getElementById('allotmentChart').getContext('2d');
            var billCtx = document.getElementById('billChart').getContext('2d');

            if (allotmentData.length > 0) {
                new Chart(allotmentCtx, {
                    type: 'bar',
                    data: {
                        labels: ['January', 'February', 'March', 'April'],
                        datasets: [{
                            label: 'Allotments',
                            data: allotmentData,
                            backgroundColor: 'rgba(75, 192, 192, 0.6)',
                        }]
                    },
                    options: {
                        responsive: true,
                        maintainAspectRatio: false
                    }
                });
            }

            if (billData.length > 0) {
                new Chart(billCtx, {
                    type: 'pie',
                    data: {
                        labels: ['Paid', 'Not Paid'],
                        datasets: [{
                            data: billData,
                            backgroundColor: ['#36a2eb', '#ff6384'],
                        }]
                    },
                    options: {
                        responsive: true,
                        maintainAspectRatio: false
                    }
                });
            }
        }
    });
</script>

</asp:Content>