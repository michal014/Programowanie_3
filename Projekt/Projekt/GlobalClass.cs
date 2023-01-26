using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public static class GlobalClass
    {
        public static string connectionString = @"Data Source=LAPTOP-SI4R27P1\MB_LOCAL;Initial Catalog=videoteka;User ID=sa;Password=zaq1@WSX;encrypt=false";
        public static ListClass selectedItemList { get; set; }
        public static MyListClass selectedItemMyList { get; set; }
        public static int userid = 2;
        public static bool isAdmin = false;

        public static int encryptKey = 11;

        public static string Encrypt(string szPlainText, int szEncryptionKey)
        {
            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ szEncryptionKey);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }
    }
}
