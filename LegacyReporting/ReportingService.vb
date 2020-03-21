Imports System.Data.SqlClient

Public Class ReportingService
    Public Shared Function GetDataByYear(intYear)
        Dim strQuery = "SELECT w.Id AS WebinarId, w.Name AS WebinarName, w.[Date] AS WebinarDate, r.Id AS RegistrantId, r.FirstName AS RegistrantFirstName, r.LastName AS RegistrantLastName, r.EmailAddress AS RegistrantEmailAddress, c.Id AS CompanyId, c.Name AS CompanyName FROM Webinar w LEFT JOIN WebinarRegistrant wr ON w.Id = wr.WebinarId LEFT JOIN Registrant r ON wr.RegistrantId = r.Id LEFT JOIN Company c ON r.CompanyId = c.Id WHERE w.[Year] = " & intYear & " ORDER BY w.Date, r.LastName, r.FirstName"

        Dim objSqlConnection = New SqlConnection
        objSqlConnection.ConnectionString = "data source=(local);initial catalog=WebinarRegistration;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"

        Dim objDataAdapter = New SqlDataAdapter(strQuery, objSqlConnection)
        Dim objReportData As New DataTable

        objDataAdapter.Fill(objReportData)

        Return objReportData
    End Function
End Class
