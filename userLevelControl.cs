using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BambamGames {
    public class userLevelControl : MonoBehaviour {
        
        internal int highScore = 0;
        internal int highKillScore = 0;
        public int kill = 0;
        //Kill and level text components
        public Transform killText;
        public Transform levelText;
        
        //Prefs name for get kill,high score and level numbers
        public string killPlayerPrefs = "Kill";
        public string highScorePlayerPrefs = "HighScore";
        public string levelPlayerPrefs = "Level";

        /* 
            Progress Image
            Image
            Type:Filled
            Fill Method:Horizontal
            Fill Origin:Left            
        */
        public Image killBarFill;

        //Level and required kill number
        public int Userlevel = 0;
        public int UserLevelFaktor = 100;
        public int UserLevelFaktorArtim = 1;

        void Start(){

            //Get the highscore & Level & Kill information for the player
            highScore = PlayerPrefs.GetInt(highScorePlayerPrefs, 0);
            Userlevel = PlayerPrefs.GetInt(levelPlayerPrefs, 1);
            highKillScore = PlayerPrefs.GetInt(killPlayerPrefs, 0);
            kill = highKillScore;
            //Look level and required kill
            killText.GetComponent<Text>().text = kill.ToString() + " / " + (Userlevel * UserLevelFaktor * UserLevelFaktorArtim);
            levelText.GetComponent<Text>().text = "LEVEL : " + Userlevel;
            //Find required kill
            float gecici_degisken = (kill % (UserLevelFaktor* UserLevelFaktorArtim));
            //Fill the bar
            if (kill == 0)
            {
                killBarFill.GetComponent<Image>().fillAmount = 0;
            }
            else
            {
                if (gecici_degisken / (UserLevelFaktor* UserLevelFaktorArtim) == 0)
                {
                    killBarFill.GetComponent<Image>().fillAmount = 0;
                }
                else
                {
                    killBarFill.GetComponent<Image>().fillAmount = gecici_degisken / (UserLevelFaktor* UserLevelFaktorArtim);
                }
            }
        }
    }
}