using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using DevExpress.XtraEditors;
using nucs.JsonSettings;
using nucs.JsonSettings.Fluent;

namespace Sandogh_PG
{
    public partial class FrmAppRegister : DevExpress.XtraEditors.XtraForm
    {

        FrmMain Fm;
        public FrmAppRegister(FrmMain fm)
        {
            InitializeComponent();
            Fm = fm;
        }
        public FrmAppRegister()
        {
            InitializeComponent();
        }

        public static int RandomNumber(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                //تولید عدد و تبدیل آن به کاراکتر
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string RandomCode()
        {
            StringBuilder builder = new StringBuilder();
            //builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000000000, 2147483647));
            //builder.Append(RandomString(2, false));
            return builder.ToString();
        }


        private string GetHardwarSerial()
        {
           // string cpuSerial = string.Empty;
           // string hardSerial = string.Empty;
            string MadarBoardCode = string.Empty;
            //----------------------

            //ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //ManagementObjectCollection objcol = mgmt.GetInstances();
            //foreach (ManagementObject obj in objcol)
            //{
            //    if (obj.Properties["ProcessorId"] != null)
            //        cpuSerial = obj.Properties["ProcessorId"].Value.ToString().Trim();
            //}

            ////---------------------

            //ManagementObjectSearcher sercher = new ManagementObjectSearcher("select * from Win32_PhysicalMedia");
            //foreach (ManagementObject wmi_Hd in sercher.Get())
            //{
            //    if (wmi_Hd["SerialNumber"] != null)
            //        hardSerial = wmi_Hd["SerialNumber"].ToString().Trim();
            //}

            //---------------------

            ManagementObjectSearcher sercher2 = new ManagementObjectSearcher("select * from Win32_BaseBoard");
            foreach (ManagementObject wmi_Board in sercher2.Get())
            {
                if (wmi_Board["SerialNumber"] != null)
                    MadarBoardCode = wmi_Board["SerialNumber"].ToString().Trim();
            }

            //-----------

            //return cpuSerial + hardSerial + mainBoardSerial;
            return  MadarBoardCode;
        }

        //string HardSerial = "";
        string _RandomCode = "";
        private void frmAppRegister_Load(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmMain"] == null)
            {
                _RandomCode = GetHardwarSerial().Substring(0,10);
                txtCode.Text = _RandomCode;
            }
            else
            {
                //HardSerial = ReveresString(GetHardwarSerial());
                //if (string.IsNullOrEmpty(HardSerial))
                //{
                //    HardSerial = "laksjdhfglaksjdhfg";
                //}
                _RandomCode = RandomCode();
                txtCode.Text = _RandomCode;

            }
        }

        private string ReveresString(string RandomCode)
        {
            char[] ch = RandomCode.ToCharArray();
            Array.Reverse(ch);
            return new string(ch);
        }

        private string GenerateSerial(string RandomCode)
        {
            string ReveresRandomCode = ReveresString(RandomCode);
            string Serial = string.Empty;
            string code = ReveresRandomCode.Substring(0, 10);
            for (int i = 0; i < code.Length; i++)
            {
                char ch = char.Parse(code.Substring(i, 1));
                Serial += ((int)ch).ToString();
            }
            string ReveresSerial = ReveresString(Serial);
            return ReveresSerial.Substring(0, 10);
        }

        public string _Password = string.Empty;
        public string _Shenase = string.Empty;
        private void btnSabt_Click(object sender, EventArgs e)
        {
            if (txtSeryal.Text == GenerateSerial(_RandomCode))
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.TarifSandoghs.Find(1);
                        if (q != null)
                        {
                            q.AppActived = true;
                            q.IsGaranti = true;
                            q.ShomareNoskheBarname = Application.ProductVersion;

                            q.TarikhRegister = Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10));
                            int yyyy1 = Convert.ToInt32(DateTime.Now.ToString().Substring(0, 4));
                            int MM1 = Convert.ToInt32(DateTime.Now.ToString().Substring(5, 2));
                            int dd1 = Convert.ToInt32(DateTime.Now.ToString().Substring(8, 2));
                            Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                            for (int i = 0; i < 13; i++)
                            {
                                d1.IncrementMonth();
                            }
                            q.TarikhEtmamGaranti = Convert.ToDateTime(d1.ToString());
                            db.SaveChanges();
                            this.Close();

                            if (Application.OpenForms["FrmMain"] == null)
                            {
                                q.MadarBoardCode = txtCode.Text;
                                db.SaveChanges();
                                var q1 = db.Karbarans.FirstOrDefault(f => f.Shenase == _Shenase && f.Password == _Password);
                                if (q1 != null)
                                {
                                    FrmMain fm = new FrmMain();
                                    fm.txtUserId.Caption = q1.Id.ToString();
                                    fm.txtUserName.Caption = q1.Name.ToString();
                                    fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                                    fm.NameDataBase.Caption = db.Database.Connection.Database;
                                    //fm.IndexNameDataBase.Caption = cmbNameDataBaseSandogh.SelectedIndex.ToString();
                                    fm.Show();
                                }
                            }
                            else
                            {
                                Fm.EtmamGaranti.Caption = db.TarifSandoghs.FirstOrDefault().TarikhEtmamGaranti != null ? "اتمام گارانتی : " + db.TarifSandoghs.FirstOrDefault().TarikhEtmamGaranti.ToString().Substring(0, 10) : "0000/00/00";

                                Fm.EtmamGaranti.ItemAppearance.Normal.ForeColor = labelControl1.ForeColor;
                                Fm.btnTamdidGaranti.Enabled = false;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtSeryal.Text))
                    XtraMessageBox.Show("لطفاً سریال را وارد کنید");
                else
                    XtraMessageBox.Show("سریال وردی اشتباه است");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmMain"] == null)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }

        }
    }
}