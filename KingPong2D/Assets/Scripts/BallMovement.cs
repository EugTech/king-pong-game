using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public float speed = 5f;
    Vector3 dirV3;
    Vector2 dir;
    Rigidbody rb;
  
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        Spawn();
        

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 6 || transform.position.x < -6)
        {
            Spawn();
        }
	}

    void Spawn() {
        transform.position = Vector3.zero;
        dir = Random.insideUnitCircle;
        dirV3 = new Vector3(dir.x, dir.y);
        rb.velocity = dirV3 * speed;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Paddle")
        {
            Vector3 paddle = col.transform.position;
            Vector3 angle = paddle - transform.position;
            float mag = Vector3.Magnitude(angle);
            rb.velocity = -angle * speed;
        }
    }
}
