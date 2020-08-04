using System;

/*
 Pseudocode
mem = [ ]
fib(n)
    If n in mem: return mem[n] 
    else,     
        If n < 2, f = 1
        else , f = f(n - 1) + f(n -2)
        mem[n] = f
        return f

 */
namespace FibonacciDynamic
{
    public class Fibonacci
    {
        /// <summary>
        /// Fn = {[(√5 + 1)/2] ^ n} / √5
        /// Time complexity: O(1)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int FibFormula(int n)
        {
            double phi = (1 + Math.Sqrt(5)) / 2;
            return (int)Math.Round(Math.Pow(phi, n) / Math.Sqrt(5));
        }

        /// <summary>
        /// Time complexity = T(n) = T(n-1) + T(n-2) which is exponential
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int FibRecursive(int n)
        {
            if (n <= 1)
                return 1;
            return FibRecursive(n - 1) + FibRecursive(n - 2);
        }

        private static int FibRecursiveSpaceOptimized(int n)
        {
            int a = 0, b = 1, c ;
            if (n==0)
            {
                return a;
            }
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return b;

        }

        private static void MultiplyMatrix( int[,] F, int [,] M)
        {
            int x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            int y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            int z = F[1, 0] * M[0, 0] + F[1, 1] * M[1, 0];
            int w = F[1, 0] * M[0, 1] + F[1, 1] * M[1, 1];

            F[0, 0] = x;
            F[0, 1] = y;
            F[1, 0] = z;
            F[1, 1] = w;


        }
        private static void MatrixPower(int [,] F, int n)
        {
            int i;
            int[,] M = new int[,] { { 1, 1 }, { 1, 0 } };
            for ( i = 2; i <= n; i++)
            {
                MultiplyMatrix(F, M);
            }
        }
        /// <summary>
        /// to achieve a O(logN)
        /// </summary>
        /// <param name="F"></param>
        /// <param name="n"></param>
        private static void MatrixPowerOptimized(int[,] F, int n)
        {
            if (n == 0 || n == 1)
                return;

            int i;
            int[,] M = new int[,]{{1, 1},
                      {1, 0}};

            MatrixPowerOptimized(F, n / 2);
            MultiplyMatrix(F, F);

            if (n % 2 != 0)
                MultiplyMatrix(F, M);

        }

        private static int FibMatrix(int n)
        {
            int[,] M = new int[,] { { 1, 1 }, { 1, 0 } };
            if (n == 0)
                return 0;
            // MatrixPower(M, n - 1);
            MatrixPowerOptimized(M, n - 1);
            return M[0, 0];
        }
        public static int Fib(int n)
        {
            return FibMatrix(n);
        }

        private static int[] f;
        private  readonly int _n;
        public Fibonacci(int n)
        {
            f = new int[n + 1];
            _n = n;
        }

        public int ComputeFib()
        {
            try
            {
                return FibRecursionWithStorageArray(_n);
            }
            finally
            {
                f = null;
            }
        }
        private  int FibRecursionWithStorageArray(int n)
        {
                if (n == 0)
                {
                    return 0;
                }
                if (n == 1 || n == 2)
                {
                    return (f[n] = 1);
                }


                // if fib(n) is already computed return;
                if (f[n] != 0)
                    return f[n];
                // now divide and conquer
                int k = (n & 1) == 1 ? (n + 1) / 2 : n / 2;

                f[n] = (n & 1) == 1 ? (FibRecursionWithStorageArray(k) * FibRecursionWithStorageArray(k)
                    + FibRecursionWithStorageArray(k - 1) * FibRecursionWithStorageArray(k - 1)) :
                    (2 * FibRecursionWithStorageArray(k - 1) + FibRecursionWithStorageArray(k)) * FibRecursionWithStorageArray(k);
                return f[n];
            
        }
    }

    public enum ApproachType
    {
        Recursion=0,Dynamic, Matrix, Formula 
    }
}
