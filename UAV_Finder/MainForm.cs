using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

struct Results
{
    public int nMethod;
    public double dTime;
    public double[] dFindTimes;  // Массив времен для подсчета дисперсии
    public double dProb;
}

public partial class MainForm : Form
{
    Area  m_Area;           // Объект общей территории
    Human m_Human;          // Объект цели
    UAV_Control m_UAV_Ctrl; // Объект для контроля БПЛА

    int m_nMethod;      // Номер текущего метода

    double m_dSTerr;    // Площадь территории
    int    m_nInitCount;// Кол-во испытаний
    int    m_nCount;    // Счетчик для кол-ва испытаний
    double m_dMinProb;  // Мин. вероятность для признания метода эффективным
    double m_dHumanV;   // Скорость человека
    double m_dHumanR;   // Радиус видимости человека
    double m_dUAVv;     // Скорость БПЛА
    double m_dUAVr;     // Радиус видимости БПЛА
    double m_dUAVtime;  // Время работы БПЛА
    int    m_nUAVs;     // Количество БПЛА

    double m_dCoeff;    // Коэффициент перевода в СК PictureBox

    bool m_bHuman;      // Флаги для отрисовки цели и БПЛА
    bool m_bUAVs;

    int m_nTicks;       // Количество тиков таймера = перерасчета координат
    double m_dTimeFind; // Время, затраченное на нахождение цели 
    int m_nFind;        // Счетчик сколько раз нашли цель

    bool m_bBase;       // Флаг, используется ли БД
    Results[] m_zResults;

    System.Globalization.CultureInfo CInfo = System.Globalization.CultureInfo.InvariantCulture;

    // Конструктор формы
    public MainForm()
    {
        InitializeComponent();

        m_bBase = Query.TryConnect();     // Проверка подключения к БД

        SetInitialValues();     // Установка начальных значений

        // Создание объектов, здесь вызывается только для того, чтобы нарисовать сетку
        m_Area = new Area(m_dSTerr, m_dHumanR);
        m_UAV_Ctrl = new UAV_Control(m_nUAVs, m_dSTerr, m_dUAVv, m_dUAVr, m_dUAVtime, m_nMethod);     
        //m_Human = new Human(m_Area);

        m_bHuman = false;
        m_bUAVs = false;
    }

    // Рисование в PictureBox
    private void PBTerritory_Paint(object sender, PaintEventArgs e)
    {
        DrawArea(e);        // Нарисовать сетку

        if (m_bHuman)
            DrawHuman(e);   // Нарисовать цель

        if (m_bUAVs)
            DrawUAVs(e);    // Нарисовать БПЛА
    }

    // Нарисовать сетку
    private void DrawArea(PaintEventArgs e)
    {
        float x, y;     // Координаты
        float w, h;     // Ширина и высота
        float x0, y0;   // Начальные координаты

        // Рисовка сетки для человека
        //int S = PBTerritory.Height * PBTerritory.Width;

        //x0 = 0;
        //y0 = 0;// PBTerritory.Height;

        //w = (float)PBTerritory.Width / m_Area.m_nSide; ;
        //h = (float)PBTerritory.Height / m_Area.m_nSide;

        //m_dCoeff = Math.Sqrt(S / m_dSTerr);

        //x = x0;
        //y = y0;

        //e.Graphics.FillRectangle(Brushes.White, x, y, PBTerritory.Width, PBTerritory.Height);

        //Font font = new Font("Tahoma", 8);

        //for (int i = 0; i < m_Area.m_nSide; i++)
        //{
        //    for (int j = 0; j < m_Area.m_nSide; j++)
        //    {
        //        e.Graphics.DrawRectangle(Pens.Black, x, y, w, h);
        //        //String coord = "(" + m_Area.m_zArea[i * m_Area.m_nSide + j].x.ToString() + ", " + m_Area.m_zArea[i * m_Area.m_nSide + j].y.ToString() + ")";
        //        //e.Graphics.DrawString(coord, font, Brushes.Black, x, y);
        //        x += w;
        //    }
        //    y += h;
        //    x = 0;
        //}

        // Рисовка сетки для БПЛА
        int S = PBTerritory.Height * PBTerritory.Width;

        x0 = 0;
        y0 = 0;

        w = (float)PBTerritory.Width / m_nUAVs / m_UAV_Ctrl.m_nSquareW;
        h = (float)PBTerritory.Height / m_UAV_Ctrl.m_nSquareH;

        m_dCoeff = Math.Sqrt(S / m_dSTerr);

        x = x0;
        y = y0;

        e.Graphics.FillRectangle(Brushes.White, x, y, PBTerritory.Width, PBTerritory.Height);
        //Font font = new Font("Tahoma", 8);

        for (int i = 0; i < m_UAV_Ctrl.m_nSquareH; i++)
        {
            for (int j = 0; j < m_UAV_Ctrl.m_nSquareW * m_nUAVs; j++)
            {
                e.Graphics.DrawRectangle(Pens.Black, x, y, w, h);
                //String coord = "(" + m_Area.m_zArea[i * m_Area.m_nSide + j].x.ToString() + ", " + m_Area.m_zArea[i * m_Area.m_nSide + j].y.ToString() + ")";
                //e.Graphics.DrawString(coord, font, Brushes.Black, x, y);
                x += w;
            }
            y += h;
            x = 0;
        }
    }

    // Нарисовать цель
    private void DrawHuman(PaintEventArgs e)
    {
        float fRadius = (float)PBTerritory.Width / m_UAV_Ctrl.m_nSquareH / 7;//m_Area.m_nSide / 10;
        e.Graphics.FillEllipse(Brushes.Green, (float)(m_Human.m_dX * m_dCoeff) - fRadius,
            (float)PBTerritory.Height - (float)(m_Human.m_dY * m_dCoeff) - fRadius, 2 * fRadius, 2 * fRadius);
    }

    // Нарисовать БПЛА
    private void DrawUAVs(PaintEventArgs e)
    {
        float fRadius = (float)PBTerritory.Width / m_UAV_Ctrl.m_nSquareH / 10;

        for (int i = 0; i < m_nUAVs; i++)
        {
            Pen ElPen = new Pen(Brushes.DarkBlue, 3);

            e.Graphics.FillEllipse(Brushes.CornflowerBlue, (float)(m_UAV_Ctrl.GetUavX(i) * m_dCoeff) - fRadius,
                (float)PBTerritory.Height - (float)(m_UAV_Ctrl.GetUavY(i) * m_dCoeff) - fRadius, 2 * fRadius, 2 * fRadius);

            e.Graphics.DrawEllipse(ElPen, (float)((m_UAV_Ctrl.GetUavX(i) - m_dUAVr) * m_dCoeff),
                (float)PBTerritory.Height - (float)((m_UAV_Ctrl.GetUavY(i) + m_dUAVr) * m_dCoeff), (float)(2 * m_dUAVr * m_dCoeff), (float)(2 * m_dUAVr * m_dCoeff));
        }
    }
 
    // Установка начальных значений
    private void SetInitialValues()     
    {
        m_dSTerr   = 500;
        m_nCount   = 1;
        m_nInitCount = 1;
        m_dMinProb = 0.9;
        m_dHumanV  = 5;
        m_dHumanR  = 4.7;
        m_dUAVv    = 20;
        m_dUAVr    = 3;
        m_dUAVtime = 2;
        m_nUAVs    = 2;
        m_nMethod  = 1;

        m_zResults = new Results[3];

        if (m_bBase)
        {
            List<string[]> listH_V = Query.Select("SELECT * FROM Human_V");
            List<string[]> listH_R = Query.Select("SELECT * FROM Human_R");
            List<string[]> listU_V = Query.Select("SELECT * FROM UAV_V");
            List<string[]> listU_R = Query.Select("SELECT * FROM UAV_R");
            List<string[]> listU_T = Query.Select("SELECT * FROM UAV_Time");

            m_dHumanV = Convert.ToDouble(listH_V[0][0]);
            m_dHumanR = Convert.ToDouble(listH_R[0][0]);
            m_dUAVv = Convert.ToDouble(listU_V[0][0]);
            m_dUAVr = Convert.ToDouble(listU_R[0][0]);
            m_dUAVtime = Convert.ToDouble(listU_T[0][0]);

            for (int i = 0; i < listH_V.Count; i++)
                CB_HumanV.Items.Add(listH_V[i][0]);
            for (int i = 0; i < listH_R.Count; i++)
                CB_HumanR.Items.Add(listH_R[i][0]);
            for (int i = 0; i < listU_V.Count; i++)
                CB_UAVv.Items.Add(listU_V[i][0]);
            for (int i = 0; i < listU_R.Count; i++)
                CB_UAVr.Items.Add(listU_R[i][0]);
            for (int i = 0; i < listU_T.Count; i++)
                CB_UAVTime.Items.Add(listU_T[i][0]);
        }   

        TB_S.Text        = m_dSTerr.ToString();
        TB_Count.Text    = m_nCount.ToString();
        TB_MinProb.Text  = m_dMinProb.ToString();
        CB_HumanV.Text   = m_dHumanV.ToString();
        CB_HumanR.Text   = m_dHumanR.ToString();
        CB_UAVv.Text     = m_dUAVv.ToString();
        CB_UAVr.Text     = m_dUAVr.ToString();
        CB_UAVTime.Text  = m_dUAVtime.ToString();
        TB_UAVCount.Text = m_nUAVs.ToString();
     
    }

    // Получить значения из текстовых полей
    private int GetInitialValues()
    {
        int nRet = 1;

        if (TB_S.TextLength != 0)
        {
            TB_S.BackColor = Color.White;
            m_dSTerr = Convert.ToDouble(TB_S.Text);
        }
        else
        {
            TB_S.BackColor = Color.Red;
            nRet = 0;
        }

        if (TB_Count.TextLength != 0)
        {
            TB_Count.BackColor = Color.White;
            m_nCount = (int)Convert.ToDouble(TB_Count.Text);
            m_nInitCount = m_nCount;
            m_zResults[0].dFindTimes = new double[m_nInitCount];
            m_zResults[1].dFindTimes = new double[m_nInitCount];
            m_zResults[2].dFindTimes = new double[m_nInitCount];
        }
        else
        {
            TB_Count.BackColor = Color.Red;
            nRet = 0;
        }

        if (TB_MinProb.Text.Length != 0)
        {
            TB_MinProb.BackColor = Color.White;
            m_dMinProb = Convert.ToDouble(TB_MinProb.Text);
        }
        else
        {
            TB_MinProb.BackColor = Color.Red;
            nRet = 0;
        }

        if (CB_HumanV.Text.Length != 0)
        {
            CB_HumanV.BackColor = Color.White;
            m_dHumanV = Convert.ToDouble(CB_HumanV.Text);
        }
        else
        {
            CB_HumanV.BackColor = Color.Red;
            nRet = 0;
        }

        if (CB_HumanR.Text.Length != 0)
        {
            CB_HumanR.BackColor = Color.White;
            m_dHumanR = Convert.ToDouble(CB_HumanR.Text);
        }
        else
        {
            CB_HumanR.BackColor = Color.Red;
            nRet = 0;
        }

        if (CB_UAVv.Text.Length != 0)
        {
            CB_UAVv.BackColor = Color.White;
            m_dUAVv = Convert.ToDouble(CB_UAVv.Text);
        }
        else
        {
            CB_UAVv.BackColor = Color.Red;
            nRet = 0;
        }

        if (CB_UAVr.Text.Length != 0)
        {
            CB_UAVr.BackColor = Color.White;
            m_dUAVr = Convert.ToDouble(CB_UAVr.Text);
        }
        else
        {
            CB_UAVr.BackColor = Color.Red;
            nRet = 0;
        }

        if (CB_UAVTime.Text.Length != 0)
        {
            CB_UAVTime.BackColor = Color.White;
            m_dUAVtime = Convert.ToDouble(CB_UAVTime.Text);
        }
        else
        {
            CB_UAVTime.BackColor = Color.Red;
            nRet = 0;
        }

        if (TB_UAVCount.Text.Length != 0)
        {
            TB_UAVCount.BackColor = Color.White;
            m_nUAVs = (int)Convert.ToDouble(TB_UAVCount.Text);
        }
        else
        {
            TB_UAVCount.BackColor = Color.Red;
            nRet = 0;
        }

        BT_Excel.Enabled = false;

        m_dTimeFind = 0;
        m_nFind = 0;

        return nRet;
    }

    // Обработчик для события нажатия кнопки "Рассчитать"
    private void BT_Calculate_Click(object sender, EventArgs e)
    {
        if ((BT_Calculate.Text == "Рассчитать") && (GetInitialValues() == 0))   // Если закончен предыдущий расчет и не все поля заполнены
        {
            MessageBox.Show("Заполните все поля");
            return;
        }

        if ((BT_Calculate.Text == "Рассчитать"))
        {       
            TB_Met1Time.Text = "";
            TB_Met1Prob.Text = "";
            TB_Met2Time.Text = "";
            TB_Met2Prob.Text = "";
            TB_Met3Time.Text = "";
            TB_Met3Prob.Text = "";

            GetOptimalUAV();

            if (m_bBase)
                InsToDB();
        }

        m_nCount--;         // Уменьшение количества испытаний

        if (timer1.Enabled == false)        // Если таймер выключен
        {
            // Создать новые объекты
            m_Area = new Area(m_dSTerr, m_dHumanR);
            m_Human = new Human(m_Area, m_dHumanV);
            m_UAV_Ctrl = new UAV_Control(m_nUAVs, m_dSTerr, m_dUAVv, m_dUAVr, m_dUAVtime, m_nMethod);

            m_nTicks = 0;

            timer1.Enabled = true;          // Запуск таймера
            BT_Calculate.Text = "Стоп";

            // Необходимо перерисовывать координаты
            m_bHuman = true;
            m_bUAVs = true;
        }
        // Если нажата кнопка "Стоп"
        else
        {
            timer1.Enabled = false;             // Выключить таймер
            BT_Calculate.Text = "Рассчитать";

            m_nMethod = 1;
            m_bHuman = false;
            m_bUAVs = false;
        }

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        m_nTicks++;

        if (m_Area.m_nSide != 1)        // Если в стороне больше 1 квадрата
            m_Human.Step();             // Перерасчет координат цели
        for (int i = 0; i < m_nUAVs; i++)   // Для каждого БПЛА из m_nUAVs
            m_UAV_Ctrl.Step(i, m_nMethod);         // Перерасчет координат БПЛА

        PBTerritory.Invalidate();       // Вызвать перерисовку

        for (int i = 0; i < m_nUAVs; i++)
        {
            int nRet = m_UAV_Ctrl.TargetAnalysys(i, m_Human.m_dX, m_Human.m_dY);    // Проверка есть ли цель в радиусе обнаружения

            if ((nRet == 1) || (((double)m_nTicks / 60) >= m_dUAVtime))     // Если цель найдена или превышено время полета
            {
                timer1.Stop();      // Остановить таймер

                if (nRet == 1)      // Если цель найдена
                {
                    m_dTimeFind += (double)m_nTicks / 60;           // Накапливать время поиска
                    m_zResults[m_nMethod - 1].dFindTimes[m_nFind] = (double)m_nTicks / 60;  // Занести время поиска в массив
                    m_nFind++;                                      // Увеличить счетчик нахождений цели
                }

                if (m_nCount > 0)   // Если проведены не все испытания
                    BT_Calculate_Click(sender, e);  // Сделать еще итерацию
                // Если прошли не все методы
                else if (m_nMethod < 3)
                {                    
                    ReflectMetResults();
                    m_nMethod++;
                    m_nCount = m_nInitCount;
                    BT_Calculate_Click(sender, e);
                }
                // Если испытания закончились
                else
                {
                    ReflectMetResults();
                    BT_Calculate.Text = "Рассчитать";
                    m_nMethod = 1;

                    // Занесение данных в Excel
                    if (ResExcel.CreateTable(m_zResults, m_dMinProb) == 1)
                        BT_Excel.Enabled = true;
                }

                return;
            }
        }
    }
    
    // Получить оптимальное количество БПЛА
    private void GetOptimalUAV()
    {
        int nOptimalUAV = 1;                    // Оптимальное количество БПЛА
        int nRow;                            // Количество рядов области поиска
        double dSUAV = m_dUAVv * m_dUAVtime;    // Расстояние, которое пролетит БПЛА        
        double dSquareS = Math.Sqrt(m_dSTerr);  // Корень из площади территории (длина стороны)

        if (dSUAV < dSquareS)       // Если БПЛА не пролетит даже стороны
            return;

        nRow = (int)Math.Ceiling(dSquareS / m_dUAVr / Math.Sqrt(2));

        while (dSquareS * nRow > dSUAV)     // Пока расстояние, необходимое для покрытия области поиска больше расстояния, которое способен пролететь БПЛА
        {
            nOptimalUAV += 1;
            nRow = (int)Math.Ceiling(dSquareS / m_dUAVr / Math.Sqrt(2) / nOptimalUAV);
        }

        if (m_nUAVs != nOptimalUAV && MessageBox.Show("Для текущих параметров рекомендуется оптимальное количество БПЛА: " 
            + nOptimalUAV + "\nПрименить исправление?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            m_nUAVs = nOptimalUAV;

        TB_UAVCount.Text = m_nUAVs.ToString();
    }

    private void InsToDB()
    {
        bool bFlag = true;

        if (!CB_HumanV.Items.Contains(m_dHumanV.ToString()))        // Если поля нет в БД
            Query.InUpDel("INSERT INTO Human_V(Velocity) VALUES ('" + m_dHumanV.ToString("0.0", CInfo) + "')", ref bFlag);
        if (!CB_HumanR.Items.Contains(m_dHumanR.ToString()))
            Query.InUpDel("INSERT INTO Human_R(Radius) VALUES ('" + m_dHumanR.ToString("0.0", CInfo) + "')", ref bFlag);
        if (!CB_UAVv.Items.Contains(m_dUAVv.ToString()))
            Query.InUpDel("INSERT INTO UAV_V(Velocity) VALUES ('" + m_dUAVv.ToString("0.0", CInfo) + "')", ref bFlag);
        if (!CB_UAVr.Items.Contains(m_dUAVr.ToString()))
            Query.InUpDel("INSERT INTO UAV_R(Radius) VALUES ('" + m_dUAVr.ToString("0.0", CInfo) + "')", ref bFlag);
        if (!CB_UAVTime.Items.Contains(m_dUAVtime.ToString()))
            Query.InUpDel("INSERT INTO UAV_Time(Time) VALUES ('" + m_dUAVtime.ToString("0.0", CInfo) + "')", ref bFlag);

        Query.InUpDel("INSERT INTO Human(Velocity, Radius) VALUES ('" + m_dHumanV.ToString("0.0", CInfo) + "','" + m_dHumanR.ToString("0.0", CInfo) + "')", ref bFlag);
        Query.InUpDel("INSERT INTO UAV(Velocity, Radius, Time) VALUES ('" + m_dUAVv.ToString("0.0", CInfo) + "','" + m_dUAVr.ToString("0.0", CInfo) + "','" + 
            m_dUAVtime.ToString("0.0", CInfo) + "')", ref bFlag);

    }

    private void ReflectMetResults()
    {
        TextBox TB_Time = null;
        TextBox TB_Prob = null;
        bool bFlag = false;
        double dProb;           // Вероятность нахождения цели

        switch (m_nMethod)
        {
            case 1:
                TB_Time = TB_Met1Time;
                TB_Prob = TB_Met1Prob;
                break;
            case 2:
                TB_Time = TB_Met2Time;
                TB_Prob = TB_Met2Prob;
                break;
            case 3:
                TB_Time = TB_Met3Time;
                TB_Prob = TB_Met3Prob;
                break;
        }

        if (m_nFind != 0)   // Если были нахождения цели
        {
            m_dTimeFind /= m_nFind;     // Среднее время поиска
            TB_Time.Text = m_dTimeFind.ToString("0.00");
        }
        else
            TB_Time.Text = "-";

        dProb = (double)m_nFind / m_nInitCount;      // Вероятность нахождения цели   
        TB_Prob.Text = dProb.ToString("0.00");
        m_zResults[m_nMethod - 1].nMethod = m_nMethod - 1;
        m_zResults[m_nMethod - 1].dTime = m_dTimeFind;
        m_zResults[m_nMethod - 1].dProb = dProb; 

        if (m_bBase)
        // Занесение данных в таблицу Report, Id Human и Id UAV получить селектом по значениям
            Query.InUpDel("INSERT INTO Report(Date, Area, Id_Human, Id_UAV, Method, UAV_Count, Init_Count, Time, Probability) " +
            "VALUES ('" + DateTime.Now.ToString("g") + "','" + m_dSTerr.ToString("0.0", CInfo) + "','" + 
            Query.Select("SELECT id FROM Human WHERE Velocity = " + m_dHumanV.ToString("0.0", CInfo) + " AND Radius = " + m_dHumanR.ToString("0.0", CInfo))[0][0] + "','" +
            Query.Select("SELECT id FROM UAV WHERE Velocity = " + m_dUAVv.ToString("0.0", CInfo) + " AND Radius = " + m_dUAVr.ToString("0.0", CInfo) +
            " AND Time = " + m_dUAVtime.ToString("0.0", CInfo))[0][0] + "','" + m_nMethod + "','" + m_nUAVs + "','" + m_nInitCount + "','" + 
            m_dTimeFind.ToString("0.00", CInfo) + "','" + dProb.ToString("0.0", CInfo) + "')", ref bFlag);

        m_dTimeFind = 0;
        m_nFind = 0;
    }

    // Обработчик для события ввода данных в каждое текстовое поле
    private void TB_KeyPress(object sender, KeyPressEventArgs e)
   {
        // Запрет всех символов, кроме управляющих, цифр и ','
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
              e.Handled = true;

        // Запрет использования больше одного символа '.'
        try
        {
            if ((e.KeyChar == ',') && ((sender as ComboBox).Text.IndexOf(',') > -1))
                e.Handled = true;
        }
        catch
        {
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                e.Handled = true;
        }
    }

    private void BT_Excel_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start(Application.StartupPath + "\\Results.xlsm");
    }
}
