using System;
using System.Linq;
using System.Collections.Generic;

namespace Gaussian_Elimination
{
    public class Solve_equation
    {
        readonly int dimension;
        readonly double[,] leftMatrix;
        readonly double[] rightVector;
        double[] solutionX;

        public Solve_equation(int Dimension, double[,] LeftMatrix, double[] RightVector, double[] SolutionX)
        {
            this.dimension = Dimension;
            this.leftMatrix = LeftMatrix;
            this.rightVector = RightVector;
            this.solutionX = SolutionX;
        }

        public void solve()
        {
            BackwardSubstitution(ForwardElimination());
        }

        private void WriteEquationFuntion()
        {
            var rowCount = rightVector.Length;
            if(rowCount!= leftMatrix.GetLength(0))
            {
                throw new Exception();
            }

            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = 0; j < leftMatrix.GetLength(1); ++j)
                {
                    Console.Write($"{leftMatrix[i, j],8:F4}");
                }
                Console.WriteLine($" | {rightVector[i],8:F4}");
            }
        }

        private void WriteEquationFuntion(double[,] LeftMatrix, double[] RightVector)
        {
            var rowCount = RightVector.Length;
            if (rowCount != LeftMatrix.GetLength(0))
            {
                throw new Exception();
            }

            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = 0; j < LeftMatrix.GetLength(1); ++j)
                {
                    Console.Write($"{LeftMatrix[i, j],8:F4}");
                }
                Console.WriteLine($" | {RightVector[i],8:F4}");
            }
        }

        private Tuple<double[,], double[]> ForwardElimination()
        {
            Console.WriteLine("Initial");
            WriteEquationFuntion();
            Console.WriteLine();

            var matrixA = leftMatrix;
            var vectorB = rightVector;
            for (int i = 0; i < dimension - 1; ++i)
            {
                for (int j = i + 1; j < dimension; ++j)
                {
                    var s = matrixA[j, i] / matrixA[i, i];
                    for (int k = i; k < dimension; ++k)
                    {
                        matrixA[j, k] -= matrixA[i, k] * s;
                    }
                    vectorB[j] -= vectorB[i] * s;
                }
            }
            Console.WriteLine("After forward elimination");
            WriteEquationFuntion(leftMatrix, vectorB);
            Console.WriteLine();

            var result = new Tuple<double[,], double[]>(matrixA, vectorB);
            return result;
        }

        private void BackwardSubstitution(Tuple<double[,], double[]> forwardMatrix)
        {
            for (int i = dimension - 1; i >= 0; --i)
            {
                var vec = forwardMatrix.Item2;
                var mat = forwardMatrix.Item1;
                var s = vec[i];

                for (int j = i + 1; j < dimension; ++j)
                {
                    s -= mat[i, j] * solutionX[j];
                }
                solutionX[i] = s / mat[i, i];
            }
            Console.WriteLine("After Backward Substitution");
            WriteEquationFuntion(forwardMatrix.Item1, forwardMatrix.Item2);
            Console.WriteLine();

            Console.WriteLine("Solved");
            Console.WriteLine(string.Join("\r\n", solutionX.Select(x => $"{x,8:F4}")));
        }

    }
}
