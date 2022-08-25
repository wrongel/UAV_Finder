using System;
using static System.Math;

class UAV_Control
{
    public Square[] m_zArea;// Массив квадратов

    double m_dWidth;        // Длина  зоны для 1 БПЛА
    double m_dHeight;       // Ширина зоны для 1 БПЛА

    public int m_nSquareH;  // Количество квадратов по высоте для 1 БПЛА
    public int m_nSquareW;  // Количество квадратов по ширине для 1 БПЛА

    double m_dSquareSide;   // Сторона 1 квадрата
    int m_nUAV;             // Количество БПЛА
    UAV[] m_UAVs;           // Массив объектов БПЛА
    double m_dUAVv;         // Скорость БПЛА
    double m_dUAVr;         // Радиус видимости БПЛА
    double m_dUAVtime;      // Время работы БПЛА

    // Конструктор
    public UAV_Control(int nUAV, double dSArea, double dV, double dR, double dUAVtime, int nMethod)
    {
        m_nUAV = nUAV;
        m_UAVs = new UAV[m_nUAV];   // Выделение памяти под nUAV БПЛА
        m_dUAVv = dV;
        m_dUAVr = dR;
        m_dUAVtime = dUAVtime;

        m_dHeight = Sqrt(dSArea);
        m_dWidth = Sqrt(dSArea) / m_nUAV;

        double dASquare = m_dUAVr * Sqrt(2);            // Максимальная сторона квадрата

        m_nSquareW = (int)Ceiling(m_dWidth / dASquare); // Делим ширину на макс. сторону, округляем в большую сторону

        m_dSquareSide = m_dWidth / m_nSquareW;          // Получаем итоговую сторону квадрата
        m_nSquareH = (int)Ceiling(m_dHeight / m_dSquareSide);      // Округление в большую сторону

        m_zArea = new Square[m_nSquareH * m_nSquareW * m_nUAV]; // Выделение памяти под квадраты для всях БПЛА
        FillSquareInfo();   // Заполнить информацию о каждом квадрате
        
        // Создать объекты БПЛА
        Create_UAV(nMethod);
       
    }

    // Заполнить информацию о каждом квадрате
    private void FillSquareInfo()
    {
        for (int i = 0; i < m_nSquareH; i++)                // i = y коорд
            for (int j = 0; j < m_nSquareW * m_nUAV; j++)   // j = x коорд
            {
                m_zArea[i * m_nSquareW * m_nUAV + j].x = j + 1;
                m_zArea[i * m_nSquareW * m_nUAV + j].y = i + 1;
                m_zArea[i * m_nSquareW * m_nUAV + j].Xc = (j + 1 - 0.5) * m_dSquareSide;           // Корень из площади квадрата - есть сторона
                m_zArea[i * m_nSquareW * m_nUAV + j].Yc = (m_nSquareH - (i + 1) + 0.5) * m_dSquareSide;
            }
    }

    // Создать объекты БПЛА
    public void Create_UAV(int nMethod)
    {
        for (int i = 0; i < m_nUAV; i++)
        {
            if (nMethod == 1)
                m_UAVs[i] = new UAV(i, i * m_nSquareW, m_zArea, m_nSquareW * m_nUAV, m_nSquareH, m_nSquareW, m_dUAVv, m_dUAVr, m_dUAVtime);
            else if (nMethod > 1)
            {
                Random rand = new Random();              
                m_UAVs[i] = new UAV(i, i * m_nSquareW, m_zArea, m_nSquareW * m_nUAV, m_nSquareH, m_nSquareW, m_dUAVv, m_dUAVr, m_dUAVtime);
                m_UAVs[i].InitAddPar(nMethod);
            }
        }
    }

    // Получить координату Х БПЛА с индексом nIndex
    public double GetUavX(int nIndex)
    {
        return m_UAVs[nIndex].m_dX;
    }
    // Получить координату Y БПЛА с индексом nIndex
    public double GetUavY(int nIndex)
    {
        return m_UAVs[nIndex].m_dY;
    }

    // Перерасчет координат БПЛА с индексом nIndex
    public void Step(int nIndex, int nMethod)
    {
        if (nMethod == 1)
            m_UAVs[nIndex].Step();
        else
            m_UAVs[nIndex].Step2(nMethod);

        //switch (nMethod)
        //{
        //    case 1:
        //        m_UAVs[nIndex].Step();
        //        break;
        //    case 2:
        //        m_UAVs[nIndex].Step2();
        //        break;
        //    case 3:
        //        m_UAVs[nIndex].Step3();
        //        break;
        //}
    }

    // Проверка обнаружения цели БПЛА с индексом nIndex
    public int TargetAnalysys(int nIndex, double dTargetX, double dTargetY)
    {
        return m_UAVs[nIndex].TargetAnalysys(dTargetX, dTargetY);
    }
}

// Класс БПЛА
class UAV
{
    public Square[] m_zArea;    // Массив квадратов всей территории (не только территориии отдельного БПЛА)

    int m_nNumber;          // Поряковый номер БПЛА
    int m_nSquare;          // Квадрат в котором находится БПЛА
    int m_nStartSquare;     // Начальный квадрат для БПЛА

    public double m_dX;     // Координаты БПЛА
    public double m_dY;

    double m_dV;            // Скорость БПЛА в км/ч
    double m_dUAVr;         // Радиус видимости БПЛА в км
    double m_dUAVtime;      // Время работы БПЛА в часах

    int m_nDirection;   // Направление полета БПЛА
    int m_nNextSquare;  // Номер квадрата, в который летит БПЛА
    int m_nSquareH;     // Кол-во квадраторв по высоте территории поиска 1 бпла
    int m_nSquareW;     // Кол-во квадраторв по ширине территории поиска 1 бпла
    int m_nFullSquareW; // Кол-во квадратов ширине всей территории

    int m_nCurSteps;    // Количество шагов - изменений координат БПЛА
    double m_dConstTime;// Константа времени для привязки к реальному

    double m_dOffsetX;  // Погрешности по осям при переходе через центр очередного квадрата
    double m_dOffsetY;

    bool m_bCentre;     // Флаг, находится ли БПЛА в центре квадрата
    bool m_bWay;        // true - прямой ход, false - обратный

    // Параметры для метода 2
    int[] m_nIndex;     // Массив индексов квадратов зоны поиска

    // Параметры для метода 3
    static int[] m_nTour;
    int m_iTourInd;  

    // Конструктор
    public UAV(int nNumber, int nStartArea, Square[] zArea, int nFullSquareW, int nSquareH, int nSquareW, double dV, double dR, double dUAVtime)
    {
        m_nNumber = nNumber;
        m_dV = dV;
        m_dUAVr = dR;
        m_dUAVtime = dUAVtime;

        m_nStartSquare = nStartArea;
        m_nSquare = nStartArea;

        m_zArea = zArea;
        m_nFullSquareW = nFullSquareW;
        m_nSquareH = nSquareH;
        m_nSquareW = nSquareW;
        m_nNextSquare = -1;

        m_dX = m_zArea[m_nSquare].Xc;
        m_dY = m_zArea[m_nSquare].Yc;
        m_dOffsetX = 0;
        m_dOffsetY = 0;
        m_bCentre = true;
        m_bWay = true;

        m_iTourInd = 1;

        m_nCurSteps = 0;
        m_dConstTime = (double)1 / 60;     // Константа времени для привязки к реальному 1 тик = 1 минута
    }

    // Такой же алгоритм движения как и у цели
    public void Step()
    {
        m_nCurSteps++;
        double dLenght = m_dV * m_dConstTime * m_nCurSteps;      // Расстояние от центра текущего квадрата

        if (m_bCentre)  // Если БПЛА в центре квадрата
        {
            m_nDirection = GetDirection2();  // Получить новое направление
            m_bCentre = false;
        }

        switch (m_nDirection)
        {
            // Север
            case 2:
                m_dX = m_zArea[m_nSquare].Xc;
                m_dY = m_zArea[m_nSquare].Yc + m_dOffsetY + dLenght;

                m_nNextSquare = m_nSquare - m_nFullSquareW;
                if (m_nSquareW == 1)      // Обработка тривиального случая, когда БПЛА летит только на север
                    m_nNextSquare = m_nSquare - m_nFullSquareW * (m_nSquareH - 1);
                break;

            // Восток
            case 4:
                m_dX = m_zArea[m_nSquare].Xc + m_dOffsetX + dLenght;
                m_dY = m_zArea[m_nSquare].Yc;

                //m_nNextSquare = m_nSquare + m_nSquareW - 1;
                m_nNextSquare = m_nSquare + 1;
                break;

            // Юг
            case 6:
                m_dX = m_zArea[m_nSquare].Xc;
                m_dY = m_zArea[m_nSquare].Yc + m_dOffsetY - dLenght;

                m_nNextSquare = m_nSquare + m_nFullSquareW;
                if (m_nSquareW == 1)      // Обработка тривиального случая, когда БПЛА летит только на юг
                    m_nNextSquare = m_nSquare + m_nFullSquareW * (m_nSquareH - 1);
                break;

            // Запад
            case 8:
                m_dX = m_zArea[m_nSquare].Xc + m_dOffsetX - dLenght;
                m_dY = m_zArea[m_nSquare].Yc;

                //m_nNextSquare = m_nSquare - (m_nSquareW - 1);
                m_nNextSquare = m_nSquare - 1;
                break;
        }

        // Проверка пришли ли в центр след. квадрата
        if (!m_bCentre)
        {
            // Если двигаемся вправо (Х увеличивается) и m_dX стало больше центра, то перешли через центр
            if ((((m_nDirection == 3 || m_nDirection == 4 || m_nDirection == 5) && m_dX > m_zArea[m_nNextSquare].Xc)
            // Если двигаемся влево (Х уменьшается) и m_dX стало меньше центра, то перешли через центр
              || ((m_nDirection == 1 || m_nDirection == 8 || m_nDirection == 7) && m_dX < m_zArea[m_nNextSquare].Xc)
            // Если двигаемся на север или юг (Х не изменяется), то проверяем условия по Y
              || ((m_nDirection == 2 || m_nDirection == 6) && m_dX == m_zArea[m_nNextSquare].Xc))
            // Если двигаемся вверх (Y увеличивается) и m_dY стало больше центра, то перешли через центр
              && (((m_nDirection == 1 || m_nDirection == 2 || m_nDirection == 3) && m_dY > m_zArea[m_nNextSquare].Yc)
            // Если двигаемся вниз (Y уменьшается) и m_dY стало меньше центра, то перешли через центр
              || ((m_nDirection == 5 || m_nDirection == 6 || m_nDirection == 7) && m_dY < m_zArea[m_nNextSquare].Yc)
            // Если двигаемся на восток или запад (Y не изменяется), то проверяем условия по X
              || ((m_nDirection == 4 || m_nDirection == 8) && m_dY == m_zArea[m_nNextSquare].Yc)))
            {
                // БПЛА пришел в центр следующего квадрата
                m_nSquare = m_nNextSquare;

                m_dOffsetX = m_dX - m_zArea[m_nSquare].Xc;
                m_dOffsetY = m_dY - m_zArea[m_nSquare].Yc;

                //m_dX = m_zArea[m_nSquare].Xc + m_dOffsetX;
                //m_dY = m_zArea[m_nSquare].Yc + m_dOffsetY;

                m_nCurSteps = 0;
                m_bCentre = true;
            }
        }
    }

    // Инициировать специальные параметры для метода 2
    public void InitAddPar(int nMethod)
    {
        int k = 0;

        m_nIndex = new int[m_nSquareH * m_nSquareW];
        for (int i = 0; i < m_zArea.Length; i += m_nFullSquareW)
            for (int j = m_nNumber * m_nSquareW; j < m_nSquareW * (m_nNumber + 1); j++)           
            {
                m_nIndex[k] = i + j;
                k++;
            }

        m_nSquare = m_nStartSquare;
        m_dX = m_zArea[m_nSquare].Xc;
        m_dY = m_zArea[m_nSquare].Yc;

        if ((m_nTour == null || m_nTour.Length != m_nIndex.Length) && nMethod == 3)
        {
            Annealing Anneal = new Annealing(m_zArea, this.m_nIndex);
            m_nTour = new int[m_nIndex.Length];
            m_nTour = Anneal.Anneal(m_nStartSquare);
        }
        if (nMethod == 3)
            m_nSquare = m_nIndex[m_nTour[0]];

    }

    public void Step2(int nMethod)
    {
        bool bXDir;
        bool bYDir;
        m_nCurSteps++;
        double dLenght = m_dV * m_dConstTime * m_nCurSteps;      // Расстояние от центра текущего квадрата
        double dAlpha;

        if (m_bCentre && nMethod == 3)
        {
            m_nNextSquare = m_nIndex[m_nTour[m_iTourInd]];
            m_bCentre = false;
        }
        else if (m_bCentre)  // Если БПЛА в центре квадрата
        {
            Random rand = new Random();
            do
            {
                m_nNextSquare = rand.Next(m_nSquareH * m_nSquareW);
                System.Threading.Thread.Sleep(15);                      // Пауза 15 мс для новых чилес ГСЧ
            }
            while (m_nNextSquare == m_nSquare);      // След квадрат должен отличаться от текущего
                m_nNextSquare = m_nIndex[m_nNextSquare];
            m_bCentre = false;
        }

        dAlpha = Atan2(Abs(m_zArea[m_nSquare].Yc - m_zArea[m_nNextSquare].Yc), Abs(m_zArea[m_nSquare].Xc - m_zArea[m_nNextSquare].Xc));

        if (m_zArea[m_nSquare].Yc - m_zArea[m_nNextSquare].Yc < 0)
        {
            m_dY = m_zArea[m_nSquare].Yc + dLenght * Sin(dAlpha);
            bYDir = true;       // Движение вверх
        }
        else
        {
            m_dY = m_zArea[m_nSquare].Yc - dLenght * Sin(dAlpha);
            bYDir = false;      // Движение вниз
        }

        if (m_zArea[m_nSquare].Xc - m_zArea[m_nNextSquare].Xc < 0)
        {
            m_dX = m_zArea[m_nSquare].Xc + dLenght * Cos(dAlpha);
            bXDir = true;      // Вправо
        }
        else
        {
            m_dX = m_zArea[m_nSquare].Xc - dLenght * Cos(dAlpha);
            bXDir = false;       // Влево
        }

        // Если двигаемся вправо (Х увеличивается) и m_dX стало больше центра, то перешли через центр
        if (((bXDir == true && m_dX > m_zArea[m_nNextSquare].Xc)
        // Если двигаемся влево (Х уменьшается) и m_dX стало меньше центра, то перешли через центр
         || (bXDir == false && /*m_dX < m_zArea[m_nNextSquare].Xc)*/ (m_zArea[m_nNextSquare].Xc - m_dX > 1E-10))
        // Если двигаемся вверх (Y увеличивается) и m_dY стало больше центра, то перешли через центр
         || (bYDir == true && m_dY > m_zArea[m_nNextSquare].Yc)
        // Если двигаемся вниз (Y уменьшается) и m_dY стало меньше центра, то перешли через центр
         || (bYDir == false && m_dY < m_zArea[m_nNextSquare].Yc)) && !m_bCentre)

        {
            // БПЛА пришел в центр следующего квадрата
            m_nSquare = m_nNextSquare;

            m_dX = m_zArea[m_nSquare].Xc;
            m_dY = m_zArea[m_nSquare].Yc;

            m_nCurSteps = 0;
            m_bCentre = true;

            if (m_bWay)
                m_iTourInd++;
            else
                m_iTourInd--;

            if (m_nTour != null && (m_iTourInd == m_nTour.Length - 1 || m_iTourInd == 0))
                m_bWay = !m_bWay;
        }
    }

    // Получить новое направление в соответствии с алгоритмом движения
    int GetDirection()
    {
        int nDirection = 0;
        bool bFirstWay = false;     // Флаг первого перехода на обратный ход

        if (m_bWay == true) // Прямой ход
        {
            if (m_nSquare == m_nStartSquare)
            {
                if (m_nSquareW == 1)      // Обработка тривиального случая, когда БПЛА летит только на юг
                    nDirection = 6;       // Юг
                else
                    nDirection = 4;       // Восток
            }
            else if ((m_nDirection == 4 && (m_nSquare + 1) % m_nSquareW == 0) ||   // Если предыдущее направление было на восток и дошли до края зоны поиска, в противном случае продолжаем двигаться на восток
                     (m_nDirection == 8 && m_nSquare % m_nSquareW == 0))     // Если предыдущее направление было на запад и дошли до левого края зоны поиска, в противном случае продолжаем двигаться на запад
            {
                nDirection = 6;     // Юг

                if (m_nSquare >= m_nFullSquareW * (m_nSquareH - 1))     // Если находимся в последнем ряду
                {
                    m_bWay = false;     // Начать обратный ход
                    bFirstWay = true;
                }
           
            }
            else if (m_nDirection == 6)   // Если предыдущее направление было на юг
            {
                if (m_nSquare % m_nSquareW == 0)    // Если мы на левом краю зоны поиска, то двигаемся на восток, в противном случае - на запад
                    nDirection = 4;     // Восток
                else if ((m_nSquare + 1) % m_nSquareW == 0) // Если на правом краю
                    nDirection = 8;     // Запад
            }
            else
                nDirection = m_nDirection;  // Сохраняем старое направление
        }

        if (m_bWay == false) // Обратный ход
        {
            if (bFirstWay && m_nSquareW == 1)      // Обработка тривиального случая, когда БПЛА летит только на север
                nDirection = 2;     // Север
            else if (bFirstWay && m_nDirection == 4)    // Если первый раз зашли в обратный ход, то меняем напрвление на противоположное
                nDirection = 8;     // Запад
            else if (bFirstWay && m_nDirection == 8)
                nDirection = 4;     // Восток
            else if ((m_nDirection == 4 && (m_nSquare + 1) % m_nSquareW == 0) ||   // Если предыдущее направление было на восток и дошли до края зоны поиска, в противном случае продолжаем двигаться на восток
                     (m_nDirection == 8 && m_nSquare % m_nSquareW == 0))     // Если предыдущее направление было на запад и дошли до левого края зоны поиска, в противном случае продолжаем двигаться на запад
            {
                nDirection = 2;     // Север

                if (m_nSquare < m_nFullSquareW)     // Если находимся в первом ряду
                {
                    nDirection = 4;           // Начальное направление для прямого хода - всегда восток
                    if (m_nSquareW == 1)      // Обработка тривиального случая, когда БПЛА летит только на север
                        nDirection = 6;       // Юг
                    m_bWay = true;            // Начать прямой ход           
                }
            }
            else if (m_nDirection == 2)   // Если предыдущее направление было на юг
            {
                if (m_nSquare % m_nSquareW == 0)    // Если мы на левом краю зоны поиска, то двигаемся на восток, в противном случае - на запад
                    nDirection = 4;
                else if ((m_nSquare + 1) % m_nSquareW == 0) // Если на правом краю
                    nDirection = 8;
            }
            else
                nDirection = m_nDirection;  // Сохраняем старое направление
        }

        return nDirection;
    }

    int GetDirection2()
    {
        int nDirection = 0;
        bool bFirstWay = false;     // Флаг первого перехода на обратный ход

        if (m_bWay == true) // Прямой ход
        {
            if ((m_nSquare == m_nStartSquare) || (m_nDirection == 4 && m_nSquare <= m_nFullSquareW))
                nDirection = 6;       // Юг
            else if ((m_nDirection == 6 && m_nSquare >= m_nFullSquareW * (m_nSquareH - 1)) ||    // Если предыдущее направление было на юг и находимся в последнем ряду
                     (m_nDirection == 2 && m_nSquare < m_nFullSquareW))            // Если север и в 1 ряду   
            {
                if ((m_nSquare + 1) % m_nSquareW == 0)
                {
                    m_bWay = false;     // Начать обратный ход
                    bFirstWay = true;
                }
                else
                    nDirection = 4;
            }
            else if (m_nDirection == 4 && m_nSquare >= m_nFullSquareW * (m_nSquareH - 1))
                nDirection = 2;
            else
                nDirection = m_nDirection;  // Сохраняем старое направление
           
        }

        if (m_bWay == false) // Обратный ход
        {
            if (bFirstWay && m_nSquareW == 1)      // Обработка тривиального случая, когда БПЛА летит только на север
                nDirection = 2;     // Север
            else if (bFirstWay && m_nDirection == 2)    // Если первый раз зашли в обратный ход, то меняем напрвление на противоположное
                nDirection = 6;     // Юг
            else if (bFirstWay && m_nDirection == 6)
                nDirection = 2;     // Север

            else if ((m_nDirection == 6 && m_nSquare >= m_nFullSquareW * (m_nSquareH - 1)) ||    // Если предыдущее направление было на юг и находимся в последнем ряду
                     (m_nDirection == 2 && m_nSquare < m_nFullSquareW))            // Если север и в 1 ряду   
            {
                nDirection = 8;
                if (m_nSquare == m_nStartSquare)
                {
                    m_bWay = true;
                    nDirection = 6;
                }     
            }
            else if (m_nDirection == 8 && m_nSquare >= m_nFullSquareW * (m_nSquareH - 1))
                nDirection = 2;
            else if (m_nDirection == 8 && m_nSquare <= m_nFullSquareW)
                nDirection = 6;
            else
                nDirection = m_nDirection;  // Сохраняем старое направление
        }

        return nDirection;
    }

    // Проверка обнаружения цели
    public int TargetAnalysys(double dTargetX, double dTargetY)
    {
        double dR = Sqrt( Pow((m_dX - dTargetX), 2) + Pow((m_dY - dTargetY), 2) );  // Формула

        if (dR < m_dUAVr)
            return 1;       // Цель найдена
        else
            return 0;       // Цель не найдена
    }
}