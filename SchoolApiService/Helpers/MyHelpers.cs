using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace SchoolApiService.Helpers
{
    public static class MyHelpers
    {

        public static string AsString(this  TimeSpan time)
        {
            return time.ToFriendlyString();
        }




    }
}
