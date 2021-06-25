using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Weenove_application
{
    public partial class MainWindow : Window
    {
        public const int RANDOM_IMAGES_NUMBER = 10;
        public const int LOCAL_IMAGES_NUMBER = 1;
        public const int IMAGE_WIDTH = 599;
        public const int IMAGE_HEIGHT = 400;
        public const int MARGIN = 15;

        public MainWindow()
        {
            InitializeComponent();
            DisplayImage displayRandomImages = new DisplayImage(new DisplayApiImagesOperation(RANDOM_IMAGES_NUMBER));
            displayRandomImages.displayImage(getWebImageViewersRecursive(0), ExceptionText);
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayImage displayLocalImage = new DisplayImage(new DisplayLocalImagesOperation());
            displayLocalImage.displayImage(getLocalImageViewersRecursive(0), ExceptionText);
        }

        public List<Image> getWebImageViewers()
        {
            List<Image> imageViewersList = new();
            for (int i = 0; i < RANDOM_IMAGES_NUMBER; i++)
            {
                Image img = initImage();
                myStackPanel.Children.Add(img);
                imageViewersList.Add(img);
            }
            return imageViewersList;
        }

        public List<Image> getLocalImageViewers()
        {
            List<Image> imageViewersList = new();
            for (int i = 0; i < LOCAL_IMAGES_NUMBER; i++)
            {
                Image img = initImage();
                img.Visibility = Visibility.Collapsed;
                myStackPanel.Children.Insert(0,img);
                imageViewersList.Add(img);
            }
            return imageViewersList;
        }

        public List<Image> getWebImageViewersRecursive(int listCount)
        {
            if (listCount == RANDOM_IMAGES_NUMBER)
            {
                return new List<Image>();
            }
            else
            {
                List<Image> imageList = getWebImageViewersRecursive(listCount + 1);
                Image img = initImage();
                myStackPanel.Children.Add(img);
                imageList.Add(img);
                return imageList;
            }
        }

        public List<Image> getLocalImageViewersRecursive(int listCount)
        {
            if (listCount == LOCAL_IMAGES_NUMBER)
            {
                return new List<Image>();
            }
            else
            {
                List<Image> imageList = getLocalImageViewersRecursive(listCount+1);
                Image img = initImage();
                img.Visibility = Visibility.Collapsed;
                myStackPanel.Children.Insert(0, img);
                imageList.Add(img);
                return imageList;
            }
        }

        Image initImage()
        {
            Image img = new();
            img.Width = IMAGE_WIDTH;
            img.Height = IMAGE_HEIGHT;
            img.Stretch = System.Windows.Media.Stretch.Fill;
            Thickness margin = img.Margin;
            margin.Right = MARGIN;
            img.Margin = margin;
            return img;
        }
    }
}
