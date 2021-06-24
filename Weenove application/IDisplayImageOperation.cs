using System.Collections.Generic;
using System.Windows.Controls;

namespace Weenove_application
{
    public interface IDisplayImageOperation
    {
        public void displayImage(List<Image> imageViewerList);
        public void displayImage(Image imageViewer, Label FileNameLabel);
    }
}
