using System;
using UnityEngine;



public class Paddle : MonoBehaviour {

    public bool AutoPlayForTesting = false;

    private LevelManager levelManager;
    private Ball leBall;

    // Use this for initialization
    void Start () {

        

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        leBall = GameObject.FindObjectOfType<Ball>();

        if (levelManager.ReturnIndexOfCurentLevel() >= 20) //HARD MODE, SOME BUGS - cum iese mingea din paddle
        {
            Transform transformPropertyOfPaddle = this.GetComponent<Transform>();
            transformPropertyOfPaddle.localScale = new Vector3(1, 1, 1);
            transformPropertyOfPaddle.position = new Vector3(7.5f, 0.4299998f, 0);
        }
            
	}
	
	// Update is called once per frame
	void Update () {
        if (!AutoPlayForTesting)
        {
            MoveWithMouse();
        }else
        {
            AutoPlay();
        }
      

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if(leBall.transform.position.x > (this.transform.position.x - this.transform.localScale.x / 2)  ) // a lovit in stanga
        //{
        //   // leBall.GetComponent<Rigidbody2D>().velocity = new Vector2(11f, 0f);
        //}
        //else if(leBall.transform.position.x < (this.transform.position.x  + this.transform.localScale.x / 2)) // a lovit in dreapta
        //{
        //    leBall.GetComponent<Rigidbody2D>().transform.right = new Vector2(11f, 0f);
     
        //}
       
    }


    void AutoPlay()
    {
        Vector3 ballPositon = leBall.transform.position;
       
        Vector3 paddlePosition = new Vector3(0f, this.transform.position.y, 0f);
        paddlePosition.x = Mathf.Clamp(ballPositon.x -1f, 0f, 14f);
        this.transform.position = paddlePosition;
    }

    void MoveWithMouse()
    {
        //print(Input.mousePosition / Screen.width);  // interval 0 - 1
        //print(Input.mousePosition.x / Screen.width * 16);  // mouse position in game units (16 game units, patratele alea transparente)

        float mousePositionInGameUnits = Input.mousePosition.x / Screen.width * 16;
        //this = paddle ca e scriptu pus pe el
        //this.transform.position.x = mousePositionInGameUnits; //asta nu pot sa fac, trebuie sa asignez pt un vector 3!!!!
        Vector3 paddlePosition = new Vector3(0f, this.transform.position.y, 0f);
        paddlePosition.x = Mathf.Clamp(mousePositionInGameUnits, 0f, 14.13f);
        this.transform.position = paddlePosition;
    }
}
