using System;
namespace SpaceInvaders
{
    public class MovementSprite : Command
    {
        AlienGrid grid;
        int myLevel;
        int count = 0;
        Sound alienMoveSound1 = SoundManager.Find(Sound.Name.Alien_Walk1);
        Sound alienMoveSound2 = SoundManager.Find(Sound.Name.Alien_Walk2);
        Sound alienMoveSound3 = SoundManager.Find(Sound.Name.Alien_Walk3);
        Sound alienMoveSound4 = SoundManager.Find(Sound.Name.Alien_Walk4);
        public MovementSprite(AlienGrid pGrid, int CurrentLevel)
        {
            this.grid = pGrid;
            this.myLevel = CurrentLevel;
        }

        public override void Execute(float deltaTime)
        {
          if(GameStats.GetLevel() == this.myLevel)
            {
                // move game object
                grid.MoveGrid();
                count++;

                if (count == 1)
                {
                    alienMoveSound1.PlaySound();
                }

                else if (count == 2)
                {
                    alienMoveSound2.PlaySound();

                }

                else if (count == 3)
                {
                    alienMoveSound3.PlaySound();
                }

                else
                {
                    alienMoveSound4.PlaySound();
                    count = 0;
                }


                // add itself back to the timer
                TimerManager.Add(TimeEvent.Name.SpriteMovement, this, deltaTime);
            }
        }
    }
}
