namespace SmartLocker.WebAPI.Options
{
    public class CultureOptions
    {
        public const string SectionName = "CultureOptions";

        public string[] SupportedCultures { get; set; }
        public string DefaultCulture { get; set; }
    }
}
