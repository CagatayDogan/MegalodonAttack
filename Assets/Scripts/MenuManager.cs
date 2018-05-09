using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	#region Singleton MenuManager

	private static MenuManager _instance;

	public GameObject startPanel, pausePanel, gameOverPanel;

	public GameObject sunkedShip, diver, bubbles;

	public GameObject healthBar, oxygenBar;

	public GameObject scoreText;

	public GameObject pauseButton, musicButton;

    public GameObject megalodon;

    public AudioClip menuMusic,ingameMusic;

	public static MenuManager Instance
	{

		get
		{

			if (_instance == null)
			{
				GameObject go = new GameObject("MenuManager");
				go.AddComponent<MenuManager>();
			}

			return _instance;

		}

	}


	#endregion

	void Awake()
	{
		_instance = this;

	}

	void Start()
	{
		if (startPanel.gameObject.activeSelf == true) 
		{
			Time.timeScale = 0;
			diver.gameObject.SetActive (false);
			healthBar.gameObject.SetActive (false);
			scoreText.gameObject.SetActive (false);
			pauseButton.gameObject.SetActive (false);
			musicButton.gameObject.SetActive (false);
			pausePanel.gameObject.SetActive (false);
			gameOverPanel.gameObject.SetActive (false);
			oxygenBar.gameObject.SetActive (false);
            megalodon.gameObject.SetActive(false);
            SoundManager.instance.PlaySingle(menuMusic);
        }

	}

	public void StartButton()
	{
		Debug.Log ("Start Button called");
		startPanel.gameObject.SetActive (false);
		sunkedShip.gameObject.SetActive (false);
		bubbles.gameObject.SetActive (false);
		diver.gameObject.SetActive (true);
		healthBar.gameObject.SetActive (true);
		scoreText.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (true);
		musicButton.gameObject.SetActive (true);
		oxygenBar.gameObject.SetActive (true);
        megalodon.gameObject.SetActive(true);
		Time.timeScale = 1;
        SoundManager.instance.PlaySingle(ingameMusic);

    }

	public void PauseButton()
	{
		Debug.Log ("Pause Button called.");
		Time.timeScale = 0;
		pauseButton.gameObject.SetActive (false);
		musicButton.gameObject.SetActive (false);
		pausePanel.gameObject.SetActive (true);
        SoundManager.instance.PauseSingle(ingameMusic);
    }

	public void ResumeButon()
	{
		Debug.Log ("Resume Button called.");
		pausePanel.gameObject.SetActive (false);
		pauseButton.gameObject.SetActive (true);
		musicButton.gameObject.SetActive (true);
		Time.timeScale = 1;
        SoundManager.instance.PlaySingle(ingameMusic);
    }

	public void RestartButton()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		StartButton ();
	}

	public void MusicButton()
	{
		if (SoundManager.instance.isMusicOn) 
		{
			SoundManager.instance.PauseSingle (ingameMusic);
		}
		else
		{
			SoundManager.instance.PlaySingle (ingameMusic);
		}
	}
		
}
