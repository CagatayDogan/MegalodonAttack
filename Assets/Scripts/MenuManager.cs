using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	#region Singleton MenuManager

	private static MenuManager _instance;

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

	public void StartButton()
	{
		Debug.Log ("Start Button called");


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
