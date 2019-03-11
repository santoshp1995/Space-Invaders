using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipCategory : Leaf
    {
        public enum ShipType
        {
            Ship,
            ShipRoot,
            Unitialized
        }

        protected ShipCategory(GameObject.Name name, GameSprite.Name spriteName, ShipCategory.ShipType shipType)
            : base(name, spriteName)
        {
            this.type = shipType;
        }

        // Data: ---------------
        ~ShipCategory()
        {
#if(TRACK_DESTRUCTOR)
            Debug.WriteLine("     ~ShipCategory():{0}", this.GetHashCode());
#endif
        }

        // this is just a placeholder, who knows what data will be stored here
        protected ShipCategory.ShipType type;

    }
}