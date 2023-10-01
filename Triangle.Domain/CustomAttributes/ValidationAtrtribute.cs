using System.ComponentModel.DataAnnotations;
using Triangle.Domain.Dto;

namespace Triangle.Domain.CustomAttributes
{
    public class ValidateTriangleAttribute : ValidationAttribute
    {
        public ValidateTriangleAttribute()
        {
            ErrorMessage = "Input sides are not a valid triangle.";
        }
        public override bool IsValid(object value)
        {
            TriangleDto triangle = value as TriangleDto;

            return (triangle.FirstSide + triangle.SecondSide > triangle.ThirdSide
                && triangle.FirstSide + triangle.ThirdSide > triangle.SecondSide
                && triangle.ThirdSide + triangle.SecondSide > triangle.FirstSide);
        }
    }
}
