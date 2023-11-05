namespace app.Entities.Common
{
    public class jsTree
    {
        public int id { get; set; }
        public string text { get; set; }
        public jsTreeState state { get; set; } = new jsTreeState();
        public List<jsTreeChildren> children { get; set; } = new List<jsTreeChildren>();
    }
    public class jsTreeChildren
    {
        public string text { get; set; }
        public string type { get; set; }
        public jsTreeState state { get; set; } = new jsTreeState();
        public List<jsTreeChildren> children { get; set; } = new List<jsTreeChildren>();
    }
    public class jsTreeState
    {
        public bool opened { get; set; } = true;
    }
}
