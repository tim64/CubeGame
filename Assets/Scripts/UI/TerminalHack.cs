using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalHack : MonoBehaviour {

    Text textfield;
    public Terminal terminal;
    public Image detector;
    bool endupdate;
    int charIndex = 0;
    string codetext = "\n\n#include <stdio.h>\n\nmain()\n{\n\tprintf(hello, world!);\n}";

    void Start () {
        textfield = GetComponent<Text>();
        //textfield.text = codetext;

    }

    // Update is called once per frame
    void Update()
    {
        if (!endupdate)
        {
            foreach (char c in Input.inputString)
            {
                if (charIndex < codetext.Length)
                {
                    textfield.text += codetext[charIndex];
                    charIndex += 1;
                }
                else
                {
                    detector.color = Color.green;
                    endupdate = true;
                    textfield.text += "\nHack ready! Press enter!";
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && endupdate)
        {
            terminal.DeactivateField();
            transform.parent.gameObject.SetActive(false);
        }
    }
}
