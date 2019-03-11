using System;

namespace SpaceInvaders
{
    public class SquidAlien : Alien
    {
        public SquidAlien(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY) : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        ~SquidAlien()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitSquid(this);
        }

        public override void VisitMissile(Missile missile)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(missile, this);
            pColPair.NotifyListeners();

            missile.Remove();

            this.Remove();
        }

        public override void VisitMissileGroup(MissileGroup group)
        {
            // Alien vs MissileGroup
            Console.WriteLine("         collide:  {0} <-> {1}", group.name, this.name);

            //Missle vs Alien 
            GameObject pGameObj = (GameObject)Iterator.GetChild(group);
            ColPair.Collide(pGameObj, this);
        }


        public override void Update()
        {
            base.Update();
        }
    }
}
