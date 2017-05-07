using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int gameScore;
    public static bool isTryAgain;
	// Use this for initialization
	void Start () {
        UpdateScore(0);
        if (isTryAgain)
        {
            UpdateScore(-2000);
            isTryAgain = false;
        }
    }

    public void UpdateScore(int addScore)
    {
        var score = GameObject.FindObjectOfType<Score>();
        gameScore += addScore;
        score.GetComponent<Text>().text = gameScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
