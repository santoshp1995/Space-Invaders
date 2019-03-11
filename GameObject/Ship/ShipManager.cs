using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipManager
    {
        public enum State
        {
            Ready,
            MissileFlying,
            ShipSpawnState,
            End
        }

        private ShipManager()
        {
            // Store the states
            this.pStateReady = new ShipReadyState();
            this.pStateMissileFlying = new ShipMissileFlyingState();
            this.pShipSpawnState = new ShipSpawnState();
            this.pEndState = new ShipEndState();

            // set active
            this.pShip = null;
            this.pMissile = null;
        }

        public static void Create()
        {
            // make sure its the first time
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new ShipManager();
            }

            Debug.Assert(instance != null);

            // Stuff to initialize after the instance was created
            instance.pShip = ActivateShip();
            instance.pShip.SetState(ShipManager.State.Ready);

        }

        private static ShipManager PrivInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static Ship GetShip()
        {
            ShipManager pShipMan = ShipManager.PrivInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pShip != null);

            return pShipMan.pShip;
        }

        public static ShipState GetState(State state)
        {
            ShipManager pShipMan = ShipManager.PrivInstance();
            Debug.Assert(pShipMan != null);

            ShipState pShipState = null;

            switch (state)
            {
                case ShipManager.State.Ready:
                    pShipState = pShipMan.pStateReady;
                    break;

                case ShipManager.State.MissileFlying:
                    pShipState = pShipMan.pStateMissileFlying;
                    break;

                case ShipManager.State.End:
                    pShipState = pShipMan.pEndState;
                    break;
                case ShipManager.State.ShipSpawnState:
                    pShipState = pShipMan.pShipSpawnState;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static Missile GetMissile()
        {
            ShipManager pShipMan = ShipManager.PrivInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pMissile != null);

            return pShipMan.pMissile;
        }

        public static Missile ActivateMissile()
        {
            ShipManager pShipMan = ShipManager.PrivInstance();
            Debug.Assert(pShipMan != null);

            // copy over safe copy
            Missile pMissile = new Missile(GameObject.Name.Missle, GameSprite.Name.PlayerShot, 100, -5);
            pShipMan.pMissile = pMissile;

            // Attached to SpriteBatches
            SpriteBatch pSB_Aliens = SpriteBatchManager.Find(SpriteBatch.Name.SpaceInvaders);
            SpriteBatch pSB_Boxes = SpriteBatchManager.Find(SpriteBatch.Name.Boxes);

            pMissile.ActivateCollisionSprite(pSB_Boxes);
            pMissile.ActivateGameSprite(pSB_Aliens);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameObjectManager.Find(GameObject.Name.MissleGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pShipMan.pMissile);

            return pShipMan.pMissile;
        }


        private static Ship ActivateShip()
        {
            ShipManager pShipMan = ShipManager.PrivInstance();
            Debug.Assert(pShipMan != null);

            // copy over safe copy
            Ship pShip = new Ship(GameObject.Name.Ship, GameSprite.Name.Player, 200, 75);
            pShipMan.pShip = pShip;

            // Attach the sprite to the correct sprite batch
            SpriteBatch pSB_Aliens = SpriteBatchManager.Find(SpriteBatch.Name.SpaceInvaders);
            pSB_Aliens.Attach(pShip.pProxySprite);

            // Attach the missile to the missile root
            GameObject pShipRoot = GameObjectManager.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pShipRoot.Add(pShipMan.pShip);

            return pShipMan.pShip;
        }

        // Data: ----------------------------------------------
        private static ShipManager instance = null;

        // Active
        private Ship pShip;
        private Missile pMissile;

        // Reference
        private ShipReadyState pStateReady;
        private ShipMissileFlyingState pStateMissileFlying;
        private ShipSpawnState pShipSpawnState;
        private readonly ShipEndState pEndState;


    }
}
