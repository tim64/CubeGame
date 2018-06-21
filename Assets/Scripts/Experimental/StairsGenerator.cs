using UnityEngine;
using System.Collections;

public class StairsGenerator : MonoBehaviour {

	public GameObject mainBlock;

	Vector2 blockSize;
	Vector2 borderXY;
	Vector2 startPosition;

	float deltaY;

	void Start () 
	{
		

		StartGenerate ();
	}

	void StartGenerate ()
	{
		for (int i = 0; i < 128; i++) {
			startPosition = mainBlock.transform.position;
			blockSize = mainBlock.GetComponent<Renderer> ().bounds.size;
			deltaY = mainBlock.GetComponent<Renderer> ().bounds.min.y - Random.Range (-2, 2);

			borderXY = new Vector2 (startPosition.x + blockSize.x, deltaY);
			GameObject newBlock = Instantiate(mainBlock, borderXY, Quaternion.identity) as GameObject;
			newBlock.GetComponent<SpriteRenderer> ().color = GetNewColor (newBlock.GetComponent<SpriteRenderer> ().color);
			newBlock.name = "Block" + i.ToString ();
			newBlock.tag = "Ground";
			mainBlock = newBlock;
		}
	}

	Color32 GetNewColor(Color current)
	{
		
		Color32 newColor = (Color32) current;

		byte r = newColor.r;
		byte g = newColor.g;
		byte b = newColor.b;

		//blue -> green
		if (b > 160)
			return new Color32 (r, g, ByteCorrect (b - 10), 255);
		else
			//green -> yellow
			if (r < 255)
				return new Color32 (ByteCorrect (r + 10), g, b, 255);
			else
				//yellow -> red
				if (g > 160)
					return new Color32 (r, ByteCorrect (g - 10), b, 255);
					else
					//Return to blue
						return new Color32 (160, 255, 255, 255);
		
	}

	byte ByteCorrect(int currentInt)
	{
		if (currentInt > 255)
			return (byte)255;
		else
			return (byte)currentInt;

		if (currentInt < 0)
			return (byte)0;
		else
			return (byte)currentInt;
	}
}
