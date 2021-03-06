﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Triangle
    {
        public enum TriangleKind
        {
            Equilateral,
            Isosceles,
            Scalene
        }

        public static TriangleKind Kind(decimal a, decimal b, decimal c)
        {
            if (NotATriangle(a, b, c))
            {
                throw new TriangleException();
            }

            int NumberOfEqualSides = GetNumberOfEqualSides(a, b, c);

            if (NumberOfEqualSides == 3)
            {
                return TriangleKind.Equilateral;
            }
            else if (NumberOfEqualSides == 2)
            {
                return TriangleKind.Isosceles;
            }
            else
            {
                return TriangleKind.Scalene;
            }
        }

        private static int GetNumberOfEqualSides(decimal a, decimal b, decimal c)
        {
            if ((a == b) & (b == c))
            {
                return 3;
            } else if ((a == b) || (b == c) || (a == c))
            {
                return 2;
            }
            return 0;
        }

        private static bool NotATriangle(decimal a, decimal b, decimal c)
        {
            return (HasNonPositiveSide(a, b, c) || FailsTriangleInequality(a, b, c));
        }

        private static bool HasNonPositiveSide(decimal a, decimal b, decimal c)
        {
            return ((a <= 0) || (b <= 0) || (c <= 0));
        }

        private static bool FailsTriangleInequality(decimal a, decimal b, decimal c)
        {
            return (((a + b) <= c) || ((a + c) <= b) || ((b + c) <= a));
        }
    }

    [Serializable()]
    public class TriangleException : System.Exception
    {
        public TriangleException() : base() { }
        public TriangleException(string message) : base(message) { }
        public TriangleException(string message, System.Exception inner) : base(message, inner) { }
        public TriangleException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
