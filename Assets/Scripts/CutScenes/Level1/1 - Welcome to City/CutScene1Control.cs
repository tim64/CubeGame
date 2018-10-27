using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene1Control : MonoBehaviour {

	public PlayerControl player;
	public GameObject timeline;
	public GameObject npc;
	public ForceFieldControl fieldControl;

	bool activeCutScene = false;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		LeanTween.delayedCall(2f, () => {player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();});
		
	}
	
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (!activeCutScene)
		{
			player.forceControlOff = true;
			timeline.SetActive(true);
			activeCutScene = true;	
		}

	}

	public void EndScene()
	{
		fieldControl.DeactivateField();
		player.forceControlOff = false;
	}
}
