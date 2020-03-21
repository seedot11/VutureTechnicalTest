<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportExcel.aspx.cs" Inherits="WebinarRegistration.ExportExcel" %>
<%@ Import Namespace="System.Data" %>
<html xmlns:x="urn:schemas-microsoft-com:office:excel">
<head>
<style>
<!--
mso-data-placement:same-cell;
table
	{mso-displayed-decimal-separator:"\.";
	mso-displayed-thousand-separator:"\,";}
@page
	{mso-header-data:"&L&\0022Arial\,Bold\0022&12Salutation Generator\000A&\0022Arial\,Regular\0022&10&D - Page &P of &N\000A";
	margin:1.0in .75in 0.5in .75in;
	mso-header-margin:.5in;
	mso-footer-margin:0in;
	mso-page-orientation:landscape;}
	margin:1.0in .75in 0.5in .75in;
	mso-header-margin:.5in;
	mso-footer-margin:0in;
	mso-page-orientation:landscape;}
tr
	{mso-height-source:auto;}
col
	{mso-width-source:auto;}
br
	{mso-data-placement:same-cell;}
td
	{
	padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:none;
	mso-protection:locked visible;
	mso-rotate:0;}
.xldate
	{mso-style-parent:style0;
	mso-number-format:"General Date";}
.xltext
	{mso-number-format:"\@";}
.xlcurrency0
	{mso-style-parent:style0;
	mso-number-format:"\0022\0022\#\,\#\#0";
	text-align:right;}
.xlcurrency2
	{mso-style-parent:style0;
	mso-number-format:"\0022\0022\#\,\#\#0\.00";
	text-align:right;}
.xlfooter
	{mso-style-parent:style0;
	font-size:5.0pt;}

.xltextfail {mso-style-parent:style0;mso-number-format:"\@";background: #fec5cd !important; mso-background: #fec5cd !important; color: #9a0042 !important;}

.xltextemployee {mso-style-parent:style0;mso-number-format:"\@";background: #dbeef3 !important; mso-background: #dbeef3 !important; color: #646d6f !important;}

.xltextdarker {mso-style-parent:style0;mso-number-format:"\@";background: #ececec !important; mso-background: #ececec !important; }
.xltextfaildarker {mso-style-parent:style0;mso-number-format:"\@";background: #c5979e !important; mso-background: #c5979e !important; color: #9a0042 !important;}
.xltextemployeedarker {mso-style-parent:style0;mso-number-format:"\@";background: #b6c7cb !important; mso-background: #b6c7cb !important; color: #646d6f !important;}
-->
</style>
<!--[if gte mso 9]><xml>
 <x:ExcelWorkbook>
  <x:ExcelWorksheets>
   <x:ExcelWorksheet>
    <x:Name>Sheet1</x:Name>
    <x:WorksheetOptions>
     <x:FitToPage/>
     <x:Print>
      <x:FitWidth>1</x:FitWidth>
	  <x:FitHeight>100</x:FitHeight>
      <x:ValidPrinterInfo/>
      <x:PaperSizeIndex>9</x:PaperSizeIndex>
      <x:HorizontalResolution>600</x:HorizontalResolution>
      <x:VerticalResolution>600</x:VerticalResolution>
     </x:Print>
     <x:Selected/>
     <x:Panes>
      <x:Pane>
       <x:Number>3</x:Number>
       <x:ActiveRow>13</x:ActiveRow>
       <x:ActiveCol>15</x:ActiveCol>
      </x:Pane>
     </x:Panes>
     <x:ProtectContents>False</x:ProtectContents>
     <x:ProtectObjects>False</x:ProtectObjects>
     <x:ProtectScenarios>False</x:ProtectScenarios>
    </x:WorksheetOptions>
   </x:ExcelWorksheet>
   <x:ExcelWorksheet>
    <x:Name>Sheet2</x:Name>
    <x:WorksheetOptions>
     <x:ProtectContents>False</x:ProtectContents>
     <x:ProtectObjects>False</x:ProtectObjects>
     <x:ProtectScenarios>False</x:ProtectScenarios>
    </x:WorksheetOptions>
   </x:ExcelWorksheet>
   <x:ExcelWorksheet>
    <x:Name>Sheet3</x:Name>
    <x:WorksheetOptions>
     <x:ProtectContents>False</x:ProtectContents>
     <x:ProtectObjects>False</x:ProtectObjects>
     <x:ProtectScenarios>False</x:ProtectScenarios>
    </x:WorksheetOptions>
   </x:ExcelWorksheet>
  </x:ExcelWorksheets>
  <x:WindowHeight>12405</x:WindowHeight>
  <x:WindowWidth>19020</x:WindowWidth>
  <x:WindowTopX>120</x:WindowTopX>
  <x:WindowTopY>75</x:WindowTopY>
  <x:ProtectStructure>False</x:ProtectStructure>
  <x:ProtectWindows>False</x:ProtectWindows>
 </x:ExcelWorkbook>
 <x:ExcelName>
  <x:Name>Print_Titles</x:Name>
  <x:SheetIndex>1</x:SheetIndex>
  <x:Formula>=Sheet1!$1:$1</x:Formula>
 </x:ExcelName>
</xml><![endif]-->
</head>
<body>
<table>
    <% int columnCount = ReportingData.Columns.Count; %>
    <tr>
        <% for (int i = 0; i < columnCount; i++) { %>
            <td><strong><%= Server.HtmlEncode(ReportingData.Columns[i].ColumnName) %></strong></td>
        <% } %>
    </tr>
    
    <% foreach (DataRow row in ReportingData.Rows) { %>
    <tr>
        <% for (int i = 0; i < columnCount; i++) {%>
        <td class="xltext"><%= Server.HtmlEncode(row[i].ToString()) %></td>
        <% } %>
    </tr>
    <% } %>

</table>
</body>
</html>