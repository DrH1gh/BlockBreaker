using UnityEngine;

using System.Collections;
using System;

public class Brick : MonoBehaviour {


    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;
    public GameObject smokePrefab;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    private Score leScore;

    //void Awake()
    //{
    //    breakableCount = 0;
    //}

    // Use this for initialization
    void Start () {
        isBreakable = (gameObject.tag == "Breakable");
        
        if (isBreakable)
        {
            breakableCount++;
            
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        leScore = GameObject.FindObjectOfType<Score>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 1.0f);
        
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {

        timesHit++;
        //SimulateWin();
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();

            //trigger smoke 
            GameObject smokePuff = (GameObject) Instantiate(smokePrefab, gameObject.transform.position, Quaternion.identity); // a trebuit sa castez Object la GameObject
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            
            //destroyOBJ
            Destroy(gameObject);

            //Update Score
            leScore.UpdateScore(50);
        }
        else
        {
            LoadSprite();
        }
    }

    private void LoadSprite()
    {
        int spriteIndex = timesHit - 1; //incarcam indexu pozei 0, ca asa le-am pus :)))
        if (hitSprites[spriteIndex]) // Daca gaseste setat un sprite cu index-u asta pe BRICK-ul respectiv ATUNCI LOAD; Altfel - incarca si daca nu exista, si avea collider. Not Good
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];  //hitSprite - este var public, si completata in editor cu spriteurile, si aleg indexu :)
        }
    }

    //TODO: Remove this methode
    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
