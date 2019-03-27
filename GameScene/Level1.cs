using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Level1 : SceneState
    {
        // data
        public static Random randomUFO = new Random();
        public static Random randomUFO2 = new Random();
        public SpriteBatchManager poSpriteBatchMan;

        public Level1()
        {
            this.Initialize();
        }

        public override void Handle()
        {
            
        }

        public override void Initialize()
        {
            // clear game object manager before adding in new stuff
            GameObjectManager.RemoveAll();


            // now add in new stuff 


            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            Texture pTexture = TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXML(Glyph.Name.Consolas20pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            TextureManager.Add(Texture.Name.Birds, "Birds.tga");
            TextureManager.Add(Texture.Name.SpaceInvaders, "SpaceInvaders.tga");
            TextureManager.Add(Texture.Name.Birds, "Birds_N_Shield.tga");

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------

            // ----- Space Invaders Images ----- //

            ImageManager.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageManager.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 18, 3, 12, 8);
            ImageManager.Add(Image.Name.AlienA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageManager.Add(Image.Name.AlienB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageManager.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageManager.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 72, 3, 8, 8);
            ImageManager.Add(Image.Name.Player, Texture.Name.SpaceInvaders, 3, 14, 13, 8);
            ImageManager.Add(Image.Name.Saucer, Texture.Name.SpaceInvaders, 99, 3, 16, 8);

            ImageManager.Add(Image.Name.PlayerShot, Texture.Name.SpaceInvaders, 3, 29, 1, 4);
            ImageManager.Add(Image.Name.AlienShotExplosion, Texture.Name.SpaceInvaders, 86, 25, 6, 8);
            ImageManager.Add(Image.Name.SquigglyShotA, Texture.Name.SpaceInvaders, 18, 26, 3, 7);
            ImageManager.Add(Image.Name.SquigglyShotB, Texture.Name.SpaceInvaders, 24, 26, 3, 7);
            ImageManager.Add(Image.Name.SquigglyShotC, Texture.Name.SpaceInvaders, 30, 26, 3, 7);
            ImageManager.Add(Image.Name.SquigglyShotD, Texture.Name.SpaceInvaders, 36, 26, 3, 7);
            ImageManager.Add(Image.Name.PlungerShotA, Texture.Name.SpaceInvaders, 42, 27, 3, 6);
            ImageManager.Add(Image.Name.PlungerShotB, Texture.Name.SpaceInvaders, 48, 27, 3, 6);
            ImageManager.Add(Image.Name.PlungerShotC, Texture.Name.SpaceInvaders, 54, 27, 3, 6);
            ImageManager.Add(Image.Name.PlungerShotD, Texture.Name.SpaceInvaders, 60, 27, 3, 6);
            ImageManager.Add(Image.Name.RollingShotA, Texture.Name.SpaceInvaders, 65, 26, 3, 7);
            ImageManager.Add(Image.Name.RollingShotB, Texture.Name.SpaceInvaders, 70, 26, 3, 7);
            ImageManager.Add(Image.Name.RollingShotC, Texture.Name.SpaceInvaders, 75, 26, 3, 7);
            ImageManager.Add(Image.Name.RollingShotD, Texture.Name.SpaceInvaders, 80, 26, 3, 7);

            ImageManager.Add(Image.Name.Brick, Texture.Name.Birds, 20, 210, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Top0, Texture.Name.Birds, 15, 180, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Top1, Texture.Name.Birds, 15, 185, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Birds, 35, 215, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Top0, Texture.Name.Birds, 75, 180, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Top1, Texture.Name.Birds, 75, 185, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Bottom, Texture.Name.Birds, 55, 215, 10, 5);


            ImageManager.Add(Image.Name.Wall, Texture.Name.Birds, 40, 185, 20, 10);


            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            GameSpriteManager.Add(GameSprite.Name.OctopusA, Image.Name.OctopusA, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.OctopusB, Image.Name.OctopusB, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.AlienA, Image.Name.AlienA, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.AlienB, Image.Name.AlienB, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.SquidA, Image.Name.SquidA, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.SquidB, Image.Name.SquidB, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.Player, Image.Name.Player, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.PlayerShot, Image.Name.PlayerShot, 20, 20, 5, 15);
            GameSpriteManager.Add(GameSprite.Name.Saucer, Image.Name.Saucer, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.AlienShotExplosion, Image.Name.AlienShotExplosion, 25, 25, 25, 25);
            GameSpriteManager.Add(GameSprite.Name.SquigglyShotA, Image.Name.SquigglyShotA, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.SquigglyShotB, Image.Name.SquigglyShotB, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.SquigglyShotC, Image.Name.SquigglyShotC, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.SquigglyShotD, Image.Name.SquigglyShotD, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.PlungerShotA, Image.Name.PlungerShotA, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.PlungerShotB, Image.Name.PlungerShotB, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.PlungerShotC, Image.Name.PlungerShotC, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.PlungerShotD, Image.Name.PlungerShotD, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.RollingShotA, Image.Name.RollingShotA, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.RollingShotB, Image.Name.RollingShotB, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.RollingShotC, Image.Name.RollingShotC, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.RollingShotD, Image.Name.RollingShotD, 15, 15, 15, 15);
            GameSpriteManager.Add(GameSprite.Name.Brick, Image.Name.Brick, 50, 25, 40, 20);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25, 40, 20);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 50, 25, 40, 20);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25, 40, 20);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 50, 25, 40, 20);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 50, 25, 40, 20);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25, 40, 20);
            GameSpriteManager.Add(GameSprite.Name.Wall, Image.Name.Wall, 448, 900, 850, 30);

            //---------------------------------------------------------------------------------------------------------
            // Create SpriteBatch
            //---------------------------------------------------------------------------------------------------------
            this.poSpriteBatchMan = new SpriteBatchManager(3, 1);
            SpriteBatchManager.SetActive(this.poSpriteBatchMan);


            SpriteBatch pSB_Text = SpriteBatchManager.Add(SpriteBatch.Name.Texts, 1);
            SpriteBatch pSB_Boxes = SpriteBatchManager.Add(SpriteBatch.Name.Boxes, 3);
            SpriteBatch pSB_Shields = SpriteBatchManager.Add(SpriteBatch.Name.Shields, 2);
            SpriteBatch pSB_Aliens = SpriteBatchManager.Add(SpriteBatch.Name.SpaceInvaders, 4);

            //---------------------------------------------------------------------------------------------------------
            // Sounds
            //---------------------------------------------------------------------------------------------------------
            Sound pShootMissile = SoundManager.Add(Sound.Name.Player_Shoot, "invaderkilled.wav");
            Sound pAlienWalk1 = SoundManager.Add(Sound.Name.Alien_Walk1, "fastinvader1.wav");
            Sound pAlienWalk2 = SoundManager.Add(Sound.Name.Alien_Walk2, "fastinvader2.wav");
            Sound pAlienWalk3 = SoundManager.Add(Sound.Name.Alien_Walk3, "fastinvader3.wav");
            Sound pAlienWalk4 = SoundManager.Add(Sound.Name.Alien_Walk4, "fastinvader4.wav");
            Sound pAlienDead = SoundManager.Add(Sound.Name.Alien_Killed, "shoot.wav");
            Sound pShipDead = SoundManager.Add(Sound.Name.Explosions, "explosion.wav");
            Sound pUFONoise = SoundManager.Add(Sound.Name.UFO, "ufo_highpitch.wav");

            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------

            InputSubject pInputSubject;
            pInputSubject = InputManager.GetArrowRightSubject();
            pInputSubject.Attach(new MoveRightObserver());

            pInputSubject = InputManager.GetArrowLeftSubject();
            pInputSubject.Attach(new MoveLeftObserver());

            pInputSubject = InputManager.GetSpaceSubject();
            pInputSubject.Attach(new ShootObserver());

            Simulation.SetState(Simulation.State.Realtime);

            //---------------------------------------------------------------------------------------------------------
            // Bombs
            //---------------------------------------------------------------------------------------------------------
            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.ActivateCollisionSprite(pSB_Boxes);
            GameObjectManager.Attach(pBombRoot);

            //---------------------------------------------------------------------------------------------------------
            // Walls
            //---------------------------------------------------------------------------------------------------------

            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateGameSprite(pSB_Boxes);
            pWallGroup.ActivateCollisionSprite(pSB_Aliens);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, GameSprite.Name.NullObject, -10, 300, 50, 2000);
            pWallLeft.ActivateCollisionSprite(pSB_Boxes);
            pWallLeft.ActivateGameSprite(pSB_Aliens);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, GameSprite.Name.NullObject, 900, 300, 50, 2000);
            pWallRight.ActivateCollisionSprite(pSB_Boxes);
            pWallLeft.ActivateGameSprite(pSB_Aliens);

            WallDown pWallTop = new WallDown(GameObject.Name.WallDown, GameSprite.Name.NullObject, 400, 900, 1000, 30);
            pWallTop.ActivateCollisionSprite(pSB_Boxes);
            pWallTop.ActivateGameSprite(pSB_Aliens);

            WallDown pWallDown = new WallDown(GameObject.Name.WallDown, GameSprite.Name.Wall, 500, 55, 2000, 30);
            pWallDown.ActivateCollisionSprite(pSB_Boxes);
            pWallDown.ActivateGameSprite(pSB_Aliens);

            //// Add to the composite the children
            pWallGroup.Add(pWallLeft);
            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallDown);

            GameObjectManager.Attach(pWallGroup);

            pWallGroup.Print();

            //---------------------------------------------------------------------------------------------------------
            // Missile
            //---------------------------------------------------------------------------------------------------------

            // Missile Root
            MissileGroup pMissileGroup = new MissileGroup(GameObject.Name.MissleGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pMissileGroup.ActivateGameSprite(pSB_Aliens);
            pMissileGroup.ActivateCollisionSprite(pSB_Boxes);

            GameObjectManager.Attach(pMissileGroup);



            //---------------------------------------------------------------------------------------------------------
            // Ship
            //---------------------------------------------------------------------------------------------------------

            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pShipRoot.ActivateGameSprite(pSB_Aliens);
            pShipRoot.ActivateCollisionSprite(pSB_Boxes);

            GameObjectManager.Attach(pShipRoot);

            ShipManager.Create();

            //---------------------------------------------------------------------------------------------------------
            // UFO
            //---------------------------------------------------------------------------------------------------------
            UFORoot pUFORoot = new UFORoot(GameObject.Name.UFORoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pUFORoot.ActivateGameSprite(pSB_Aliens);
            pUFORoot.ActivateCollisionSprite(pSB_Boxes);

            UFO pUFOLeft = new UFO(GameObject.Name.UFO, GameSprite.Name.Saucer, -30, 800);
            pUFOLeft.ActivateCollisionSprite(pSB_Boxes);
            pUFOLeft.ActivateGameSprite(pSB_Aliens);

            
                

            pUFORoot.Add(pUFOLeft);
           

            GameObjectManager.Attach(pUFORoot);

            // create the factory 
            AlienFactory factory = new AlienFactory(SpriteBatch.Name.SpaceInvaders, SpriteBatch.Name.Boxes);

            AlienGrid pGrid = (AlienGrid)factory.Create(GameObject.Name.AlienGrid, Alien.Type.Grid);
            pGrid.ActivateCollisionSprite(pSB_Boxes);

            GameObject pGameObject;

            // create column 1
            GameObject pCol1 = factory.Create(GameObject.Name.AlienColumn1, Alien.Type.Column);
            pGrid.Add(pCol1);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 50.0f, 750.0f);
            pCol1.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 50.0f, 700.0f);
            pCol1.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 50.0f, 650.0f);
            pCol1.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 50.0f, 600.0f);
            pCol1.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 50.0f, 550.0f);
            pCol1.Add(pGameObject);

            // create column 2
            GameObject pCol2 = factory.Create(GameObject.Name.AlienColumn2, Alien.Type.Column);
            pGrid.Add(pCol2);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 100.0f, 750.0f);
            pCol2.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 100.0f, 700.0f);
            pCol2.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 100.0f, 650.0f);
            pCol2.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 100.0f, 600.0f);
            pCol2.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 100.0f, 550.0f);
            pCol2.Add(pGameObject);

            // create column 3
            GameObject pCol3 = factory.Create(GameObject.Name.AlienColumn3, Alien.Type.Column);
            pGrid.Add(pCol3);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 150.0f, 750.0f);
            pCol3.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 150.0f, 700.0f);
            pCol3.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 150.0f, 650.0f);
            pCol3.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 150.0f, 600.0f);
            pCol3.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 150.0f, 550.0f);
            pCol3.Add(pGameObject);

            // create column 4
            GameObject pCol4 = factory.Create(GameObject.Name.AlienColumn4, Alien.Type.Column);
            pGrid.Add(pCol4);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 200, 750.0f);
            pCol4.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 200.0f, 700.0f);
            pCol4.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 200.0f, 650.0f);
            pCol4.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 200.0f, 600.0f);
            pCol4.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 200.0f, 550.0f);
            pCol4.Add(pGameObject);

            // create column 5
            GameObject pCol5 = factory.Create(GameObject.Name.AlienColumn5, Alien.Type.Column);
            pGrid.Add(pCol5);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 250.0f, 750.0f);
            pCol5.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 250.0f, 700.0f);
            pCol5.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 250.0f, 650.0f);
            pCol5.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 250.0f, 600.0f);
            pCol5.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 250.0f, 550.0f);
            pCol5.Add(pGameObject);

            // create column 6
            GameObject pCol6 = factory.Create(GameObject.Name.AlienColumn6, Alien.Type.Column);
            pGrid.Add(pCol6);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 300.0f, 750.0f);
            pCol6.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 300.0f, 700.0f);
            pCol6.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 300.0f, 650.0f);
            pCol6.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 300.0f, 600.0f);
            pCol6.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 300.0f, 550.0f);
            pCol6.Add(pGameObject);

            // create column 7
            GameObject pCol7 = factory.Create(GameObject.Name.AlienColumn7, Alien.Type.Column);
            pGrid.Add(pCol7);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 350.0f, 750.0f);
            pCol7.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 350.0f, 700.0f);
            pCol7.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 350.0f, 650.0f);
            pCol7.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 350.0f, 600.0f);
            pCol7.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 350.0f, 550.0f);
            pCol7.Add(pGameObject);

            // create column 8
            GameObject pCol8 = factory.Create(GameObject.Name.AlienColumn8, Alien.Type.Column);
            pGrid.Add(pCol8);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 400.0f, 750.0f);
            pCol8.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 400.0f, 700.0f);
            pCol8.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 400.0f, 650.0f);
            pCol8.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 400.0f, 600.0f);
            pCol8.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 400.0f, 550.0f);
            pCol8.Add(pGameObject);

            // create column 9
            GameObject pCol9 = factory.Create(GameObject.Name.AlienColumn9, Alien.Type.Column);
            pGrid.Add(pCol9);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 450.0f, 750.0f);
            pCol9.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 450.0f, 700.0f);
            pCol9.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 450.0f, 650.0f);
            pCol9.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 450.0f, 600.0f);
            pCol9.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 450.0f, 550.0f);
            pCol9.Add(pGameObject);

            // create column 10
            GameObject pCol10 = factory.Create(GameObject.Name.AlienColumn10, Alien.Type.Column);
            pGrid.Add(pCol10);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 500.0f, 750.0f);
            pCol10.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 500.0f, 700.0f);
            pCol10.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 500.0f, 650.0f);
            pCol10.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 500.0f, 600.0f);
            pCol10.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 500.0f, 550.0f);
            pCol10.Add(pGameObject);

            // create column 11
            GameObject pCol11 = factory.Create(GameObject.Name.AlienColumn11, Alien.Type.Column);
            pGrid.Add(pCol11);

            pGameObject = factory.Create(GameObject.Name.SquidA, Alien.Type.Squid, 550.0f, 750.0f);
            pCol11.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 550.0f, 700.0f);
            pCol11.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.AlienA, Alien.Type.Crab, 550.0f, 650.0f);
            pCol11.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 550.0f, 600.0f);
            pCol11.Add(pGameObject);

            pGameObject = factory.Create(GameObject.Name.OctopusA, Alien.Type.Octopus, 550.0f, 550.0f);
            pCol11.Add(pGameObject);

            GameObjectManager.Attach(pGrid);

            //---------------------------------------------------------------------------------------------------------
            // Shields
            //---------------------------------------------------------------------------------------------------------

            // create the factory
            Composite pShieldRoot = (Composite)new ShieldRoot(GameObject.Name.ShieldRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            GameObjectManager.Attach(pShieldRoot);

            ShieldFactory SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, pShieldRoot);

            // load by column
            {
                int j = 0;

                GameObject pColumn;

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                float start_x = 75.0f;
                float start_y = 250.0f;
                float off_x = 0;
                float brick_width = 20.0f;
                float brick_height = 10.0f;

                // Shield 1
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 2 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 3 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 4 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 5 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 6 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 7 * brick_height);
                SF.Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x, start_y + 8 * brick_height);
                SF.Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x, start_y + 9 * brick_height);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brick_width;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brick_height);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brick_width;
                SF.Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brick_height);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brick_width;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brick_height);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brick_width;
                SF.Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brick_height);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brick_width;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brick_height);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brick_width;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brick_height);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brick_height);
                SF.Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brick_height);
                SF.Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brick_height);

                // Shield 2
                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                float start_x_2 = 300.0f;
                float start_y_2 = 250.0f;
                float off_x_2 = 0;
                float brick_width_2 = 20.0f;
                float brick_height_2 = 10.0f;

                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2, start_y_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + 2 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + 3 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + 4 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + 5 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + 6 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + 7 * brick_height_2);
                SF.Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + 8 * brick_height_2);
                SF.Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x_2, start_y_2 + 9 * brick_height_2);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_2 += brick_width_2;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 2 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 3 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 4 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 5 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 6 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 7 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 8 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 9 * brick_height_2);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_2 += brick_width_2;
                SF.Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 2 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 3 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 4 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 5 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 6 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 7 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 8 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 9 * brick_height_2);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_2 += brick_width_2;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 3 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 4 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 5 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 6 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 7 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 8 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 9 * brick_height_2);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_2 += brick_width_2;
                SF.Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 2 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 3 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 4 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 5 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 6 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 7 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 8 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 9 * brick_height_2);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_2 += brick_width_2;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 0 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 1 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 2 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 3 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 4 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 5 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 6 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 7 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 8 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 9 * brick_height_2);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_2 += brick_width_2;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 0 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 1 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 2 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 3 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 4 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 5 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 6 * brick_height_2);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 7 * brick_height_2);
                SF.Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 8 * brick_height_2);
                SF.Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x_2 + off_x_2, start_y_2 + 9 * brick_height_2);

                // Shield 3
                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                float start_x_3 = 500.0f;
                float start_y_3 = 250.0f;
                float off_x_3 = 0;
                float brick_width_3 = 20.0f;
                float brick_height_3 = 10.0f;

                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3, start_y_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + 2 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + 3 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + 4 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + 5 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + 6 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + 7 * brick_height_3);
                SF.Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + 8 * brick_height_3);
                SF.Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x_3, start_y_3 + 9 * brick_height_3);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_3 += brick_width_3;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 2 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 3 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 4 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 5 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 6 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 7 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 8 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 9 * brick_height_3);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_3 += brick_width_3;
                SF.Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 2 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 3 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 4 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 5 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 6 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 7 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 8 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 9 * brick_height_3);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_3 += brick_width_3;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 3 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 4 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 5 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 6 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 7 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 8 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 9 * brick_height_3);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_3 += brick_width_3;
                SF.Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 2 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 3 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 4 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 5 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 6 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 7 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 8 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 9 * brick_height_3);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_3 += brick_width_3;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 0 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 1 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 2 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 3 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 4 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 5 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 6 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 7 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 8 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 9 * brick_height_3);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_3 += brick_width_3;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 0 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 1 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 2 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 3 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 4 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 5 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 6 * brick_height_3);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 7 * brick_height_3);
                SF.Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 8 * brick_height_3);
                SF.Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x_3 + off_x_3, start_y_3 + 9 * brick_height_3);

                // Start HERe
                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                float start_x_4 = 700.0f;
                float start_y_4 = 250.0f;
                float off_x_4 = 0;
                float brick_width_4 = 20.0f;
                float brick_height_4 = 10.0f;

                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4, start_y_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + 2 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + 3 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + 4 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + 5 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + 6 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + 7 * brick_height_4);
                SF.Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + 8 * brick_height_4);
                SF.Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x_4, start_y_4 + 9 * brick_height_4);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_4 += brick_width_4;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 2 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 3 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 4 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 5 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 6 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 7 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 8 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 9 * brick_height_4);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_4 += brick_width_4;
                SF.Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 2 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 3 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 4 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 5 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 6 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 7 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 8 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 9 * brick_height_4);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_4 += brick_width_4;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 3 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 4 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 5 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 6 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 7 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 8 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 9 * brick_height_4);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_4 += brick_width_4;
                SF.Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 2 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 3 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 4 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 5 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 6 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 7 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 8 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 9 * brick_height_4);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_4 += brick_width_4;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 0 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 1 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 2 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 3 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 4 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 5 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 6 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 7 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 8 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 9 * brick_height_4);

                SF.SetParent(pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x_4 += brick_width_4;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 0 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 1 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 2 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 3 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 4 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 5 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 6 * brick_height_4);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 7 * brick_height_4);
                SF.Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 8 * brick_height_4);
                SF.Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x_4 + off_x_4, start_y_4 + 9 * brick_height_4);


            }


            // Setting movement of alien sprites
            MovementSprite pMovementSprite = new MovementSprite(pGrid, 1);
            TimerManager.Add(TimeEvent.Name.SpriteMovement, pMovementSprite, 1.5f);

            // UFO stuff
            UFOTimer pUFOTimer = new UFOTimer(pUFOLeft, 1);
            float sendUFO = randomUFO.Next(25, 55);
            TimerManager.Add(TimeEvent.Name.UFOMovement, pUFOTimer, sendUFO);

            


            // Animating our 3 alien types
            AnimationSprite pSquidAnim = new AnimationSprite(GameSprite.Name.SquidA);
            pSquidAnim.Attach(Image.Name.SquidA);
            pSquidAnim.Attach(Image.Name.SquidB);
            TimerManager.Add(TimeEvent.Name.SpriteAnimation, pSquidAnim, 1.5f);

            AnimationSprite pCrabAnim = new AnimationSprite(GameSprite.Name.AlienA);
            pCrabAnim.Attach(Image.Name.AlienA);
            pCrabAnim.Attach(Image.Name.AlienB);
            TimerManager.Add(TimeEvent.Name.SpriteAnimation, pCrabAnim, 1.5f);

            AnimationSprite pOctoAnim = new AnimationSprite(GameSprite.Name.OctopusA);
            pOctoAnim.Attach(Image.Name.OctopusA);
            pOctoAnim.Attach(Image.Name.OctopusB);
            TimerManager.Add(TimeEvent.Name.SpriteAnimation, pOctoAnim, 1.5f);

            //---------------------------------------------------------------------------------------------------------
            // ColPair 
            //---------------------------------------------------------------------------------------------------------

            // associate in a collision pair
            ColPair pColPair;


            pColPair = ColPairManager.Add(ColPair.Name.Alien_Wall, pGrid, pWallGroup);
            pColPair = ColPairManager.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallGroup);
            pColPair = ColPairManager.Add(ColPair.Name.Ship_Wall, pShipRoot, pWallGroup);
            pColPair = ColPairManager.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallGroup);


            pColPair.Attach(new BombObserver());

            // missile vs UFO
            pColPair = ColPairManager.Add(ColPair.Name.Missile_UFO, pMissileGroup, pUFORoot);
            pColPair.Attach(new UFOKilledObserver());

            Debug.Assert(pColPair != null);

            // Ship vs Bomb
            pColPair = ColPairManager.Add(ColPair.Name.Ship_Bomb, pShipRoot, pBombRoot);
            pColPair.Attach(new ShipKilledObserver());

            // Alien vs Missile
            pColPair = ColPairManager.Add(ColPair.Name.Alien_Missile, pMissileGroup, pGrid);
            pColPair.Attach(new AlienKilledObserver());


            // Bomb vs Shield
            pColPair = ColPairManager.Add(ColPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());

            // Missile vs Shield
            pColPair = ColPairManager.Add(ColPair.Name.Missile_Shield, pMissileGroup, pShieldRoot);
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver());

            TextManager.Add(TextFont.Name.ScoreHeader, SpriteBatch.Name.Texts, "<P1 Score> ", Glyph.Name.Consolas20pt, 15, 1030);
            TextManager.Add(TextFont.Name.PlayerScore, SpriteBatch.Name.Texts, "000" + GameStats.GetScore().ToString(), Glyph.Name.Consolas20pt, 25, 1000);

            TextManager.Add(TextFont.Name.HighScoreHeader, SpriteBatch.Name.Texts, "<Hi-Score>", Glyph.Name.Consolas20pt, 250, 1030);
            TextManager.Add(TextFont.Name.HighScore, SpriteBatch.Name.Texts, "000" + GameStats.GetScore().ToString(), Glyph.Name.Consolas20pt, 290, 1000);

            TextManager.Add(TextFont.Name.PlayerLivesHeader, SpriteBatch.Name.Texts, "Lives: ", Glyph.Name.Consolas20pt, 15, 120);
            TextManager.Add(TextFont.Name.PlayerLives, SpriteBatch.Name.Texts, GameStats.GetLives().ToString(), Glyph.Name.Consolas20pt, 130, 120);

            TextManager.Add(TextFont.Name.CurrentLevelHeader, SpriteBatch.Name.Texts, "Level: ", Glyph.Name.Consolas20pt, 500, 1030);
            TextManager.Add(TextFont.Name.CurrentLevel, SpriteBatch.Name.Texts, GameStats.GetLevel().ToString(), Glyph.Name.Consolas20pt,620, 1030);
        }

        public override void Update(float systemTime)
        {
            Simulation.Update(systemTime);

            InputManager.Update();

            if (Simulation.GetTimeStep() > 0.0f)
            {
                TimerManager.Update(Simulation.GetTotalTime());

                ColPairManager.Process();

                GameObjectManager.Update();

                DelayedObjectManager.Process();
            }
        }

        public override void Draw()
        {
            SpriteBatchManager.Draw();
        }

        public override void Transition()
        {
            SpriteBatchManager.SetActive(this.poSpriteBatchMan);
            
        }
    }
}
