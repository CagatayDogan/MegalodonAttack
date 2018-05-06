using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	#region Singleton MenuManager

	private static MenuManager _instance;

	public GameObject startPanel;

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
		}
	}

	public void StartButton()
	{
		Debug.Log ("Start Button called");
		startPanel.gameObject.SetActive (false);
		Time.timeScale = 1;

	}
		
}
