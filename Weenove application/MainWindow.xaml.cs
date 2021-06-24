﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Weenove_application
/// <summary>
/// Interaction logic for MainWindow.xaml
{
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int RANDOM_IMAGES_NUMBER = 10;

        public MainWindow()
        {
            InitializeComponent();
            DisplayImage displayRandomImages = new DisplayImage(new DisplayApiImages(RANDOM_IMAGES_NUMBER));
            displayRandomImages.displayImage(getWebImageViewers());
        }

        public List<Image> getWebImageViewers()
        {
            List<Image> imageViewersList = new();
            Image img;

            for (int i = 2; i < RANDOM_IMAGES_NUMBER + 2; i++)
            {
                img = ((Image)this.FindName(String.Concat("ImageViewer", i.ToString())));
                imageViewersList.Add(img);
            }

            return imageViewersList;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayImage displayLocalImage = new DisplayImage(new DisplayLocalImage());
            displayLocalImage.displayImage(ImageViewer1,FileNameLabel);
        }
    }
}