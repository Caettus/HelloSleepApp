using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Serialization;
using HelloSleep.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace HelloSleep.DocumentDownloads
{
    public class DownloadExcel
    {

        public static void Download(List<Data> dataList, string id)
        {

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            ExcelPackage excel = new ExcelPackage();

            var workSheet = excel.Workbook.Worksheets.Add("Slaapdata");

            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            workSheet.Cells[1, 1].Value = "Id";
            workSheet.Cells[1, 2].Value = "Datum";
            workSheet.Cells[1, 3].Value = "Avg temp";
            workSheet.Cells[1, 4].Value = "Temperatuur";
            workSheet.Cells[1, 5].Value = "Hartslag";
            workSheet.Cells[1, 6].Value = "Slapen";
            workSheet.Cells[1, 7].Value = "Wakker";

            workSheet.Cells[1, 1].Style.Font.Bold = true;
            workSheet.Cells[1, 2].Style.Font.Bold = true;
            workSheet.Cells[1, 3].Style.Font.Bold = true;
            workSheet.Cells[1, 4].Style.Font.Bold = true;
            workSheet.Cells[1, 5].Style.Font.Bold = true;
            workSheet.Cells[1, 6].Style.Font.Bold = true;
            workSheet.Cells[1, 7].Style.Font.Bold = true;

            workSheet.Cells[1, 1, 1, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;

            int recordIndex = 2;

            foreach (Data item in dataList)
            {
                if (id != null)
                {
                    if (item.Id == int.Parse(id))
                    {
                        workSheet.Cells[$"A1:G{dataList.Count}"].AutoFitColumns();

                        workSheet.Cells[recordIndex, 1].Value = item.Id;
                        workSheet.Cells[recordIndex, 2].Value = item.Datum;
                        workSheet.Cells[recordIndex, 3].Value = item.AvgTemp;
                        workSheet.Cells[recordIndex, 4].Value = item.Temperatuur;
                        workSheet.Cells[recordIndex, 5].Value = item.Hartslag;
                        workSheet.Cells[recordIndex, 6].Value = item.Slapen;
                        workSheet.Cells[recordIndex, 7].Value = item.Wakker;


                        recordIndex++;
                    }
                }
                else
                {
                    workSheet.Cells[$"A1:G{dataList.Count}"].AutoFitColumns();

                    workSheet.Cells[recordIndex, 1].Value = item.Id;
                    workSheet.Cells[recordIndex, 2].Value = item.Datum;
                    workSheet.Cells[recordIndex, 3].Value = item.AvgTemp;
                    workSheet.Cells[recordIndex, 4].Value = item.Temperatuur;
                    workSheet.Cells[recordIndex, 5].Value = item.Hartslag;
                    workSheet.Cells[recordIndex, 6].Value = item.Slapen;
                    workSheet.Cells[recordIndex, 7].Value = item.Wakker;


                    recordIndex++;
                }
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();

            Random rnd = new Random();

            string fileNaam = @"E:\Fontys_ICT\Media\" + rnd.Next(1, 1000000000) + ".xlsx";

            FileInfo excelFile = new FileInfo(fileNaam);

            excel.SaveAs(excelFile);

            if (File.Exists(fileNaam)) { new Process { StartInfo = new ProcessStartInfo(fileNaam) { UseShellExecute = true } }.Start(); }
        }
    }
}
