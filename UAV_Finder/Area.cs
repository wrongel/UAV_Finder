using System;
using static System.Math;

// Структура с информацией об одном квадрате
struct Square
{
    public int x;           // Индексы матрицы
    public int y;
    public double Xc;       // Координаты центра
    public double Yc;
}

class Area
{
    double m_dSArea;            // Площадь территории
    double m_dRhuman;           // Радиус видимости человека
    double m_dSquareArea;       // Площадь одного квадрата
    public Square[] m_zArea;    // Массив квадратов
    public int m_nSide;         // Количество квадратов в стороне

    // Конструктор
    public Area(double dSarea, double dRhuman)
    {
        m_dSArea  = dSarea;
        m_dRhuman = dRhuman;

        int nSquareAmount = GetSquareAmount(dSarea);    // Получить общее количество квадратов
        m_zArea = new Square[nSquareAmount];            // Выделение памяти под nSquareAmount квадратов
        m_dSquareArea = dSarea / nSquareAmount;         // Площадь одного квадрата

        FillSquareInfo(nSquareAmount);                  // Заполнить информацию о каждом квадрате
    }

    // Получить общее количество квадратов
    private int GetSquareAmount(double dSarea)
    {
        double dSquares = dSarea / (Math.Pow(m_dRhuman, 2) * 2);  // Кол-во квадратов по формуле
        dSquares = Sqrt(dSquares);                          // Кол-во квадратов должно быть степенью числа, берем корень
        int nSquareAmount = (int)dSquares;                  
        if (dSquares - nSquareAmount != 0)                  // Есть ли дробная часть
        {
            dSquares = Ceiling(dSquares);                   // Округляем в большую сторону
            nSquareAmount = (int)Pow(dSquares, 2);          // Возводим в степень
        }

        return nSquareAmount;
    }

    // Заполнить информацию о каждом квадрате
    private void FillSquareInfo(int nSquareAmount)
    {
        m_nSide = (int)Sqrt(nSquareAmount);     // Квадратов в стороне
        double dSqrtS = Sqrt(m_dSquareArea);    // Корень из площади, сторона территории

        for (int i = 0; i < m_nSide; i++)       // i = y коорд
            for (int j = 0; j < m_nSide; j++)   // j = x коорд
            {
                m_zArea[i * m_nSide + j].x = j + 1;
                m_zArea[i * m_nSide + j].y = i + 1;
                m_zArea[i * m_nSide + j].Xc = (j + 1 - 0.5) * dSqrtS;               // Определение координат центров по формулам
                m_zArea[i * m_nSide + j].Yc = (m_nSide - (i + 1) + 0.5) * dSqrtS;
            }

    }
}
