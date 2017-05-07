using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int curentLevelIndex;

    public void LoadLevel(string name)
    {
        Debug.Log("Level loaded " + name);
        InitVars();
        SceneManager.LoadScene(name);

        //HideCursor
        if (name == "Startmenu" || name == "GameOver" || name == "Win")
        {
            Cursor.visible = true;
            if(name == "Startmenu")
            {
                //ResetScore
                Score.gameScore = 0;
            }
        }
        else
            Cursor.visible = false;
    }

    public void LoadNextLevel()
    { 
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        curentLevelIndex = nextLevel;
        InitVars();
        SceneManager.LoadScene(nextLevel);
        //HideCursor
        if (nextLevel == 1)
        {
            Cursor.visible = true;
            //ResetScore
            if (curentLevelIndex == 0)
                Score.gameScore = 0;
        }
        else
            Cursor.visible = false;
    }

    public int ReturnIndexOfCurentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void BrickDestroyed()
    {
        if(Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

    public void PlayAgainCurentLevel()
    {
        InitVars();
        Score.isTryAgain = true;
        SceneManager.LoadScene(curentLevelIndex);
        //HideCursor
        if (curentLevelIndex == 0 || curentLevelIndex == 1)
        {
            Cursor.visible = true;
            //ResetScore
            if(curentLevelIndex == 0)
                Score.gameScore = 0;
        }
        else
            Cursor.visible = false;
    }

    public void InitVars()
    {
        LoseColider.livesCount = 4;
        Brick.breakableCount = 0;
    }

    public void QuitGame()
    {
        Debug.Log("Quiting... Works only if you make a build.");
        Application.Quit();
    }
}
