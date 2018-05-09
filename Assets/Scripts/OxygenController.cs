using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenController : MonoBehaviour {

    public float moveSpeed;
	Animator animator;
    public AudioClip airSound;
    public GameObject megalodon;

    // Use this for initialization
    void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(moveSpeed * Time.deltaTime * -1, 0));
        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "diver 0")
        {
            Debug.Log("Oksijen Dokundu");
            OxygenBarScript.oxygen += 25f;
			animator.SetTrigger("hitOxygen");
            SoundManager.instance.RandomizeSfx(airSound);
        }
        else if (collision.name == "Megalodon")
        {
            Physics.IgnoreCollision(megalodon.GetComponent<Collider>(), GetComponent<Collider>());
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
