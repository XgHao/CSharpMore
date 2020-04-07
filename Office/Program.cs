using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;

namespace Office
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecPrint(new Students
            {
                StuNo = "150104400132",
                Name = "郑兴豪",
                Class = "15软件工程",
                PhoNum = "15869650977",
                Address = "浙江省温州市乐清市大荆镇",
                Remark = "备注备注备注备注备注备注备注备注备注备注备注备注备注备注"
            });

            Console.Read();
        }


        public static void ExecPrint(Students students)
        {
            //定义工作簿
            Application excelApp = new Application();
            //获取路径
            string execlBookPath = Environment.CurrentDirectory + @"\studentinfo.xlsx";
            //将现有工作簿加入已经定义的工作簿集合中
            excelApp.Workbooks.Add(execlBookPath);
            //获取第一个工作表
            Worksheet worksheet = excelApp.Worksheets[1];
            //插入图片
            worksheet.Shapes.AddPicture(Environment.CurrentDirectory + @"\pic.png", MsoTriState.msoFalse, MsoTriState.msoTrue, 40, 80, 70, 80);
            //其他数据
            worksheet.Cells[4, 5] = students.StuNo;
            worksheet.Cells[4, 8] = students.Name;
            worksheet.Cells[6, 5] = students.Class;
            worksheet.Cells[6, 8] = students.PhoNum;
            worksheet.Cells[9, 4] = students.Address;
            worksheet.Cells[10, 2] = students.Remark;

            //打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);

            //释放资源
             excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            excelApp = null;
        }
    }
}
