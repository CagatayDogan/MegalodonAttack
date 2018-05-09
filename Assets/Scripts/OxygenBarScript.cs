using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarScript : MonoBehaviour {

    Image oxygenBar;
    public GameObject gameOver, gameOverPanel;
	public AudioClip ingameMusic;
    float maxOxygen = 100f;
    public static float oxygen;

	// Use this for initialization
	void Start () {
        oxygenBar = GetComponent<Image>();
        oxygen = maxOxygen;
	}
	
	// Update is called once per frame
	void Update () {
        oxygenBar.fillAmount = oxygen / maxOxygen;
        oxygen -= 5f * Time.deltaTime;
        if (oxygen < 0)
        {
            gameOver.gameObject.SetActive(true);
			gameOverPanel.gameObject.SetActive (true);
			SoundManager.instance.PauseSingle(ingameMusic);
            Time.timeScale = 0;
        }
        else if (oxygen > 100f)
        {
            oxygen = maxOxygen;
        }
    }
}
