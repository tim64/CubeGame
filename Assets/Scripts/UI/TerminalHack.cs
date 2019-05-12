using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 

public class TerminalHack:MonoBehaviour 
                {

    
    public Terminal terminal; 
    public Image detector; 
    
    private Text textfield; 
    private bool endupdate; 
    private int charIndex = 0; 
    private string codetext = "\n\n#include <stdio.h>\n\nmain()\n{\n\tprintf(hello, world!);\n}"; 
    private string startText; 

    void Start ()
                    {
        textfield = GetComponent < Text > (); 
        startText = textfield.text; 

    }

    // Update is called once per frame
    void Update()
    {
        if ( ! endupdate)
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
            Deactivate(); 
        }
    }

    private void Deactivate()
    {
        terminal.DeactivateField(); 
        textfield.text = startText; 
        endupdate = false; 
        charIndex = 0; 
        detector.color = Color.red; 
        transform.parent.gameObject.SetActive(false); 
    }
}
