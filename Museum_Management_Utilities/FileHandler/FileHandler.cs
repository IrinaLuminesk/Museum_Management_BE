using ClosedXML.Excel;
using Museum_Management_Utilities.FileHandler;
using System.Data;
using System.Reflection;
namespace Lottery_Predict_Utilities.FileProcess
{
    public class FileHandler
    {

        #region Import và Export Excel
        //public static async Task<byte[]> ExportExcel<T>(string ReportName, List<string> header, List<T> data)
        //{
        //    ExcelPackage pck = new ExcelPackage();
        //    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(ReportName);

        //    ws.Cells["A1"].Value = ReportName;

        //    ws.Cells["A2"].Value = "Thời gian tạo:";
        //    ws.Cells["B2"].Value = string.Format("{0:dd/MM/yyyy} vào lúc {0:HH:mm}", DateTime.Now);

        //    int column = 3;
        //    foreach (var i in header)
        //    {
        //        ws.Cells[6, column].Value = i;
        //        SetExcelColumnCenter(ref ws, column);
        //        //ws.Cells[6, column].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        //        column++;
        //    }

        //    int RowStart = 7;
        //    DataTable data = await ConvertingUtilities.ConvertListToDatatable<T>(Item);

        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        column = 3;
        //        ws.Cells[RowStart, column].Value = i + 1;
        //        for (int j = 0; j < data.Columns.Count; j++)
        //        {
        //            //ws.Cells[RowStart, column + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        //            ws.Cells[RowStart, column + 1].Value = data.Rows[i][j];
        //            SetExcelColumnCenter(ref ws, column);
        //            column++;
        //        }
        //        RowStart++;
        //    }



        //    //ws.Cells[1, 1, 1, data.Columns.Count].AutoFitColumns();

        //    return await Task.FromResult(pck.GetAsByteArray());
        //}

        public static async Task<byte[]> ExportExcel2<T>(string? ReportName, List<string>? header, List<List<object?>> data)
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add(
            string.IsNullOrEmpty(ReportName)
                ? "Report"
                : ReportName);

            var properties = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead &&
                        p.GetIndexParameters().Length == 0 &&
                        !Attribute.IsDefined(
                            p, typeof(ExcelIgnoreAttribute)))
            .ToList();

            for (int col = 0; col < header.Count; col++)
            {
                worksheet.Cell(1, col + 1).Value = header[col];
            }

            for (int row = 0; row < data.Count; row++)
            {
                for (int col = 0; col < header.Count && col < data[row].Count; col++)
                {
                    var value = data[row][col];

                    worksheet.Cell(row + 2, col + 1).Value =
                        value == null
                            ? Blank.Value
                            : XLCellValue.FromObject(value);
                }
            }

            if (header.Count > 0)
            {
                worksheet.Row(1).Style.Font.Bold = true;
                worksheet.Row(1).Style.Fill.BackgroundColor =
                    XLColor.LightBlue;

                worksheet.Columns(1, header.Count).AdjustToContents();
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return await Task.FromResult(stream.ToArray());
        }

        //private static void SetExcelColumnCenter(ref ExcelWorksheet ws, int columnIndex)
        //{
        //    ws.Columns[columnIndex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        //    ws.Columns[columnIndex].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        //}

        #endregion


    }
}