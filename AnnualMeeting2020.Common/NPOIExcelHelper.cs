using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnnualMeeting2020.Common
{
    /// <summary>
    /// 功能描述: <功能描述>
    /// 创建时间: 2020/1/7 10:05:59
    /// <see cref="NPOIExcelHelper" langword="" />
    /// </summary>
    public class NPOIExcelHelper
    {
        public void SimpleTableToExcel(DataTable dt, string fileName)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(fileName).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                return;
            }

            ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

            //表头  
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }
            //保存为Excel文件  
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }

        public DataTable ToDataTable<T>(List<T> items, string tableName = "")
        {
            DataTable dataTable = new DataTable(tableName);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //prop.GetCustomAttribute(typeof(DescriptionAttribute), false);
                if (prop.IsDefined(typeof(DescriptionAttribute), false))
                {
                    var attr = (DescriptionAttribute)prop.GetCustomAttribute(typeof(DescriptionAttribute), false);
                    dataTable.Columns.Add(attr.Description, prop.PropertyType);
                }
            }

            foreach (T obj in items)
            {
                var values = new object[dataTable.Columns.Count];
                foreach (PropertyInfo prop in Props)
                {
                    if (prop.IsDefined(typeof(DescriptionAttribute), false))
                    {
                        var attr = (DescriptionAttribute)prop.GetCustomAttribute(typeof(DescriptionAttribute), false);
                        values[dataTable.Columns.IndexOf(attr.Description)] = prop.GetValue(obj);
                    }
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
