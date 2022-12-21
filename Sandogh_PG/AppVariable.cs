using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sandogh_PG
{
    public class AppVariable
    {
        // مسیر دایکتوری ذخیره فایل کانفیگ 
        public static string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\" + Assembly.GetExecutingAssembly().GetName().Name;

        //#region Setting Keys

        public static string[] SkinName = { "SkinName[0]", "SkinName[1]", "SkinName[2]", "SkinName[3]", "SkinName[4]", "SkinName[5]"
                ,"SkinName[6]","SkinName[7]","SkinName[8]","SkinName[9]","SkinName[10]" };
        //public static string SkinName ="Skin1";
        //public static string ConnectionPath = "dbConnection";
        //public static string[] cmbNameDataBaseSandogh = { "cmbNameDataBaseSandogh[0]", "cmbServerType[0]", "cmbServerName[0]", "cmbAuthentication[0]",
        //         "txtUserName2[0]", "txtPassword2[0]","txtAttachDbFilePath[0]","txtDatabaseName[0]","UserId[0]","Password[0],cmbNameDataBaseSandogh[1]", "cmbServerType[1]", "cmbServerName[1]", "cmbAuthentication[1]",
        //         "txtUserName2[1]", "txtPassword2[1]","txtAttachDbFilePath[1]","txtDatabaseName[1]","UserId[1]","Password[1],cmbNameDataBaseSandogh[2]", "cmbServerType[2]", "cmbServerName[2]", "cmbAuthentication[2]",
        //         "txtUserName2[2]", "txtPassword2[2]","txtAttachDbFilePath[2]","txtDatabaseName[2]","UserId[2]","Password[2]"};
        public static string[] cmbNameDataBaseSandogh = { "cmbNameDataBaseSandogh[0]", "cmbNameDataBaseSandogh[1]", "cmbNameDataBaseSandogh[2]", "cmbNameDataBaseSandogh[3]", "cmbNameDataBaseSandogh[4]", "cmbNameDataBaseSandogh[5]", "cmbNameDataBaseSandogh[6]", "cmbNameDataBaseSandogh[7]", "cmbNameDataBaseSandogh[8]", "cmbNameDataBaseSandogh[9]", "cmbNameDataBaseSandogh[10]" };
        public static string[] cmbServerType = { "cmbServerType[0]", "cmbServerType[1]", "cmbServerType[2]", "cmbServerType[3]", "cmbServerType[4]", "cmbServerType[5]", "cmbServerType[6]", "cmbServerType[7]", "cmbServerType[8]", "cmbServerType[9]", "cmbServerType[10]" };
        public static string[] cmbServerName = { "cmbServerName[0]", "cmbServerName[1]", "cmbServerName[2]", "cmbServerName[3]", "cmbServerName[4]", "cmbServerName[5]", "cmbServerName[6]", "cmbServerName[7]", "cmbServerName[8]", "cmbServerName[9]", "cmbServerName[10]" };
        public static string[] cmbAuthentication = { "cmbAuthentication[0]", "cmbAuthentication[1]", "cmbAuthentication[2]", "cmbAuthentication[3]", "cmbAuthentication[4]", "cmbAuthentication[5]", "cmbAuthentication[6]", "cmbAuthentication[7]", "cmbAuthentication[8]", "cmbAuthentication[9]", "cmbAuthentication[10]" };
        public static string[] txtUserName2 = { "txtUserName2[0]", "txtUserName2[1]", "txtUserName2[2]", "txtUserName2[3]", "txtUserName2[4]", "txtUserName2[5]", "txtUserName2[6]", "txtUserName2[7]", "txtUserName2[8]", "txtUserName2[9]", "txtUserName2[10]" };
        public static string[] txtPassword2 = { "txtPassword2[0]", "txtPassword2[1]", "txtPassword2[2]", "txtPassword2[3]", "txtPassword2[4]", "txtPassword2[5]", "txtPassword2[6]", "txtPassword2[7]", "txtPassword2[8]", "txtPassword2[9]", "txtPassword2[10]" };
        public static string[] txtAttachDbFilePath = { "txtAttachDbFilePath[0]", "txtAttachDbFilePath[1]", "txtAttachDbFilePath[2]", "txtAttachDbFilePath[3]", "txtAttachDbFilePath[4]", "txtAttachDbFilePath[5]", "txtAttachDbFilePath[6]", "txtAttachDbFilePath[7]", "txtAttachDbFilePath[8]", "txtAttachDbFilePath[9]", "txtAttachDbFilePath[10]" };
        public static string[] txtDatabaseName = { "txtDatabaseName[0]", "txtDatabaseName[1]", "txtDatabaseName[2]", "txtDatabaseName[3]", "txtDatabaseName[4]", "txtDatabaseName[5]", "txtDatabaseName[6]", "txtDatabaseName[7]", "txtDatabaseName[8]", "txtDatabaseName[9]", "txtDatabaseName[10]" };
        public static string DefaltIndexCmbNameSandogh = "DefaltIndexCmbNameSandogh";


        public static string IsChangeDbName = "IsChangeDbName";
        public static string[] txtUserName = { "txtUserName[0]", "txtUserName[1]", "txtUserName[2]", "txtUserName[3]", "txtUserName[4]", "txtUserName[5]", "txtUserName[6]", "txtUserName[7]", "txtUserName[8]", "txtUserName[9]", "txtUserName[10]" };
        public static string[] txtPassword = { "txtPassword[0]", "txtPassword[1]", "txtPassword[2]", "txtPassword[3]", "txtPassword[4]", "txtPassword[5]", "txtPassword[6]", "txtPassword[7]", "txtPassword[8]", "txtPassword[9]", "txtPassword[10]" };
        //public static string[] GarantiDate = { "GarantiDate[0]", "GarantiDate[1]", "GarantiDate[2]", "GarantiDate[3]", "GarantiDate[4]", "GarantiDate[5]", "GarantiDate[6]", "GarantiDate[7]", "GarantiDate[8]", "GarantiDate[9]", "GarantiDate[10]" };
    }
}
