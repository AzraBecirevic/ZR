using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EventiApplication.WinUI.Helper
{
    public class Helper
    {
        public static bool ProvjeriMailFormat(string email)
        {
            try
            {
                var adress = new MailAddress(email);
                return adress.Address == email;  
            }
            catch
            {
                return false;
            }
        }

      
        public static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bitmap = new Bitmap(img);  
            Bitmap bmp = new Bitmap(cropArea.Width, cropArea.Height);
            using (Graphics gph = Graphics.FromImage(bmp))
            {              
                gph.DrawImage(bitmap, new Rectangle(0, 0, bmp.Width, bmp.Height), cropArea, GraphicsUnit.Pixel);
            }
            return bmp;
        }
           
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);

            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destWidth);
            g.Dispose();

            return (Image)b;
        }


        //public static Image CropImage(Image img, Rectangle cropArea)
        //{
        //    Bitmap bmpImage = new Bitmap(img);
        //    Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);  //System.OutOfMemoryException: 'Out of memory.'
        //    return (Image)bmpCrop;
        //}

    }
}
