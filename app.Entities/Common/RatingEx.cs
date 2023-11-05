using System.ComponentModel.DataAnnotations.Schema;

namespace app.Entities.Common
{
    [ComplexType]
    public class RatingEx
    {
        public int Rate { get; set; } = 0;
    }
}
