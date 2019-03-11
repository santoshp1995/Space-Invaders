using System;

namespace SpaceInvaders
{
    public class CrabAlien : Alien
    {
        public CrabAlien(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY) : base(name,spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

       ~CrabAlien()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitCrab(this);
        }

        public override void VisitMissile(Missile missile)
        {
            // Alien vs Missile
            Console.WriteLine("         collide:  {0} <-> {1}", missile.name, this.name);

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
