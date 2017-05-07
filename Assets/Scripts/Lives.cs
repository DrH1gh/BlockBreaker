using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

    public Sprite[] livesSprite;


    // Use this for initialization
    void Start () {
        
	}
  
    public void LoadSprite()
    {
        int livesCount = LoseColider.livesCount - 1;
        this.GetComponent<SpriteRenderer>().sprite = livesSprite[livesCount];

        //if (livesSprite[livesCount])
        //{
            
        //}
    }

    // Update is called once per frame
    void Update () {
	
	}
}
