using InOne.Reservation.Manager.IMPL;
using InOne.TaskManager.DataAccessLayer;
using System.IO;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using System;

namespace InOne.TaskManager.Api
{
    public class Uploader
    {
        public static string[] UploadFile()
        {
            const string FilesPath = @"~\uploads\";
            bool exists = Directory.Exists(HttpContext.Current.Server.MapPath(FilesPath));
            if (!exists)
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(FilesPath));
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath(FilesPath), fileName);
                file.SaveAs(path + fileName);
            }
            return file != null ? new string[]{ FilesPath, file.FileName } : null;
        }

        public static void ToExcel(int userId)
        {
            ApplicationContext context = new ApplicationContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

           var tasks = unitOfWork.TaskManager.GetTasks(userId);

            String outputPath = @"C:\Users\Any\source\repos\InOne.TaskManager\InOne.TaskManager.Api\excel";

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;

            ((Excel.Range)sheet.Cells[1, 1]).Value = "Hello";
            int count1 = 1;
            int count2 = 1;
            foreach (var item in tasks)
            {
                sheet.Cells[count1, count2++].Value = item.TaskName;
                sheet.Cells[count1, count2++].Value = item.Description;
                sheet.Cells[count1, count2++].Value = item.ExpireDate;
                count2 = 1;
                count1++;
            }


            workbook.SaveAs(outputPath);
            workbook.Close();
            excel.Quit();

        }
    }
}