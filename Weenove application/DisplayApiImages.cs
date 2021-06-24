using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Controls;

namespace Weenove_application
{
    class DisplayApiImages : IDisplayImageOperation
    {
        private string apiUrl = "https://api.unsplash.com/photos/random";
        private const string accessKey = "w_K5GW0rp9aUFCFkqgyv77jgj6MCdnIM8Vv17Vh1I98";
        private List<String> imagePathList { get; set; }
        public DisplayApiImages(int imageCountParameter)
        {;
            apiUrl += "?count=" + imageCountParameter.ToString() + "&client_id=" + accessKey;
            imagePathList = new();
        }

        public async void displayImage(List<Image> imageViewerList)
        {
            HttpClient client = new();
            string response = await client.GetStringAsync(apiUrl);
            List<RandomImageJson> randomImageList = JsonConvert.DeserializeObject<List<RandomImageJson>>(response);
            int imageViewerIndex = 0;
            foreach (RandomImageJson randomImage in randomImageList)
            {
                imagePathList.Add(randomImage.urls.regular);
                if (imageViewerIndex < imageViewerList.Count)
                {
                    imageViewerList[imageViewerIndex].Source = DisplayImage.generateBitmap(imagePathList[imageViewerIndex]);
                    imageViewerIndex++;
                }
            }
        }

        public void displayImage(Image imageViewer, Label FileNameLabel)
        {
            Console.WriteLine("Wrong Parameters for DisplayApiImage object!");
        }
    }
}
