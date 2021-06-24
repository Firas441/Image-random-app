using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Weenove_application
{
    public class DisplayLocalImage : IDisplayImageOperation
    {
        private OpenFileDialog dialog;
        private string selectedImagePath = "";
        public DisplayLocalImage()
        {
            dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                selectedImagePath = dialog.FileName;
            }
        }

        public void displayImage(Image imageViewer, Label FileNameLabel)
        {
            try
            {
                FileNameLabel.Content = selectedImagePath;
                imageViewer.Source = DisplayImage.generateBitmap(selectedImagePath);
                imageViewer.Visibility = Visibility.Visible;
            }

            catch
            {
                FileNameLabel.Content = "Saisissez une image!";
                imageViewer.Visibility = Visibility.Collapsed;
            }
        }

        public void displayImage(List<Image> imageViewerList)
        {
            Console.WriteLine("Wrong parameters for DisplayLocalImage object!");
        }
    }
}
