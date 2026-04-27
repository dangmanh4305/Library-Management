using System;
using System.Data;
using System.Windows.Forms;
using QLTV.Controllers;
using LiveCharts;
using LiveCharts.Wpf;

namespace QLTV
{
    public partial class frmDashboard : Form
    {
        private ReportController reportController;

        public frmDashboard()
        {
            InitializeComponent();
            reportController = new ReportController();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadSummaryData();
            DrawTopBooksChart();
        }

        private void LoadSummaryData()
        {
            int totalBorrowed = reportController.GetTotalBorrowedBooks();
             lblBorrowed.Text = $"Sách đang cho mượn: {totalBorrowed} cuốn";

            decimal totalRevenue = reportController.GetTotalRevenue();
             lblRevenue.Text = $"Tổng tiền phạt đã thu: {totalRevenue.ToString("N0")} VNĐ"; 
        }

        private void DrawTopBooksChart()
        {
            DataTable dtTopBooks = reportController.GetTopBorrowedBooks();
            if (dtTopBooks.Rows.Count == 0) return;

            SeriesCollection series = new SeriesCollection();
            ColumnSeries columnSeries = new ColumnSeries()
            {
                Title = "Số lần mượn",
                Values = new ChartValues<int>(),
                DataLabels = true
            };

            string[] bookTitles = new string[dtTopBooks.Rows.Count];

            for (int i = 0; i < dtTopBooks.Rows.Count; i++)
            {
                columnSeries.Values.Add(Convert.ToInt32(dtTopBooks.Rows[i]["SoLanMuon"]));
                bookTitles[i] = dtTopBooks.Rows[i]["Title"].ToString();
            }

            series.Add(columnSeries);

            chartTopBooks.Series = series;
            chartTopBooks.AxisX.Clear();
            chartTopBooks.AxisX.Add(new Axis { Title = "Tên Sách", Labels = bookTitles });
            chartTopBooks.AxisY.Clear();
            chartTopBooks.AxisY.Add(new Axis { Title = "Lượt mượn", MinValue = 0 });
        }
    }
}