using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace app.Entities.Common
{
    public class BaseResponse
    {
        [NotMapped]
        public virtual string type { get; set; }
        [NotMapped]
        public virtual HttpStatusCode statusCode { get; set; }
        [NotMapped]
        public virtual string title { get; set; }
        [NotMapped]
        public virtual string message { get; set; }
    }
}
