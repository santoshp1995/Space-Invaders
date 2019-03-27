using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageHolder : SLink
    {
        // class data
        public Image pImage; 
        public ImageHolder(Image image) : base()
        {
            this.pImage = image;
        }
    }
}
