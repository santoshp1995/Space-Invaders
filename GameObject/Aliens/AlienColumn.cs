using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienColumn : Composite
    {
       
        public AlienColumn(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
        : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            //this.poColObj.pColSprite.SetLineColor(0, 0, 1);
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an BirdColumn
            // Call the appropriate collision reaction            
            other.VisitColumn(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // BirdColumn vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
            int bomb = random.Next(0, 1000);

            Alien lowestAlien = null;
            float lowestY = 5000.0f;

            if(bomb == 1)
            {
                Alien pTemp = (Alien)this.poHead;
                
                while(pTemp != null)
                {
                    if(pTemp.y < lowestY)
                    {
                        lowestAlien = pTemp;
                        lowestY = lowestAlien.y;
                    }
                    pTemp = (Alien)pTemp.pNext;

                }

                // if lowest alien is null, then there are no aliens in this column
                // if its not null, this is the lwoest alien, make it rain bombs
                if(lowestAlien != null)
                {
                    lowestAlien.DropBomb();
                }
            }

        }

       
        // Data
       
    }
}

