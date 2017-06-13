using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject particle;

    [SerializeField] //makes variable show up in editor even though it is private
    private float speed;
    bool started, gameover;

    Rigidbody rb;

    void Awake() //called before start
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
        started = false;//not necessary to write
        gameover = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }
        }

        //Debug.DrawRay(transform.position, Vector3.down, Color.red); //Draws Ray at position to dev help

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))//when ray under ball is not coliding with any other object, game over
        {
            gameover = true;
            rb.velocity = new Vector3(0, -25f, 0); //make the ball fall down

            Camera.main.GetComponent<CameraFollow>().gameover = true;

            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameover)
        {
            SwitchDirection();
        }

	}

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {

            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            ScoreManager.instance.diamondScore();
            Destroy(part, 1f);

        }
    }
}
