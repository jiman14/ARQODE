using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelpControls
{
    public class CExcel_Json_Converter
    {
        /// <summary>
        /// Convertir fichero excel en JSON
        /// </summary>
        /// <param name="path_excel"></param>
        /// <returns></returns>
        public JToken Excel2JSon(String path_excel, String nombre_hoja="")
        {
            JArray Excell_rows = new JArray();
            Excel.Application ExcelApp = new Excel.Application();

            try
            {
                Excel.Workbook ExcelBook = ExcelApp.Workbooks.Open(path_excel, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows,
                                                                        "\t", false, false, 0, false, true, Excel.XlCorruptLoad.xlNormalLoad);
                Excel.Worksheet ExcelSheet = null;
                if (nombre_hoja != "")
                {
                    ExcelSheet = (Excel.Worksheet)ExcelBook.Worksheets[nombre_hoja];
                }
                else
                {
                    ExcelSheet = (Excel.Worksheet)ExcelBook.Worksheets.get_Item(1);
                }

                #region Extraer columnas
                ArrayList listaCols = new ArrayList();
                int primera_fila = -1;
                int primera_columna = -1;
                for (int i = 1; i < ExcelSheet.Rows.Count; i++)
                {
                    foreach (Excel.Range Range in ExcelSheet.Columns)
                    {
                        var cell = ExcelSheet.Cells[i, Range.Column];
                        if (cell.Text != "")
                        {
                            if (primera_fila < 0) primera_fila = i;
                            if (primera_columna < 0) primera_columna = Range.Column;
                            listaCols.Add(cell.Text);
                        }
                        else if (listaCols.Count > 0)
                        {
                            break;
                        }
                    }
                    if (listaCols.Count > 0)
                    {
                        break;
                    }
                }
                #endregion

                #region fill json array with excel rows

                for (int i = primera_fila + 1; i < ExcelSheet.Rows.Count; i++)
                {
                    JObject JRow = new JObject();
                    int j = 0;
                    int fill_count = 0;
                    for (int ncol = primera_columna; ncol <= listaCols.Count; ncol++)
                    {
                        var cell = ExcelSheet.Cells[i, ncol];
                        JRow.Add(listaCols[j].ToString(), cell.Text);
                        j++;
                        fill_count += (cell.Text != "") ? 1 : 0;
                    }

                    // Exist on last row
                    if (fill_count == 0)
                    {
                        break;
                    }
                    else
                    {
                        Excell_rows.Add(JRow);
                    }
                }
                #endregion

                ExcelBook.Close();
                ExcelApp.Quit();
            }
            catch
            {
                ExcelApp.Quit();
            }

            return Excell_rows;
        }

        /// <summary>
        /// Convierte un DataTable en un fichero excel, 
        /// errores: -1: ruta a fichero no válida, -2: error desconocido
        /// </summary>
        /// <param name="Origin_DataTable"></param>
        /// <param name="excel_path"></param>
        /// <returns></returns>
        public int DataTable2Excel(DataTable Origin_DataTable, String excel_path)
        {
            // Start Excel and get Application object.
            Excel.Application excel = new Excel.Application();

            try
            {
                // Check if file
                if (!Directory.Exists(excel_path.Remove(excel_path.LastIndexOf("\\")))) return -1;

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                Excel.Workbook excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = Origin_DataTable.TableName;

                for (int ncol = 0; ncol < Origin_DataTable.Columns.Count; ncol++)
                {
                    excelSheet.Cells[1, ncol + 1].Value = Origin_DataTable.Columns[ncol].Caption;
                }

                for (int nfil = 0; nfil < Origin_DataTable.Rows.Count; nfil++)
                {
                    for (int ncol = 0; ncol < Origin_DataTable.Columns.Count; ncol++)
                    {
                        excelSheet.Cells[nfil+2, ncol+1].Value = Origin_DataTable.Rows[nfil][ncol].ToString();
                    }
                }
                
                excelworkBook.SaveAs(excel_path);

                excelworkBook.Close();
                excel.Quit();

                return 0;
            }
            catch
            {
                excel.Quit();
                return -2;
            }
            
        }

        /// <summary>
        /// Convierte un JArray JSON en un fichero excel, 
        /// errores: -1: ruta a fichero no válida, -2: error desconocido
        /// </summary>
        /// <param name="Origin_JArray"></param>
        /// <param name="excel_path"></param>
        /// <returns></returns>
        public int JSon2Excel(JArray Origin_JArray, String excel_path)
        {
            // Start Excel and get Application object.
            Excel.Application excel = new Excel.Application();

            try
            {
                // Check if file
                if (!Directory.Exists(excel_path.Remove(excel_path.LastIndexOf("\\")))) return -1;
                String excel_name = excel_path.Substring(excel_path.LastIndexOf("\\")+1);

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                Excel.Workbook excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = excel_name;

                int nfil = 2;
                int ncol = 1;
                foreach (JToken Jfila in Origin_JArray[nfil])
                {
                    foreach (JProperty jprop in ((JObject)Jfila).Properties())
                    {
                        if (nfil == 2)
                        {
                            excelSheet.Cells[1, ncol].Value = jprop.Name;
                            excelSheet.Cells[nfil, ncol].Value = jprop.Value.ToString(); 
                        }
                        else
                            excelSheet.Cells[nfil, ncol].Value = jprop.Value.ToString();
                        ncol++;
                    }
                    nfil++;
                }

                excelworkBook.SaveAs(excel_path);

                excelworkBook.Close();
                excel.Quit();

                return 0;
            }
            catch
            {
                excel.Quit();
                return -2;
            }

        }
    }
}
