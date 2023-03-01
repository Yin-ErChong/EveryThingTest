using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.Helper
{
    public  class BitMapHelper
    {
        public static Bitmap GetImageFromBase64(string base64string)
        {
            byte[] b = Convert.FromBase64String(base64string);
            MemoryStream ms = new MemoryStream(b);
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;
        }

        public static string GetBase64FromImage(Image imagefile)
        {
            try
            {
                //Bitmap bmp = new Bitmap(imagefile);

                //MemoryStream ms = new MemoryStream();
                //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //byte[] arr = new byte[ms.Length];
                //ms.Position = 0;
                //// ms.Seek(0, SeekOrigin.Begin);
                //ms.Read(arr, 0, (int)ms.Length);
                //ms.Close();
                //return Convert.ToBase64String(arr);
                using (MemoryStream ms = new MemoryStream())
                {
                    imagefile.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Seek(0, SeekOrigin.Begin);
                    // byte[] arr = ms.GetBuffer(); 
                    byte[] arr = ms.ToArray();

                    return Convert.ToBase64String(arr);
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static Image JoinImage(Image sourceImg, Image newImg)
        {
            int imgHeight = 0, imgWidth = 0;

            imgWidth = sourceImg.Width;
            imgHeight = sourceImg.Height + newImg.Height;

            Bitmap joinedBitmap = new Bitmap(imgWidth, imgHeight);
            using (Graphics graph = Graphics.FromImage(joinedBitmap))
            {
                graph.DrawImage(sourceImg, 0, 0, sourceImg.Width, sourceImg.Height);
                graph.DrawImage(newImg, 0, sourceImg.Height, newImg.Width, newImg.Height);
            }
            return joinedBitmap;
        }
    }

}
