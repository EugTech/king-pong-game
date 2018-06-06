using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public float speed = 5f;
	public float tolerance = 0f;

	public float spawnVariance = 3;
    Vector3 dirV3;
    Vector2 dir;
    Rigidbody rb;

	public float leftBound = -12;
	public float rightBound = 12;

	public bool RandoRot = false;


	float interactionTimerL = 0.05f;
	float iTimer = 0;


    public ScoreController sc;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        Spawn();
        

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > rightBound)
        {
			try
			{
				ScoreKeeper.Instance.ScoreME(2, 1);
			}
			catch { }
            Spawn();
        }
		else if(transform.position.x < leftBound)
		{
			try
			{
				ScoreKeeper.Instance.ScoreME(1, 1);
			}
			catch { }
			Spawn();
		}

		if(iTimer > 0)
		{
			iTimer -= Time.deltaTime;
		}
	}

	private void LateUpdate()
	{

		if (rb.velocity.magnitude > speed - tolerance)
		{
			rb.velocity = rb.velocity.normalized * speed;
		}
		if (rb.velocity.magnitude < speed + tolerance)
		{
			rb.velocity = rb.velocity.normalized * speed;
		}
	}

	void Spawn() {
        transform.position = Vector3.zero + Vector3.up * Random.Range(-spawnVariance, spawnVariance) ;
        dir = Random.insideUnitCircle;
        dirV3 = new Vector3(dir.x, dir.y);
        rb.velocity = dirV3 * speed;
    }

    private void OnCollisionEnter(Collision col)
    {
		if (iTimer <= 0)
		{

			if (col.gameObject.tag == "Paddle")
			{
				Vector3 paddle = col.transform.position;
				Vector3 angle = paddle - transform.position;
				float mag = Vector3.Magnitude(angle);

				Vector3 reflection = Vector3.Reflect(rb.velocity, col.contacts[0].normal);

				//rb.velocity = -angle * speed;
				//speed = (1f / mag) * 5;

				rb.velocity = (-angle + reflection + rb.velocity.magnitude * col.contacts[0].normal * -1f) * speed;
			}
			else
			{
				if (rb.velocity.x > 0)
				{
					rb.velocity = rb.velocity.normalized * 0.9f + Vector3.right * 0.1f; 


				}
				else if (rb.velocity.x < 0)
				{
					rb.velocity = rb.velocity.normalized * 0.9f + Vector3.left * 0.1f;

				}
			}

			iTimer = interactionTimerL;

			if (RandoRot)
			{
				rb.maxAngularVelocity = 45;
				rb.angularVelocity = Random.onUnitSphere * Random.Range(-45, 45);
			}
		}
		else
		{
			Debug.Log("Already Collided " + col.gameObject.name);
		}
	}
}
