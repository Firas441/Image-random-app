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

        public void displayImage(Image imageViewer, Label FileNameLabel) 
        {
            if(displayImageOperation.GetType() == typeof(DisplayLocalImage))
                displayImageOperation.displayImage(imageViewer,FileNameLabel);
        }

        public void displayImage(List<Image> imageViewerList)
        {
            if (displayImageOperation.GetType() == typeof(DisplayApiImages))
                displayImageOperation.displayImage(imageViewerList);
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
