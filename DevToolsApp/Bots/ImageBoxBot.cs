using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Valhalla.Plugin.Plugin;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using Easybots.Data;
using Easybots.Apps;

namespace Easybots.DevTools.Bots
{
    internal class ImageBoxBot : Easybot
    {   
        private Image image;

        public ImageBoxBot(Image img)
            : base("ImageBox", registerNow: true)
        {
            if (img == null)
                throw new ArgumentNullException("img");

            this.image = img;
        }

        [Action("Displays the image in the ImageBox")]
        public void SetImage(SerializableImage serializableImage)
        {
            this.image.Dispatcher.Invoke(() => this.SetImageSource(serializableImage));
        }

        private static BitmapSource ToWpfBitmap(System.Drawing.Image bmp)
        {
            using (var stream = new System.IO.MemoryStream())
            {               
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(bmp);
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                BitmapImage result = new BitmapImage();                
                result.BeginInit();         
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        private void SetImageSource(SerializableImage serializableImage)
        {
            this.image.Source = ToWpfBitmap(serializableImage.GetJpegImage());
        }
    }
}
