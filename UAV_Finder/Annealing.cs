using System;
using System.Linq;
using static System.Math;

class Annealing
{
    Random m_Rand;
    public Square[] m_zArea;// Массив квадратов всей территории (не только территориии отдельного БПЛА)
    int[] m_nIndex;         // Массив индексов квадратов зоны поиска (общая матрица)
    int[] m_nTour;          // Массив индексов квадратов зоны поиска (матрица от 0 до m_nSquareH * m_nSquareW
    int m_nCount;           // Количество элементов в массиве квадратов
    //int m_nSquare;          // Текущий квадрат

    public Annealing(Square[] zArea, int[] nIndex)
    {
        m_Rand = new Random();
        m_zArea = zArea;
        m_nIndex = nIndex;
        m_nCount = nIndex.Count();
    }

    double DistanceBetween(int nSquare, int nNextSquare)
    {
        double dXDis = Abs(m_zArea[nSquare].Xc - m_zArea[nNextSquare].Xc);
        double dYDis = Abs(m_zArea[nSquare].Yc - m_zArea[nNextSquare].Yc);
        double dOvDis = Sqrt(dXDis * dXDis + dYDis * dYDis);

        return dOvDis;
    }

    double GetDistance(int[] nTour)
    {
        double dDistance = 0;

        for (int i = 0; i < nTour.Count() - 1; i++)
            dDistance += DistanceBetween(m_nIndex[nTour[i]], m_nIndex[nTour[i + 1]]);

        return dDistance;
    }

    void GenRandTour()
    {
        m_nTour = Enumerable.Range(0, m_nCount).ToArray();
        for (int i = m_nCount - 1; i >= 1; i--)
        {
            int j = m_Rand.Next(1, i + 1);
            System.Threading.Thread.Sleep(15);                      // Пауза 15 мс для новых чисел ГСЧ

            int temp   = m_nTour[j];
            m_nTour[j] = m_nTour[i];
            m_nTour[i] = temp;
        }
    }

    double AcceptProb(double dCurEnergy, double dCandEnergy, double dTemp)
    {
        if (dCandEnergy < dCurEnergy)
            return 1;
       
        return Exp((dCurEnergy - dCandEnergy) / dTemp);
    }

    public int[] Anneal(int nStartSquare)
    {
        double dTemp = 10000;        // Начальная температура
        double dCooling = 0.003;     // Частота охлаждения      

        GenRandTour();

        int[] nBest = m_nTour;

        while (dTemp > 1)
        {
            int[] nCandidate = new int[m_nCount];
            Array.Copy(m_nTour, nCandidate, m_nCount);
            
            int nStartSwap = m_Rand.Next(1, m_nCount);
            int nStopSwap =  m_Rand.Next(1, m_nCount);
            if (nStartSwap > nStopSwap)
            {
                int temp = nStartSwap;
                nStartSwap = nStopSwap;
                nStopSwap = temp;
            }

            Array.Reverse(nCandidate, nStartSwap, nStopSwap - nStartSwap);

            double dEnergy = GetDistance(m_nTour);
            double dCandEnergy = GetDistance(nCandidate);

            if (AcceptProb(dEnergy, dCandEnergy, dTemp) > m_Rand.NextDouble())
                m_nTour = nCandidate;

            if (GetDistance(m_nTour) < GetDistance(nBest))
                nBest = m_nTour;

            dTemp *= 1 - dCooling;
        }

        return nBest;
    }
}