using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DcvKeyLogger
{
    public partial class Form1 : Form
    {
        static string LicenseUrl = "https://mlic.dmm.com/drm/widevine/license";
        static string GetWVKeyAPI = "http://getwvkeys.herokuapp.com/api";
        static string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) DMMPlayerv2/2.1.9 Chrome/94.0.4606.81 Electron/15.3.0 Safari/537.36";
        static string DmmUID;
        static byte[] PSSH_UUID = {
            0xED, 0xEF, 0x8B, 0xA9, 0x79, 0xD6, 0x4A, 0xCE,
            0xA3, 0xC8, 0x27, 0xDC, 0xD5, 0x1D, 0x21, 0xED
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_UID.Text = DmmUID = ConfigurationManager.AppSettings["DmmUID"];
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                foreach (var arg in args)
                {
                    if (arg.EndsWith(".dcv"))
                        DCVKey(arg);
                }
                Environment.Exit(0);
            }
        }

        private void label_DCV_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private async void label_DCV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.dcv|*.dcv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox_Keys.Text = await Task.Run(() => DCVKey(ofd.FileName));
            }
        }

        private async void label_DCV_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = e.Data.GetData(DataFormats.FileDrop) as string[];
            string fileName = fileList.FirstOrDefault(f => f.EndsWith(".dcv"));

            if (string.IsNullOrEmpty(fileName))
                return;

            textBox_Keys.Text = await Task.Run(() => DCVKey(fileName));
        }

        private string DCVKey(string dcvFile)
        {
            string pssh_b64 = GetPSSH(dcvFile);
            DmmUID = textBox_UID.Text;
            string keys = GetDcvKeys(pssh_b64, DmmUID);
            string baseDir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string keyDir = Path.Combine(baseDir, "key");
            Directory.CreateDirectory(keyDir);
            string keyFile = Path.Combine(keyDir, Path.ChangeExtension(Path.GetFileName(dcvFile), ".key"));
            File.WriteAllText(keyFile, keys);
            ConfigurationManager.AppSettings["DmmUID"] = DmmUID;
            SystemSounds.Asterisk.Play();
            return keys;
        }

        private string GetDcvKeys(string pssh_b64, string dmmUid)
        {
            string result = string.Empty;
            string cookie = $"licenseUID={dmmUid}";
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add(HttpRequestHeader.UserAgent, UserAgent);
                wc.Headers.Add(HttpRequestHeader.Cookie, cookie);
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                try
                {
                    result = wc.UploadString(GetWVKeyAPI, $"{{\"license\":\"{LicenseUrl}\",\"pssh\":\"{pssh_b64}\"}}");
                }
                catch
                {
                    result = string.Empty;
                }
            }

            if (!result.Contains("keys"))
                return string.Empty;

            JavaScriptSerializer jss = new JavaScriptSerializer();
            WVGetKeyResp resp = jss.Deserialize<WVGetKeyResp>(result);

            string keys = string.Empty;
            foreach (var item in resp.keys)
                keys += (item.key + "\r\n");

            return keys;
        }

        private string GetPSSH(string fileName)
        {
            string pssh_b64 = string.Empty;
            byte[] buffer = new byte[4 * 1024 * 1024];

            using (FileStream fs = File.OpenRead(fileName))
                fs.Read(buffer, 0, buffer.Length);

            for (int offset = 0; offset < buffer.Length - 4; offset++)
            {
                string magic = Encoding.ASCII.GetString(buffer, offset, 4);
                if (magic.Equals("pssh") && buffer.Skip(offset + 8).Take(16).SequenceEqual(PSSH_UUID))
                {
                    uint len = BitConverter.ToUInt32(buffer, offset - 4);
                    len = len << 24 | len >> 24 | (len & 0xff0000) >> 8 | (len & 0xff00) << 8;
                    pssh_b64 = Convert.ToBase64String(buffer, offset - 4, (int)len);
                    break;
                }
            }

            return pssh_b64;
        }
    }

    public class WVGetKeyResp
    {
        public class Key
        {
            public string key { get; set; }
        }
        public string license { get; set; }
        public string pssh { get; set; }
        public List<Key> keys { get; set; }
    }
}
