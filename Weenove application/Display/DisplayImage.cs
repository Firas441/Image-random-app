using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Weenove_application
{
    public class DisplayImage
    {
        private IDisplayImageOperation displayImageOperation { get; }

        public DisplayImage(IDisplayImageOperation displayImageOperation)
        {
            this.displayImageOperation = displayImageOperation;
        }

        public void displayImage(List<Image> imageViewerList, TextBlock exceptionText)
        {
            displayImageOperation.displayImage(imageViewerList, exceptionText);
        }

        public static BitmapImage generateBitmap(string uri)
        {
            BitmapImage bitmap = new();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uri);
            bitmap.EndInit();
            return bitmap;
        }
    }
}
