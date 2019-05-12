using UnityEngine; 
using System.Collections; 

public class TextCloud:MonoBehaviour 
    {

	public TextMesh textField; 

	void Start ()
        {
		textField.GetComponent < Renderer > ().sortingLayerName = "UI"; 
		textField.text = "✰❒"; 
	
	}
	
	// Update is called once per frame
	void Update ()
        {
	
	}
}
