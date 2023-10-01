using Triangle.Domain.Services.Interfaces;

namespace Triangle.Domain.Services.Implementation
{
    public class TriangleService : ITriangleService
    {
        public string GetStyle(double firstSide, double secondSide, double thirdSide)
        {
            // Check if the triangle is equilateral
            if (firstSide == secondSide && firstSide == thirdSide)
            {
                return "Equilateral triangle";
            }

            // Check if the triangle is isosceles
            else if (firstSide == secondSide || firstSide == thirdSide || secondSide == thirdSide)
            {
                return "Isosceles triangle";
            }

            // Check if the triangle is right-angled
            else if ((firstSide * firstSide) + (secondSide * secondSide) == (thirdSide * thirdSide) || (secondSide * secondSide) + (thirdSide * thirdSide) == (firstSide * firstSide) || (firstSide * firstSide) + (thirdSide * thirdSide) == (secondSide * secondSide))
            {
                return "Right-angled triangle";
            }

            // If none of the above criteria are met, then the triangle is arbitrary
            else
            {
                return "Arbitrary triangle";
            }
        }
    }
}