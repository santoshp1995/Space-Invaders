using System.Diagnostics;

namespace SpaceInvaders
{
    class AnimationSprite : Command
    {
        // class data
        private GameSprite pSprite;
        private SLink pCurrImage;
        private SLink pFirstImage;

        public AnimationSprite(GameSprite.Name spriteName)
        {
            this.pSprite = GameSpriteManager.Find(spriteName);
            Debug.Assert(this.pSprite != null);

            // initilize the reference
            this.pCurrImage = null;

            // list
            this.pFirstImage = null;
        }

        public void Attach(Image.Name imageName)
        {
            // get the image
            Image pImage = ImageManager.Find(imageName);
            Debug.Assert(pImage != null);

            // create a holder
            ImageHolder pImageHolder = new ImageHolder(pImage);
            Debug.Assert(pImageHolder != null);

            // attach to the animation sprite - Push to front
            SLink.AddToFront(ref this.pFirstImage, pImageHolder);

            // set first to this image
            this.pCurrImage = pImageHolder;
        }

        public override void Execute(float deltaTime)
        {
            // advance to next image
            ImageHolder pImageHolder = (ImageHolder)this.pCurrImage.pSNext;

            // if at the end of list, set to first
            if(pImageHolder == null)
            {
                pImageHolder = (ImageHolder)pFirstImage;
            }

            this.pCurrImage = pImageHolder;

            // change image
            this.pSprite.SwapImage(pImageHolder.pImage);

            // move game object

            // add itself back to the timer
            TimerManager.Add(TimeEvent.Name.SpriteAnimation, this, deltaTime);
        }
    }
}
