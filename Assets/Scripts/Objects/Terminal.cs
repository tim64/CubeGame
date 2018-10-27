using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour {

    public GameObject terminalWindow;
    public TerminalHack hackText;
    public GameObject infoText;
    public ForceFieldControl fieldControl;

    bool playerReady;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && playerReady)
        {
            terminalWindow.SetActive(true);
            hackText.terminal = this;
        }
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playerReady = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playerReady = false;
        }
    }

    public void DeactivateField()
    {
        infoText.SetActive(false);
        fieldControl.DeactivateField();
    }
}
