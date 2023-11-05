namespace app.Entities.Common
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";
        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
        public bool Display { get; set; } = true;
        public Alert Warning(string message, bool dismissable = false)
        {
            return new Alert()
            {
                AlertStyle = "warning",
                Dismissable = dismissable,
                Display = true,
                Message = message
            };
        }
        public Alert Primary(string message, bool dismissable = false)
        {
            return new Alert()
            {
                AlertStyle = "primary",
                Dismissable = dismissable,
                Display = true,
                Message = message
            };
        }
        public Alert Information(string message, bool dismissable = false)
        {
            return new Alert()
            {
                AlertStyle = "information",
                Dismissable = dismissable,
                Display = true,
                Message = message
            };
        }
        public Alert Error(string message, bool dismissable = false)
        {
            return new Alert()
            {
                AlertStyle = "danger",
                Dismissable = dismissable,
                Display = true,
                Message = message
            };
        }
        public Alert Success(string message, bool dismissable = false)
        {
            return new Alert()
            {
                AlertStyle = "success",
                Dismissable = dismissable,
                Display = true,
                Message = message
            };
        }
    }
    public class AlertStyles
    {
        public const string primary = "alert alert-primary";
        public const string teal = "alert alert-teal";
        public const string Success = "alert alert-success";
        public const string Information = "alert alert-info";
        public const string Warning = "alert alert-warning";
        public const string Danger = "alert alert-danger";
    }
}
