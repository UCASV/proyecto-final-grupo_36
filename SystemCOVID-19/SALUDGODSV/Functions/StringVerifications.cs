
namespace SALUDGODSV.Functions
{
    static class StringVerifications
    {
        static bool VerifyString(string toVerify)
        {
            var toCompare = "$/-*@";
            int counToReturn = 0;
            for ( var i = 0; i < toCompare.Length; i++)
                for(var j = 0; j < toVerify.Length; j++)
                {
                    if (toVerify[j] == toCompare[i])
                        counToReturn++;
                }
            return counToReturn != 0;
        }
        static bool VerifyNumber(string toVerify)
        {
            var toCompare = "qwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM";
            int counToReturn = 0;
            for (var i = 0; i < toCompare.Length; i++)
                for (var j = 0; j < toVerify.Length; j++)
                {
                    if ( toVerify[j]== toCompare[i])
                        counToReturn++;
                }
            return counToReturn != 0;
        }
    }
}
