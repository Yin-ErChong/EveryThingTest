using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;

namespace FormTest
{
    public partial class Scan : Form
    {
        public Scan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScanFile();
            return;
            ImageFile imageFile = null;
            CommonDialogClass cdc = new WIA.CommonDialogClass();

            try
            {
                imageFile = cdc.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType,
                                                 WIA.WiaImageIntent.TextIntent,
                                                 WIA.WiaImageBias.MaximizeQuality,
                                                 "{00000000-0000-0000-0000-000000000000}",
                                                 false,
                                                 false,
                                                 false);
                if (imageFile != null)
                {

                    imageFile.SaveFile(@"c:\1.bmp");
                    using (FileStream stream = new FileStream(@"c:\1.bmp", FileMode.Open,
                        FileAccess.Read, FileShare.Read))
                    {
                        pictureBox1.BackgroundImage = Image.FromStream(stream);
                    }
                    File.Delete(@"c:\1.bmp");
                }
            }
            catch (System.Runtime.InteropServices.COMException ee)
            {
                imageFile = null;
            }
        }
        private void ScanFile()
        {
            DeviceManager manager = new DeviceManagerClass();
            Device device = null;

            foreach (DeviceInfo info in manager.DeviceInfos)
            {
                if (info.Type != WiaDeviceType.ScannerDeviceType) continue;
                device = info.Connect();
                break;
            }
            Item item = device.Items[1];
            WIA.
            CommonDialogClass cdc = new WIA.CommonDialogClass();
            ImageFile imageFile = cdc.ShowTransfer(item,
                "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}",
                true) as ImageFile;

            if (imageFile != null)
            {
                var buffer = imageFile.FileData.get_BinaryData() as byte[];
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(buffer, 0, buffer.Length);
                    pictureBox1.BackgroundImage = Image.FromStream(ms);
                }
            }
        }
    }
}
