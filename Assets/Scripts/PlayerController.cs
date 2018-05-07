using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    Animator animator;
    public static int myHealth;

    private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myHealth = HealthBarScript.health;
    }
	
	// Update is called once per frame
	void Update () {
       // myRigidBody.velocity = new Vector2(escapeSpeed, myRigidBody.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveSpeed);
            transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveSpeed * -1);
            transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime * -1));
        }
        else
        {
            //myRigidBody.velocity = new Vector2(escapeSpeed,0);
            //transform.Translate(new Vector2(escapeSpeed * Time.deltaTime, 0));
        }
        //Objenin kameranın sınırları içinde kalmasını sağlıyor
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if(HealthBarScript.health > myHealth)
        {
            myHealth = HealthBarScript.health;
        }
        else if (HealthBarScript.health < myHealth)
        {
            playHit();
            myHealth = HealthBarScript.health;
            Invoke("playHit", 1);
        }
    }
    void playHit()
    {
        animator.SetTrigger("hitDiver");
    }
}
