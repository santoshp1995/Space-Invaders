using System;
using System.Diagnostics;


namespace SpaceInvaders
{

    abstract public class ColVisitor : DLink
    {

        public virtual void VisitGrid(AlienGrid grid)
        {
            Debug.Assert(false);
        }

        public virtual void VisitColumn(AlienColumn column)
        {
            Debug.Assert(false);
        }

        public virtual void VisitSquid(SquidAlien squid)
        {
            Debug.Assert(false);
        }

        public virtual void VisitCrab(CrabAlien crab)
        {
            Debug.Assert(false);
        }

        public virtual void VisitOcto(OctopusAlien octo)
        {
            Debug.Assert(false);
        }

        public virtual void VisitMissile(Missile missile)
        {
            Debug.Assert(false);
        }

        public virtual void VisitMissileGroup(MissileGroup group)
        {
            Debug.Assert(false);
        }
        public virtual void VisitNullGameObject(NullGameObject n)
        { 
            Debug.Assert(false);
        }

        public virtual void VisitWallGroup(WallGroup group)
        {
            Debug.Assert(false);
        }

        public virtual void VisitWallLeft(WallLeft left)
        {
            Debug.Assert(false);
        }

        public virtual void VisitWallRight(WallRight right)
        { 
            Debug.Assert(false);
        }

        public virtual void VisitWallTop(WallTop top)
        {
            Debug.Assert(false);
        }

        public virtual void VisitWallDown(WallDown down)
        {
            Debug.Assert(false);
        }
        public virtual void VisitShip(Ship ship)
        { 
            Debug.Assert(false);
        }

        public virtual void VisitShipRoot(ShipRoot root)
        {
            Debug.Assert(false);
        }

        public virtual void VisitBomb(Bomb bomb)
        {
            Debug.Assert(false);
        }

        public virtual void VisitBombRoot(BombRoot root)
        {
            Debug.Assert(false);
        }

        public virtual void VisitShieldRoot(ShieldRoot root)
        {
            Debug.Assert(false);
        }

        public virtual void VisitShieldBrick(ShieldBrick brick)
        {
            Debug.Assert(false);
        }

        public virtual void VisitShieldColumn(ShieldColumn column)
        {
            Debug.Assert(false);
        }

        public virtual void VisitShieldGrid(ShieldGrid grid)
        {
            Debug.Assert(false);
        }

        public virtual void VisitUFORoot(UFORoot root)
        {
            Debug.Assert(false);
        }

        public virtual void VisitUFO(UFO ufo)
        {
            Debug.Assert(false);
        }
        abstract public void Accept(ColVisitor other);
    }

}