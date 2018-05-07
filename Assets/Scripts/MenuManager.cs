using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	#region Singleton MenuManager

	private static MenuManager _instance;

	public GameObject startPanel;

	public GameObject pausePanel;

	public GameObject sunkedShip;

	public GameObject diver;

	public GameObject bubbles;

	public GameObject healthBar;

	public GameObject scoreText;

	public GameObject pauseButton;

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
			pausePanel.gameObject.SetActive (false);
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
		Time.timeScale = 1;

	}

	public void PauseButton()
	{
		Debug.Log ("Pause Button called.");
		Time.timeScale = 0;
		pauseButton.gameObject.SetActive (false);
		pausePanel.gameObject.SetActive (true);
	}

	public void ResumeButon()
	{
		Debug.Log ("Resume Button called.");
		pausePanel.gameObject.SetActive (false);
		pauseButton.gameObject.SetActive (true);
		Time.timeScale = 1;
	}
		
}
