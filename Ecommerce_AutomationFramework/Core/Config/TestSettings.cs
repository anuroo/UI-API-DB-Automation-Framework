public sealed class TestSettings
{
    public string ActiveProfile { get; set; }=string.Empty;
    public string Browser { get; set; }="chrome";
    public bool Headless { get; set; }
    public string ParallelExecution { get; set; } = "off";
    public Dictionary<string,AppProfile> Profiles {get; set;}=new();
}
