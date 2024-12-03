namespace ProductMaxProfit
{
    public static class Utils
    {
        public static decimal[] SolverSimplex(decimal[,] matrix, int l, int c)
        {
            for (int i = 0; i < length; i++)
            {
                
            }

            for (int i = 0; i < n; i++)
            {
                int max = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(matrix[j, i]) > Math.Abs(matrix[max, i]))
                    {
                        max = j;
                    }
                }

                for (int k = i; k < n; k++)
                {
                    decimal temp = matrix[max, k];
                    matrix[max, k] = matrix[i, k];
                    matrix[i, k] = temp;
                }

                decimal t = rhs[max];
                rhs[max] = rhs[i];
                rhs[i] = t;

                for (int j = i + 1; j < n; j++)
                {
                    decimal factor = matrix[j, i] / matrix[i, i];
                    rhs[j] -= factor * rhs[i];
                    for (int k = i; k < n; k++)
                    {
                        matrix[j, k] -= factor * matrix[i, k];
                    }
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                decimal sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += matrix[i, j] * result[j];
                }
                result[i] = (rhs[i] - sum) / matrix[i, i];
            }

            return result;
        }
        public static void PrintMtz(this decimal[,] mtz, int l, int c)
        {
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++) Console.Write( (mtz[i,j]+"").PadRight(20));
                Console.WriteLine();
            }
        }
        public static void PrintMtz(this decimal[,] mtz, int dimensions)
        {
            
            /*
            for (int i = 0; i < dimensions; i++)
            {
                int nextDimension = i + 1 >= dimensions ? 0 : i + 1;
                PrintFor((decimal[,])mtz.GetValue(i), i, nextDimension);
            }
            */
        }
        private static void PrintFor(decimal[,] mtz, int dimension, int nextDimension)
        {
            var dimensionLength = mtz.GetLength(dimension);
            for (int i = 0; i < dimensionLength; i++)
            {
                Console.WriteLine("|");
                if (nextDimension > 0) PrintFor(mtz, nextDimension, nextDimension - 1);
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
