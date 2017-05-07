using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    
    //Pentru a accesa clasa Paddle de aici, NU uita drag and drop la Paddle object in Ball object (unity interface)
    private Paddle paddle;
    private Vector3 paddleToBallDistance;
    private bool GameHasStarted = true;

    //Public vars
    public int BallSpeed = 11;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallDistance = this.transform.position - paddle.transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameHasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallDistance; //cand se face asta - ATENTIE la cum se executa scripturile, daca se executa scripul Ball inainte de Paddle, NU o sa stie pozitia..logic. To FIX -> Edit -> Proj Settings -> Script executing order.

            //Mouse CLICK
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked");
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, BallSpeed);
                GameHasStarted = false;
            }
        }
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweakBallVelocity = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        AudioSource audio = GetComponent<AudioSource>();
        if (!GameHasStarted)
        {
            audio.Play();
            this.GetComponent<Rigidbody2D>().velocity += tweakBallVelocity;
        }

    }
}
