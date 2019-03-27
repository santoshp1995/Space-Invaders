using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TextFont : DLink
    {
        // class data
        public Name name;
        public TextSprite pTxtSprite;
        static private String pNullString = "null";

        public enum Name
        {
            ScoreHeader,
            PlayerScore,
            HighScoreHeader,
            HighScore,
            PlayerLivesHeader,
            PlayerLives,
            PlayMessage,
            SpaceInvaders,
            OctoScore,
            CrabScore,
            SquidScore,
            UFOScore,
            LaunchGame,
            GameOverMessage,
            ScoreInstruction,
            FinalScoreHeader,
            FinalScore,
            GameResult,
            NullObject,
            CurrentLevelHeader,
            CurrentLevel,
            StartOver,
            Uninitilized
        }

        public TextFont() : base()
        {
            this.name = Name.Uninitilized;
            this.pTxtSprite = new TextSprite();
        }

        ~TextFont()
        {

        }

        public void UpdateMessage(String pMessage)
        {
            Debug.Assert(pMessage != null);
            Debug.Assert(this.pTxtSprite != null);

            this.pTxtSprite.UpdateMessage(pMessage);
        }

        public void Set(TextFont.Name name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            Debug.Assert(pMessage != null);

            this.name = name;
            this.pTxtSprite.Set(name, pMessage, glyphName, xStart, yStart);
        }

        public void Wash()
        {
            this.name = Name.Uninitilized;
            this.pTxtSprite.Set(TextFont.Name.NullObject, pNullString, Glyph.Name.NullObject, 0.0f, 0.0f);
        }

    }
}
