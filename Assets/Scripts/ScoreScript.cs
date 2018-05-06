using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static float scoreValue = 0f;
    Text score;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreValue = scoreValue + 10f * Time.deltaTime;
		score.text = "Score: " + scoreValue.ToString("F0");
        if (Time.timeScale == 0)
        {
            score.alignment = TextAnchor.LowerCenter;
            score.text = "Your Score: " + scoreValue.ToString("F0");
        }
	}
}
