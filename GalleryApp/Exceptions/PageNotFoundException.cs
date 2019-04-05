using System;

namespace GalleryApp.Exceptions
{
    public class PageNotFoundException : Exception
    {
        public PageNotFoundException(string pageName, Exception exception) : base($"{pageName} has not been found", exception)
        {
        }

        public PageNotFoundException(string pageName) : base($"{pageName} has not been found")
        {
        }
    }
}