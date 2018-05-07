using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCaller : MonoBehaviour {

	public void StartButtonCaller()
	{
		MenuManager.Instance.StartButton ();
	}

	public void PauseButtonCaller()
	{
		MenuManager.Instance.PauseButton ();
	}

	public void ResumeButtonCaller()
	{
		MenuManager.Instance.ResumeButon ();
	}
		
}
