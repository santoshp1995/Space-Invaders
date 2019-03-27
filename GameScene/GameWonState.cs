using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class GameWonState : SceneState
    {
        // data
        public SpriteBatchManager spriteBatchManager;
        public GameWonState()
        {
            this.Initialize();
        }

        public override void Handle()
        {
            
        }

        public override void Initialize()
        {
            Texture pTexture = TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXML(Glyph.Name.Consolas20pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            this.spriteBatchManager = new SpriteBatchManager(3, 1);
            SpriteBatchManager.SetActive(this.spriteBatchManager);

            SpriteBatch pSB_Texts = SpriteBatchManager.Add(SpriteBatch.Name.Texts, 1);


            TextManager.Add(TextFont.Name.GameOverMessage, SpriteBatch.Name.Texts, "GAME OVER", Glyph.Name.Consolas20pt, 300.0f, 650.0f);
            TextManager.Add(TextFont.Name.GameResult, SpriteBatch.Name.Texts, "YOU WON!", Glyph.Name.Consolas20pt, 300.0f, 600.0f);
            TextManager.Add(TextFont.Name.StartOver, SpriteBatch.Name.Texts, "PUSH '0' TO CYCLE BACK TO ATTRACT MODE", Glyph.Name.Consolas20pt, 50.0f, 500.0f);
        }

        public override void Update(float systemTime)
        {
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
            SpriteBatchManager.SetActive(this.spriteBatchManager);
        }
    }
}
