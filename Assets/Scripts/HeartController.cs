using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour {

    public float moveSpeed;
    Animator animator;
    public AudioClip healSound;
    public GameObject megalodon;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(moveSpeed * Time.deltaTime * -1, 0));
        Destroy(gameObject, 4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "diver 0")
        {
            Debug.Log("Kalp Dokundu");
            HealthBarScript.health += 1;
            animator.SetTrigger("hitHeart");
            SoundManager.instance.RandomizeSfx(healSound);
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
