using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenController : MonoBehaviour {

    public float moveSpeed;

    // Use this for initialization
    void Start () {
		
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
        }
    }
}
