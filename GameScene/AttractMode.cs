using System.Diagnostics;

namespace SpaceInvaders
{
    public class AttractMode : SceneState
    {
        // data
        public SpriteBatchManager spriteBatchManager;
        public AttractMode()
        {
            this.Initialize();
        }

        public override void Handle()
        {
            Debug.WriteLine("Handle");
        }

        public override void Initialize()
        {
            // clear game object manager before adding in new stuff

            // now add in new stuff 


            Texture pTexture = TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXML(Glyph.Name.Consolas20pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            TextureManager.Add(Texture.Name.SpaceInvaders, "SpaceInvaders.tga");
           

            ImageManager.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageManager.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 18, 3, 12, 8);
            ImageManager.Add(Image.Name.AlienA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageManager.Add(Image.Name.AlienB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageManager.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageManager.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 72, 3, 8, 8);
            ImageManager.Add(Image.Name.Saucer, Texture.Name.SpaceInvaders, 99, 3, 16, 8);

            GameSpriteManager.Add(GameSprite.Name.Saucer, Image.Name.Saucer, 300, 450, 30, 30);
            GameSpriteManager.Add(GameSprite.Name.SquidA, Image.Name.SquidA, 300, 400, 30, 30);
            GameSpriteManager.Add(GameSprite.Name.AlienA, Image.Name.AlienA, 300, 350, 30, 30);
            GameSpriteManager.Add(GameSprite.Name.OctopusA, Image.Name.OctopusA, 300, 300, 30, 30);

            this.spriteBatchManager = new SpriteBatchManager(3, 1);
            SpriteBatchManager.SetActive(this.spriteBatchManager);

            SpriteBatch pSB_Texts = SpriteBatchManager.Add(SpriteBatch.Name.Texts, 1);
            SpriteBatch pSB_Aliens = SpriteBatchManager.Add(SpriteBatch.Name.SpaceInvaders, 2);


           
            TextFont pIntro = TextManager.Add(TextFont.Name.PlayMessage, SpriteBatch.Name.Texts, "PLAY", Glyph.Name.Consolas20pt, 400, 800);
            TextFont pGameName = TextManager.Add(TextFont.Name.SpaceInvaders, SpriteBatch.Name.Texts, "SPACE INVADERS", Glyph.Name.Consolas20pt, 300, 750);
            TextFont pInstruct = TextManager.Add(TextFont.Name.LaunchGame, SpriteBatch.Name.Texts, "PUSH '1' TO LAUNCH GAME", Glyph.Name.Consolas20pt, 250, 650);
            TextFont pTable = TextManager.Add(TextFont.Name.ScoreHeader, SpriteBatch.Name.Texts, "*SCORE ADVANCE TABLE*", Glyph.Name.Consolas20pt, 250, 550);
            TextFont pUFOVal = TextManager.Add(TextFont.Name.UFOScore, SpriteBatch.Name.Texts, "= ? MYSTERY", Glyph.Name.Consolas20pt, 350, 450);
            TextFont pSquidVal = TextManager.Add(TextFont.Name.SquidScore, SpriteBatch.Name.Texts, "= 30 POINTS", Glyph.Name.Consolas20pt, 350, 400);
            TextFont pCrabVal = TextManager.Add(TextFont.Name.CrabScore, SpriteBatch.Name.Texts, "= 20 POINTS", Glyph.Name.Consolas20pt, 350, 350);
            TextFont pOctoVal = TextManager.Add(TextFont.Name.OctoScore, SpriteBatch.Name.Texts, "= 10 POINTS", Glyph.Name.Consolas20pt, 350, 300);

            ProxySprite pUFOProxy = ProxySpriteManager.Add(GameSprite.Name.Saucer);
            pUFOProxy.x = 300;
            pUFOProxy.y = 450;

            ProxySprite pSquidProxy = ProxySpriteManager.Add(GameSprite.Name.SquidA);
            pSquidProxy.x = 300;
            pSquidProxy.y = 400;

            ProxySprite pCrabProxy = ProxySpriteManager.Add(GameSprite.Name.AlienA);
            pCrabProxy.x = 300;
            pCrabProxy.y = 350;

            ProxySprite pOctoProxy = ProxySpriteManager.Add(GameSprite.Name.OctopusA);
            pOctoProxy.x = 300;
            pOctoProxy.y = 300;

            pSB_Aliens.Attach(pUFOProxy);
            pSB_Aliens.Attach(pSquidProxy);
            pSB_Aliens.Attach(pCrabProxy);
            pSB_Aliens.Attach(pOctoProxy);
        }

        public override void Update(float systemTime)
        {
            InputManager.Update();

            if (Simulation.GetTimeStep() > 0.0f)
            {
                TimerManager.Update(Simulation.GetTotalTime());

                ColPairManager.Process();

                //GameObjectManager.Update();

                DelayedObjectManager.Process();
            }
        }

        public override void Draw()
        {
            SpriteBatchManager.Draw();
        }

        public override void Transition()
        {
            SpriteBatchManager.SetActive(this.spriteBatchManager);
        }
    }
}
