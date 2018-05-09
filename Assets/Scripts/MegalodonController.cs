using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonController : MonoBehaviour {

    Animator animator;
    public GameObject diver;
    BoxCollider2D boxCol;
    public AudioClip eatSound;

    float randomTime,newTime;

    public Transform startMarker;
    public Transform endMarker;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        newTime = Random.Range(5, 10);
    }
	
	// Update is called once per frame
	void Update () {
        startMarker.position = new Vector2(transform.position.x, transform.position.y);
        endMarker.position = new Vector2(transform.position.x, diver.transform.position.y);
        transform.position = Vector2.Lerp(startMarker.position, endMarker.position, Time.deltaTime);

        if (HealthBarScript.health == 0)
        {
            playDeath();
        }
        if (Time.time > newTime)
        {
            randomTime = Random.Range(5, 10);
            newTime = Time.unscaledTime + randomTime;
            Debug.Log("Isırık zamanı! =" + newTime);
            attack();
        }

    }

    void attack()
    {
        SoundManager.instance.RandomizeSfx(eatSound);
        playAttack();
        Invoke("playAttack", 1.3f);
        StartCoroutine(ExecuteAfterTime(0.5f));
        StartCoroutine(ExecuteAfterTime2(1.2f));
    }

    void playDeath()
    {
        animator.SetTrigger("megaDeath");
        transform.position = new Vector3(diver.transform.position.x, diver.transform.position.y - 1f,diver.transform.position.z);
    }
    void playAttack()
    {
        animator.SetTrigger("megaAttack");
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        boxCol.size = new Vector2(1f, 0.1181625f);
    }

    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        boxCol.size = new Vector2(0.09382808f, 0.1181625f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "diver 0")
        {
            Debug.Log("Megaladon Dokundu");
            HealthBarScript.health -= 1;
        }
    }
}
