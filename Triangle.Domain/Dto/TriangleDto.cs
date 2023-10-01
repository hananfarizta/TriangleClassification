using System.ComponentModel.DataAnnotations;
using Triangle.Domain.CustomAttributes;

namespace Triangle.Domain.Dto
{
    [ValidateTriangle]
    public class TriangleDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public double FirstSide { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double SecondSide { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double ThirdSide { get; set; }
    }
}
