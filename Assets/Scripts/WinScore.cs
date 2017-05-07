using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var finalScore = GameObject.FindObjectOfType<WinScore>();
        finalScore.GetComponent<Text>().text = Score.gameScore.ToString(); 
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
