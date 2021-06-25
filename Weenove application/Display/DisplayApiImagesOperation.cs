using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Controls;

namespace Weenove_application
{
    class DisplayApiImagesOperation : IDisplayImageOperation
    {
        private const string apiUrl = "https://api.unsplash.com/photos/random";
        private const string accessKey = "w_K5GW0rp9aUFCFkqgyv77jgj6MCdnIM8Vv17Vh1I98";
        private int imageCountParameter;
        private List<String> imagePathList { get; set; }
        public DisplayApiImagesOperation(int imageCountParameter)
        {
            this.imageCountParameter = imageCountParameter;
            imagePathList = new();
        }

        public async void displayImage(List<Image> imageViewerList, TextBlock exceptionText)
        {
            try
            {
                HttpClient client = new();
                string response = await client.GetStringAsync(buildApiUrl());
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
            catch (HttpRequestException e)
            {
                exceptionText.Text = e.Message;
                return;
            }
        }

        public string buildApiUrl()
        {
            return apiUrl + "?count=" + imageCountParameter.ToString() + "&client_id=" + accessKey;
        }
    }
}
