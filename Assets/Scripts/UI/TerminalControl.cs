using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour {

	public Sprite terminalOff;
	public Sprite terminalOn;
	public bool state = false;

	public void ChangeState()
	{
		if (state == false)
		{
			GetComponent<SpriteRenderer>().sprite = terminalOn;
			state = true;
			return;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = terminalOn;
			state = false;
			return;
		}
	}
}
