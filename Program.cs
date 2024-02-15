using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR9
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(1, 2, 3);
            Vector vector2 = new Vector(4, 5, 6);

            Console.WriteLine("Длина вектора 1: " + vector1.Length());
            Console.WriteLine("Скалярное произведение: " + vector1.DotProduct(vector2));
            Console.WriteLine("Векторное произведение: " + vector1.CrossProduct(vector2));
            Console.WriteLine("Угол между векторами: " + vector1.Angle(vector2));

            Vector sum = vector1.Add(vector2);
            Console.WriteLine("Сумма векторов: (" + sum.X + ", " + sum.Y + ", " + sum.Z + ")");

            Vector diff = vector1.Subtract(vector2);
            Console.WriteLine("Разность векторов: (" + diff.X + ", " + diff.Y + ", " + diff.Z + ")");

            int N = 5;
            Vector[] randomVectors = Vector.GenerateRandomVectors(N);
            Console.WriteLine("Случайные векторы:");
            foreach (var vec in randomVectors)
            {
                Console.WriteLine("(" + vec.X + ", " + vec.Y + ", " + vec.Z + ")");
            }
        }
    }
    internal class Vector
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }
        public double DotProduct(Vector other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }
        public Vector CrossProduct(Vector other)
        {
            double newX = Y * other.Z - Z * other.Y;
            double newY = Z * other.X - X * other.Z;
            double newZ = X * other.Y - Y * other.X;
            return new Vector(newX, newY, newZ);
        }
        public double Angle(Vector other)
        {
            double dotProduct = DotProduct(other);
            double lengthProduct = Length() * other.Length();
            return Math.Acos(dotProduct / lengthProduct);
        }
        public Vector Add(Vector other)
        {
            return new Vector(X + other.X, Y + other.Y, Z + other.Z);
        }
        public Vector Subtract(Vector other)
        {
            return new Vector(X - other.X, Y - other.Y, Z - other.Z);
        }
        public static Vector[] GenerateRandomVectors(int N)
        {
            Random rand = new Random();
            Vector[] vectors = new Vector[N];
            for (int i = 0; i < N; i++)
            {
                double x = rand.NextDouble() * 10;
                double y = rand.NextDouble() * 10;
                double z = rand.NextDouble() * 10;
                vectors[i] = new Vector(x, y, z);
            }
            return vectors;
        }
    }
}
