using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data;
using Configuracion;

namespace Presentacion.Clases
{
    public class Reglas
    {
        public const string Aver = "tsVer";

        public static string ObtenerRutaApp()
        {
            string strPath;
            strPath = Application.StartupPath;
            if ((!strPath.EndsWith(@"\"))) strPath += @"\";
            return strPath;
        }

        public static void GuardarLogs(string pStrCadenaLog)
        {
            string strCadenaTexto;
            StreamWriter objStream;
            byte[] objByte;
            string strNombreArchivo;
            strCadenaTexto = pStrCadenaLog + " ";
            //strCadenaTexto = pStrCadenaLog + ControlChars.CrLf;
            objByte = Encoding.Unicode.GetBytes(strCadenaTexto);
            strNombreArchivo = ObtenerRutaApp() + DateTime.Today.ToString("dd-MM-yyyy") + ".txt";
            if (!File.Exists(strNombreArchivo))
            {
                objStream = File.CreateText(strNombreArchivo);
            }
            else
            {
                objStream = File.AppendText(strNombreArchivo);
            }
            objStream.Write(strCadenaTexto);
            objStream.Flush();
            objStream.Close();
            objStream = null;
        }

        public static void GuardarErrores(string pStrCadenaError)
        {
            string strCadenaTexto;
            string strNombreArchivo;
            StreamWriter objStream;
            byte[] objByte;
            strCadenaTexto = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " Error : " + pStrCadenaError + " ";
            //strCadenaTexto = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " Error : " + pStrCadenaError + ControlChars.CrLf;
            objByte = Encoding.Unicode.GetBytes(strCadenaTexto);
            strNombreArchivo = ObtenerRutaApp() + "Error\\" + DateTime.Today.ToString("Err dd-MM-yyyy") + ".txt"; //Cambio guion 
            if (!File.Exists(strNombreArchivo))
            {
                objStream = File.CreateText(strNombreArchivo);
            }
            else
            {
                objStream = File.AppendText(strNombreArchivo);
            }
            objStream.Write(strCadenaTexto);
            objStream.Flush();
            objStream.Close();
            objStream = null;
        }

        public static void ExportaExcel(DataTable tb, string nombre_titulo)
        {
            try
            {
                System.Data.DataRow filatabla;
                Microsoft.Office.Interop.Excel.Application Mexcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook libroexcel;
                Microsoft.Office.Interop.Excel.Worksheet hojaexcel;
                Mexcel.Visible = true;
                libroexcel = Mexcel.Workbooks.Add();
                hojaexcel = libroexcel.Worksheets[1];
                hojaexcel.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible;
                hojaexcel.Activate();

                hojaexcel.Columns["A"].numberformat = "@";

                hojaexcel.Range["A1:F1"].Merge();
                hojaexcel.Range["A1:F1"].Value = nombre_titulo;
                hojaexcel.Range["A1:F1"].Font.Bold = true;
                hojaexcel.Range["A1:F1"].Font.Size = 15;

                Int32 NCol = tb.Columns.Count;
                Int32 NRow = tb.Rows.Count;

                for (int i = 1; i <= NCol; i++)
                {
                    hojaexcel.Cells.Item[5, i] = tb.Columns[i - 1].Caption;
                }

                for (int fila = 0; fila <= NRow - 1; fila++)
                {
                    filatabla = tb.Rows[fila];
                    for (int col = 0; col <= NCol - 1; col++)
                    {
                        hojaexcel.Cells.Item[fila + 6, col + 1] = filatabla[col];
                    }
                }
                hojaexcel.Rows.Item[5].font.bold = 1;
                hojaexcel.Rows.Item[5].horizontalalignment = 3;
                hojaexcel.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                Libreria.Error_Grabar(ex);
            }
        }

        public static void alternarColor(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(Configuracion.Sistema.GrillaColor);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv.BackgroundColor = Color.White;
            //dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
        }

        
    }
}
