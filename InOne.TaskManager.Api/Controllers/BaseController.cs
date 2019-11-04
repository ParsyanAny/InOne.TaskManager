using InOne.Reservation.Manager.IMPL;
using InOne.TaskManager.DataAccessLayer;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Excel = Microsoft.Office.Interop.Excel;

namespace InOne.TaskManager.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected ApplicationContext _context = new ApplicationContext();
        protected UnitOfWork UnitOfWork => new UnitOfWork(_context);


        public string[] UploadFile()
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
            return file != null ? new string[] { FilesPath, file.FileName } : null;
        }
        public HttpResponseMessage GetUserTasksInfoFile()
        {
            string[] ecx = toExcel(AuthHelper.Id);
            string fileName = ecx[1] + ".xlsx";
            string localFilePath = ecx[0] + fileName;

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue(fileName);
            response.Content.Headers.ContentDisposition.FileName = fileName;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return response;
        }


        private string[] toExcel(int userId)
        {

            var tasks = UnitOfWork.TaskManager.GetTasks(userId);
            var user = UnitOfWork.UserManager.GetEntity(userId);

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);

            Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;
            sheet.Cells[1, 1].Value = "Title";
            sheet.Cells[1, 2].Value = "Description";
            sheet.Cells[1, 3].Value = "FName";
            sheet.Cells[1, 4].Value = "LName";
            sheet.Cells[1, 5].Value = "CreationDate";
            sheet.Cells[1, 6].Value = "ExpirationDate";
            sheet.Cells[1, 7].Value = "AttachmentsCount";
            sheet.Cells[1, 8].Value = "Status";

            int count1 = 2;
            int count2 = 1;
            foreach (var item in tasks)
            {
                sheet.Cells[count1, count2++].Value = item.TaskName;
                sheet.Cells[count1, count2++].Value = item.Description;
                sheet.Cells[count1, count2++].Value = item.AssignedFirstName;
                sheet.Cells[count1, count2++].Value = item.AssignedLastName;
                sheet.Cells[count1, count2++].Value = item.CreateDate;
                sheet.Cells[count1, count2++].Value = item.ExpireDate;
                sheet.Cells[count1, count2++].Value = item.AttachmentCount;
                sheet.Cells[count1, count2++].Value = item.Status;
                count2 = 1;
                count1++;
            }

            const string FilesPath = @"~\excel\";
            string fileName = user.FirstName + DateTime.Now.Minute.ToString() + user.LastName + DateTime.Now.Second;
            bool exists = Directory.Exists(HttpContext.Current.Server.MapPath(FilesPath));
            if (!exists)
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(FilesPath));
            var path = Path.Combine(HttpContext.Current.Server.MapPath(FilesPath), fileName);

            workbook.SaveAs(path + fileName);
            workbook.Close();
            excel.Quit();
            return new string[] { path, fileName };
        }
    }
}