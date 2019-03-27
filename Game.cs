using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpaceInvaders : Azul.Game
    { 
        Scene pScene = null;
        int counter = 1;
        
       
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Space Invaders");
            this.SetWidthHeight(896, 1094);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Setup Managers
            //---------------------------------------------------------------------------------------------------------
            Simulation.Create();
            TimerManager.Create(3, 1);
            TextureManager.Create(5, 1);
            ImageManager.Create(7, 2);
            GameSpriteManager.Create(8, 4);
            BoxSpriteManager.Create(3, 1);
            SpriteBatchManager.Create();
            ProxySpriteManager.Create(10, 1);
            GameObjectManager.Create(3, 1);
            ColPairManager.Create(1, 1);
            GlyphManager.Create(4, 1);
            TextManager.Create(3, 1);
            SoundManager.Create(5, 1);
            GameStats.CreateGameStats();

            pScene = new Scene();
        }

           
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------


        

        public override void Update()
        {
            
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                pScene.SetState(Scene.SceneName.Level1);
            }

            if(GameStats.GetLevel() == 1 && GameStats.GetRemainingAliens() == 0)
            {
                GameStats.IncreaseLvl();
                GameStats.ReplenishAliens();
                counter = 2;
                pScene.SetState(Scene.SceneName.Level2);
            }

            if(GameStats.GetLevel() == 2 && GameStats.GetRemainingAliens() == 0)
            {
                counter = 1;
                pScene.SetState(Scene.SceneName.GameOver_GameWon);
                
            }

            if(GameStats.GetLives() == 0)
            {
                pScene.SetState(Scene.SceneName.GameOver_GameLose);
                counter = 1;
            }

            if(Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_T) == true)
            {
                SpriteBatch pSBToggle = SpriteBatchManager.Find(SpriteBatch.Name.Boxes);
                Debug.Assert(pSBToggle != null);
                pSBToggle.SetDrawEnable(false);
            }

            if(Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_X))
            {
                SpriteBatch pSBToggle = SpriteBatchManager.Find(SpriteBatch.Name.Boxes);
                Debug.Assert(pSBToggle != null);
                pSBToggle.SetDrawEnable(true);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_0) == true)
            {
                counter = 1;
                pScene.SetState(Scene.SceneName.Attract);
                GameStats.ReplenishAliens();
                GameStats.ReplenishLives();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE) == true)
            {
                if (counter == 1) 
                {
                    // This is just to Keep the game from crashing when space is hit in other game states.
                    pScene.SetState(Scene.SceneName.Level1);
                }
                
                
            }
            

            // update the scene
            pScene.GetState().Update(this.GetTime());

        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------

        public override void Draw()
        {
            // draw all objects
            pScene.GetState().Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}
