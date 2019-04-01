using System;
using System.Security;
using System.Net;
namespace Domain
{
    public static class Extensions
    {
        /// <summary>
        /// To convert PlainText to SecuredString.
        /// </summary>
        /// <param name="secureStr"></param>
        /// <returns></returns>
        public static String ToPlainString(this SecureString secureStr)
        {
            String plainStr = new NetworkCredential(string.Empty, secureStr).Password;
            return plainStr;
        }

        /// <summary>
        /// To convert a plain text string into a secure string
        /// </summary>
        public static SecureString ToSecureString(this String plainStr)
        {
            var secStr = new SecureString();
            secStr.Clear();
            foreach (char c in plainStr.ToCharArray())
            {
                secStr.AppendChar(c);
            }
            return secStr; 
        }
    }
}
