using SALUDGODSV.Exceptions;
namespace SALUDGODSV.Functions
{
    static class StringVerifications
    {
        static public void VerifyString(string toVerify)
        {//Comprueba si una cadeena de caracteres contiene simbolos o esta vacia y arroja una exception
            var toCompare = "$/-*";
            int counToReturn = 0;
            for ( var i = 0; i < toCompare.Length; i++)
                for(var j = 0; j < toVerify.Length; j++)
                {
                    if (toVerify[j] == toCompare[i])
                        counToReturn++;
                }

            if (counToReturn != 0 || toVerify.CompareTo("") == 0)
                throw new InvalidStringException();
        }
    }
}
