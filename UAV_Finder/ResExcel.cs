using System;
//using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Office.Interop.Excel;

class ResExcel
{
    static Application m_ObjEx;
    static Workbook    m_Book;
    static _Worksheet  m_Sheet;

    static string[] sMethodNames = { "Параллельных курсов", "Случайного поиска", "Поиска кратчайшего маршрута" };

    static double GetDispersion(double[] dFindTimes)
    {
        double dMax = dFindTimes[0];
        double dMin = dFindTimes[0];

        for (int i = 0; i < dFindTimes.Length; i++)
        {
            if (dFindTimes[i] != 0 && dFindTimes[i] > dMax)
                dMax = dFindTimes[i];
            if (dFindTimes[i] != 0 && dFindTimes[i] < dMin)
                dMin = dFindTimes[i];
        }

        return dMax - dMin;
    }

    public static int CreateTable(Results[] zResults, double dMinProb)
    {
        int nRet = 1;

        try
        {
            m_ObjEx = new Application();
            m_Book = m_ObjEx.Workbooks.Add();
            m_Sheet = (Worksheet)m_ObjEx.ActiveSheet;
            m_Sheet.Cells[2, "B"] = "Метод";
            m_Sheet.Cells[2, "C"] = "Время, ч";
            m_Sheet.Cells[2, "D"] = "Вероятность обнаружения";
            m_Sheet.Cells[2, "E"] = "Требуемая вероятность";
            m_Sheet.Cells[2, "F"] = "Дисперсия времени, ч";

            for (int i = 0; i < 3; i++)
            {
                m_Sheet.Cells[3 + i, "B"] = sMethodNames[zResults[i].nMethod];
                m_Sheet.Cells[3 + i, "C"] = zResults[i].dTime;
                m_Sheet.Cells[3 + i, "D"] = zResults[i].dProb;
                m_Sheet.Cells[3 + i, "E"] = dMinProb;
                m_Sheet.Cells[3 + i, "F"] = GetDispersion(zResults[i].dFindTimes);
            }

            m_Sheet.Cells[6, "C"] = 0;
            m_Sheet.Cells[6, "E"] = dMinProb;

            m_Sheet.Columns[2].AutoFit();
            m_Sheet.Columns[3].AutoFit();
            m_Sheet.Columns[4].AutoFit();
            m_Sheet.Columns[5].AutoFit();
            m_Sheet.Columns[6].AutoFit();

            m_ObjEx.UserControl = true;
            m_Book.SaveAs(System.Windows.Forms.Application.StartupPath + "\\Results.xlsm", XlFileFormat.xlOpenXMLWorkbookMacroEnabled);            
        }
        catch(Exception e)
        {
            System.Windows.Forms.MessageBox.Show("Ошибка сохранения Excel-файла\n" + e.Message);
            nRet = 0;
        }
        finally
        {
            m_Book.Close(false);
            m_ObjEx.Quit();
        }

        return nRet;
    }
}

