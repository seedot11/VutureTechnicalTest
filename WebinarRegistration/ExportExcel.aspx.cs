using System;
using System.Data;
using System.Text;

namespace WebinarRegistration
{
    public partial class ExportExcel : System.Web.UI.Page
    {
        protected DataTable ReportingData;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryStringYear = Request.QueryString["year"];
            if (string.IsNullOrEmpty(queryStringYear))
            {
                throw new ArgumentNullException("ExportExcel requires a 'year' query parameter.");
            }
            if (!int.TryParse(queryStringYear, out int yearInput))
            {
                throw new ArgumentException("The 'year' query parameter must be an integer.");
            }
            ReportingData = LegacyReporting.ReportingService.GetDataByYear(yearInput) as DataTable;

            Response.Clear();
            Response.ClearHeaders();

            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=SalutationGeneratorReport.xls");


            Response.Buffer = true;
            Response.BufferOutput = true;

            // This sets the BOM, which we usually avoid.
            // See http://www.fusioncharts.com/flex/docs/charts/contents/case_UTF8.html
            var utfHeader = Encoding.UTF8.GetPreamble();
            Response.BinaryWrite(utfHeader);
        }
    }
}