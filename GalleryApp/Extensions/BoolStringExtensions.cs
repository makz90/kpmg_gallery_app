namespace GalleryApp.Extensions
{
    public static class BoolStringExtensions
    {
        public static bool GetBoolFromObject(this object value)
        {
            bool parsedValue = false;
            bool.TryParse(value.ToString(), out parsedValue);
            return parsedValue;
        }
    }
}