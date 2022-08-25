using System;
using static System.Math;

class Human
{
    Area m_Zone;        // Объект территории
    public double m_dX; // Координаты цели
    public double m_dY;

    int m_nSquare;      // Квадрат в котором находится цель
    int m_nDirection;   // Направление движения
    int m_nNextSquare;  // Квадрат, в который направляется цель

    double m_dSinCos;   // Синус и косинус корня из 2 на 2
    double m_dV;        // Скорость цели в км/ч

    int m_nCurSteps;    // Количество шагов - изменений координат цели
    double m_dConstTime;// Константа времени для привязки к реальному

    bool m_bCentre;     // Флаг, находится ли цель в центре квадрата

    // Конструктор
    public Human(Area objArea, double dHumanV)
    {
        m_Zone = objArea;
        m_dV = dHumanV;

        Random Rand = new Random();
        m_nSquare = Rand.Next(0, m_Zone.m_nSide * m_Zone.m_nSide);      // Начальная точка - случайный квадрат
        System.Threading.Thread.Sleep(15);

        m_dX = m_Zone.m_zArea[m_nSquare].Xc;    // Координаты центра начального квадрата
        m_dY = m_Zone.m_zArea[m_nSquare].Yc;

        m_dSinCos = Sqrt(2) / 2;

        m_bCentre = true;

        m_nCurSteps = 0;
        m_dConstTime = (double)1 / 60;     // Константа времени для привязки к реальному 1 тик = 1 минута
    }

    // Изменение координат
    public void Step()
    {
        m_nCurSteps++;
        double dLenght = m_dV * m_dConstTime * m_nCurSteps;      // Расстояние от центра текущего квадрата

        if (m_bCentre)      // Если цель в центре квадрата
        {
            m_nDirection = GetDirection();  // Получить новое направление
            m_bCentre = false;
        }

        switch (m_nDirection)
        {
            // Северо-запад
            case 1:
                m_dX = m_Zone.m_zArea[m_nSquare].Xc - dLenght * m_dSinCos;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc + dLenght * m_dSinCos;
                m_nNextSquare = m_nSquare - m_Zone.m_nSide - 1;
                break;
            
            // Север
            case 2:
                m_dX = m_Zone.m_zArea[m_nSquare].Xc;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc + dLenght;
                m_nNextSquare = m_nSquare - m_Zone.m_nSide;
                break;

            // Северо-восток
            case 3:
                m_dX = m_Zone.m_zArea[m_nSquare].Xc + dLenght * m_dSinCos;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc + dLenght * m_dSinCos;
                m_nNextSquare = m_nSquare - m_Zone.m_nSide + 1;
                break;

            // Восток
            case 4:
                m_dX = m_Zone.m_zArea[m_nSquare].Xc + dLenght;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc;
                m_nNextSquare = m_nSquare + 1;
                break;

            // Юго-восток
            case 5:
                m_dX = m_Zone.m_zArea[m_nSquare].Xc + dLenght * m_dSinCos;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc - dLenght * m_dSinCos;
                m_nNextSquare = m_nSquare + m_Zone.m_nSide + 1;
                break;

            // Юг
            case 6:
                m_dX = m_Zone.m_zArea[m_nSquare].Xc;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc - dLenght;
                m_nNextSquare = m_nSquare + m_Zone.m_nSide;
                break;

            // Юго-запад
            case 7:
                m_dX = m_Zone.m_zArea[m_nSquare].Xc - dLenght * m_dSinCos;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc - dLenght * m_dSinCos;
                m_nNextSquare = m_nSquare + m_Zone.m_nSide - 1;
                break;

            // Запад
            case 8:
                m_dX = m_Zone.m_zArea[m_nSquare].Xc - dLenght;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc;
                m_nNextSquare = m_nSquare - 1;
                break;
        }

        // Проверка пришли ли в центр след. квадрата
        if (!m_bCentre)
        {
            // Если двигаемся вправо (Х увеличивается) и m_dX стало больше центра, то перешли через центр
            if ( (((m_nDirection == 3 || m_nDirection == 4 || m_nDirection == 5) && m_dX >  m_Zone.m_zArea[m_nNextSquare].Xc)
            // Если двигаемся влево (Х уменьшается) и m_dX стало меньше центра, то перешли через центр
              ||  ((m_nDirection == 1 || m_nDirection == 8 || m_nDirection == 7) && m_dX <  m_Zone.m_zArea[m_nNextSquare].Xc)
            // Если двигаемся на север или юг (Х не изменяется), то проверяем условия по Y
              || ((m_nDirection == 2 || m_nDirection == 6)                       && m_dX == m_Zone.m_zArea[m_nNextSquare].Xc))
            // Если двигаемся вверх (Y увеличивается) и m_dY стало больше центра, то перешли через центр
              && (((m_nDirection == 1 || m_nDirection == 2 || m_nDirection == 3) && m_dY >  m_Zone.m_zArea[m_nNextSquare].Yc)
            // Если двигаемся вниз (Y уменьшается) и m_dY стало меньше центра, то перешли через центр
              || ((m_nDirection == 5 || m_nDirection == 6 || m_nDirection == 7)  && m_dY <  m_Zone.m_zArea[m_nNextSquare].Yc)
            // Если двигаемся на восток или запад (Y не изменяется), то проверяем условия по X
              || ((m_nDirection == 4 || m_nDirection == 8)                       && m_dY == m_Zone.m_zArea[m_nNextSquare].Yc)) )
            {
                // Цель пришла в центр следующего квадрата
                m_nSquare = m_nNextSquare;      

                m_dX = m_Zone.m_zArea[m_nSquare].Xc;
                m_dY = m_Zone.m_zArea[m_nSquare].Yc;

                m_nCurSteps = 0;
                m_bCentre = true;
            }
        }

    }

    // Получить новое случайное направление
    int GetDirection()
    {
        int nDirection = 0;

        Random Rand = new Random();

        // Верхний левый угол
        if (m_nSquare == 0)
            nDirection = Rand.Next(4, 7);
        // Верхний правый угол
        else if (m_nSquare == m_Zone.m_nSide - 1)
            nDirection = Rand.Next(6, 9);
        // Нижний левый угол
        else if (m_nSquare == m_Zone.m_nSide * (m_Zone.m_nSide - 1))
            nDirection = Rand.Next(2, 5);
        // Нижний правый угол
        else if (m_nSquare == m_Zone.m_nSide * m_Zone.m_nSide - 1)
        {
            int[] nMas = new int[] { 1, 2, 8 };     // Возможные направления
            nDirection = Rand.Next(0, 3);
            nDirection = nMas[nDirection];
        }
        // Верхняя сторона
        else if (m_nSquare < m_Zone.m_nSide)
            nDirection = Rand.Next(4, 9);
        // Левая сторона
        else if (m_nSquare % m_Zone.m_nSide == 0)
            nDirection = Rand.Next(2, 7);
        // Правая сторона
        else if ((m_nSquare + 1) % m_Zone.m_nSide == 0)
        {
            int[] nMas = new int[] { 1, 2, 6, 7, 8 };     // Возможные направления
            nDirection = Rand.Next(0, 5);
            nDirection = nMas[nDirection];
        }
        // Нижняя сторона
        else if ((m_nSquare > m_Zone.m_nSide * (m_Zone.m_nSide - 1)) && m_nSquare < m_Zone.m_nSide * m_Zone.m_nSide - 1)
        {
            int[] nMas = new int[] { 1, 2, 3, 4, 8 };     // Возможные направления
            nDirection = Rand.Next(0, 5);
            nDirection = nMas[nDirection];
        }
        // Центр, возможны все направления
        else
            nDirection = Rand.Next(1, 9);

        return nDirection;
    }
}
