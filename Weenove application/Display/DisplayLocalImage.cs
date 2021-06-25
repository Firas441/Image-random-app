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
        private string selectedImagePath;
        public DisplayLocalImage()
        {
            dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.RestoreDirectory = true;
            selectedImagePath = "";
        }

        public void displayImage(List<Image> imageViewerList, TextBlock exceptionText)
        {
            foreach (Image imageViewer in imageViewerList)
            {
                try
                {
                    if (dialog.ShowDialog() == true)
                    {
                        selectedImagePath = dialog.FileName;
                    }
                    imageViewer.Source = DisplayImage.generateBitmap(selectedImagePath);
                    imageViewer.Visibility = Visibility.Visible;
                    exceptionText.Text = "";
                }

                catch
                {
                    exceptionText.Text = "Saisir un fichier image!";
                    imageViewer.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
