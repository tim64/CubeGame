using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void PlayGame()
	{
		Invoke ("Play", 0.1f);

	}

	void Play()
	{
		SceneManager.LoadScene("Level X", LoadSceneMode.Single);
	}


	public void PlayMultiGame()
	{
		Invoke ("StartMultiGame", 0.1f);
	}

	void StartMultiGame()
	{
		SceneManager.LoadScene("Multiplayer", LoadSceneMode.Single);
	}
}
