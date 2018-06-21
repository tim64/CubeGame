using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayerTeleport : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartTeleport (Transform target) {
		transform.position = target.position;
	}
}
