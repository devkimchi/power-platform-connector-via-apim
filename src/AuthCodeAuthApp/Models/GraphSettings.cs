namespace AuthCodeAuthApp.Models
{
    public class GraphSettings
    {
        public const string Name = "Graph";

        public virtual string InstanceName { get; set; } = string.Empty;
        public virtual string Endpoint { get; set; } = string.Empty;
    }
}