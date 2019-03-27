using System.Diagnostics;
using System;

namespace SpaceInvaders
{
    public class GameStats
    {
        // data to rule over all the important game stats
        private static GameStats pInstance = null;
        public TextFont updateScoreText;
        public TextFont updateHighScoreText;
        public TextFont updatePlayerLivesText;
        public int alienCount;
        public int pointsEarned;
        public int playerLives;
        public int CurrLvL;
        public int highScore;

        public GameStats()
        {
            this.alienCount = 55;
            this.pointsEarned = 0;
            this.playerLives = 3;
            this.highScore = 0;
            this.CurrLvL = 1;
        }

        public static void CreateGameStats()
        {
            if (pInstance == null)
            {
                pInstance = new GameStats();
            }
        }

        private static GameStats getInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static void OnAlienHit(int pointsGiven)
        {
            GameStats.getInstance().pointsEarned += pointsGiven;
            Console.WriteLine(GameStats.getInstance().pointsEarned);

            // Update the player score
            GameStats.getInstance().updateScoreText = TextManager.Find(TextFont.Name.PlayerScore);
            String scoreToString = getInstance().pointsEarned.ToString();
            getInstance().updateScoreText.UpdateMessage(scoreToString);

            // update the high score
            if(getInstance().pointsEarned > getInstance().highScore)
            {
                GameStats.getInstance().highScore = GameStats.getInstance().pointsEarned;
                GameStats.getInstance().updateHighScoreText = TextManager.Find(TextFont.Name.HighScore);
                String updateHighScore = getInstance().highScore.ToString();
                getInstance().updateHighScoreText.UpdateMessage(updateHighScore);
            }

            // decrease alien count each time 
            GameStats.getInstance().alienCount--;

            
        }
        

        public static void OnPlayerHit()
        {
            GameStats.getInstance().playerLives--;
            Console.WriteLine(getInstance().playerLives);
            // update the # of lives player has
            GameStats.getInstance().updatePlayerLivesText = TextManager.Find(TextFont.Name.PlayerLives);
            String livesToString = getInstance().playerLives.ToString();
            getInstance().updatePlayerLivesText.UpdateMessage(livesToString);
        }

        public static void OnUFOHit(int pointsGiven)
        {
            GameStats.getInstance().pointsEarned += pointsGiven;

            // update player score after receiving random points from UFO
            GameStats.getInstance().updateScoreText = TextManager.Find(TextFont.Name.PlayerScore);
            String scoreToString = getInstance().pointsEarned.ToString();
            getInstance().updateScoreText.UpdateMessage(scoreToString);

            // update the high score
            if (getInstance().pointsEarned > getInstance().highScore)
            {
                GameStats.getInstance().highScore = GameStats.getInstance().pointsEarned;
                GameStats.getInstance().updateHighScoreText = TextManager.Find(TextFont.Name.HighScore);
                String updateHighScore = getInstance().highScore.ToString();
                getInstance().updateHighScoreText.UpdateMessage(updateHighScore);
            }


        }
        public static int GetScore()
        {
            // returns the score after aliens/ufo hit
            return GameStats.getInstance().pointsEarned;
        }

        public static int GetLives()
        {
            // returns # lives remaining after player ship hit
            return GameStats.getInstance().playerLives;
        }

        public static int GetRemainingAliens()
        {
            // returns # of living aliens
            return GameStats.getInstance().alienCount;
        }

        public static int ReplenishAliens()
        {
            return GameStats.getInstance().alienCount = 55;
        }

        public static int ReplenishLives()
        {
            return GameStats.getInstance().playerLives = 3;
        }

        public static void IncreaseLvl()
        {
            GameStats.getInstance().CurrLvL++;
        }
        public static int GetLevel()
        {
            return GameStats.getInstance().CurrLvL;
        }
    }
}
