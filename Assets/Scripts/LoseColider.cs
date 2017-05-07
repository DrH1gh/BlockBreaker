using UnityEngine;
using System.Collections;

public class LoseColider : MonoBehaviour {

    public static int livesCount = 4;
    public AudioClip loseLife;

    private LevelManager levelManager;
    private Ball leBall;
    private Paddle lePaddle;
    private Lives leLives;
    private Score leScore;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        //Se trage daca e bifa de trigger
        print("Trigger");
        //Find Objects
        leBall = GameObject.FindObjectOfType<Ball>();
        lePaddle = GameObject.FindObjectOfType<Paddle>();
        leLives = GameObject.FindObjectOfType<Lives>();
        leScore = GameObject.FindObjectOfType<Score>();
        LivesLogic();
      
    }

    void LivesLogic()
    {
        if (livesCount > 1)
        {
            Vector3 ballNewPosition = lePaddle.transform.position + new Vector3(1, 0.5f, 0);
            leBall.transform.position = ballNewPosition;
            //leBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 11f);
        }

        livesCount--;

        if (livesCount <= 0)
        {
            levelManager.LoadLevel("GameOver");
        }
        else
        {
            AudioSource.PlayClipAtPoint(loseLife, lePaddle.transform.position, 1f);
            //Schimb vietile stanga jos, in functie de livesCout
            leLives.LoadSprite();
            if(livesCount == 3)
                leScore.UpdateScore(-25);
            else
                leScore.UpdateScore(-120);
        }
    }
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
