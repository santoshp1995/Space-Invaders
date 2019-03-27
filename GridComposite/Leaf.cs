using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Leaf : GameObject
    {
        public Leaf(GameObject.Name gameName, GameSprite.Name spriteName) : base(gameName, spriteName)
        {
            this.holder = Container.Leaf;
        }

        override public void Add(Component c)
        {
            Debug.Assert(false);
        }

        override public void Remove(Component c)
        {
            Debug.Assert(false);
        }

        override public void Print()
        {
            Debug.WriteLine(" GameObject Name: {0} ({1})", this.GetName(), this.GetHashCode());
        }

      

        public override Component GetFirstChild()
        {
            Debug.Assert(false);
            return null;
        }
    }
}
