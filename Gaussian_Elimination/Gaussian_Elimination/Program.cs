using System;

namespace Gaussian_Elimination
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CalcMatrixTest();
        }

        public static void CalcMatrixTest()
        {
            const int Dimension = 4;
            double[,] matrixA = new double[Dimension, Dimension]
            {
                {2, 3, 1, 4},
                {4, 1, -3, -2},
                {-1, 2, 2, 1},
                {3, -4, 4, 3}
            };
            double[] vectorB = new double[Dimension]
            {
                10,
                0,
                4,
                6
            };
            double[] InitialSolution = new double[Dimension]
            {
                0,
                0,
                0,
                0
            };

            var calcMatrix = new Solve_equation(Dimension, matrixA, vectorB, InitialSolution);
            calcMatrix.solve();
        }
    }
}
