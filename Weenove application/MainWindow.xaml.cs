using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Weenove_application
{
    public partial class MainWindow : Window
    {
        public const int RANDOM_IMAGES_NUMBER = 10;

        public MainWindow()
        {
            InitializeComponent();
            DisplayImage displayRandomImages = new DisplayImage(new DisplayApiImagesOperation(RANDOM_IMAGES_NUMBER));
            displayRandomImages.displayImage(getWebImageViewers(), ExceptionText);
        }

        public List<Image> getWebImageViewers()
        {
            List<Image> imageViewersList = new();
            Image img;

            for (int i = 1; i < RANDOM_IMAGES_NUMBER + 1; i++)
            {
                img = ((Image)this.FindName(String.Concat("ImageViewer", i.ToString())));
                imageViewersList.Add(img);
            }

            return imageViewersList;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            List<Image> localImageViewers = new();
            localImageViewers.Add(ImageViewer11);
            DisplayImage displayLocalImage = new DisplayImage(new DisplayLocalImagesOperation());
            displayLocalImage.displayImage(localImageViewers, ExceptionText);
        }
    }
}
