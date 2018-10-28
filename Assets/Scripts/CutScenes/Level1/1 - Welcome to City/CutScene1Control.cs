using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Playables;

public class CutScene1Control : MonoBehaviour {

	public PlayerControl player;
	public PlayableDirector director;
	public GameObject npc;
	public GameObject activeObject;
	public string typeOfObject;
	public string methodOfObject;

	private System.Type myType;
	private MethodInfo method;
	private Action myAction = ()=>{};
	private bool activeCutScene = false;


	void Start()
	{
		director.gameObject.SetActive(false);
		myType = Type.GetType(typeOfObject);
		print(myType);
		method = myType.GetMethod(methodOfObject, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

		LeanTween.delayedCall(2f, () => {player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();});
		
	}
	
	private void OnTriggerEnter2D(Collider2D coll) 
	{
		if (!activeCutScene && coll.tag == "Player")
		{
			director.gameObject.SetActive(true);
			director.stopped += OnPlayableDirectorStopped;
			activeCutScene = true;
			player.forceDisableControls = true;	
		}

	}

	void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
		{
			print(method);
			if (method != null)
			{
				myAction = (Action)Delegate.CreateDelegate(typeof(Action), activeObject, method);
			}
			player.forceDisableControls = false;
			director.stopped -= OnPlayableDirectorStopped;
		}
            
    }

}
