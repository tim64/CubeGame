using UnityEngine;
using System.Collections;

public class colorReplacer : MonoBehaviour {
	public Sprite originalSprite;
	[Range(0, 1)] public float scale = 1f;
	public bool recolored = true;
	public Color32[] aryOldColors;
	public Color32[] aryNewColors;
	public int tolerance;

	public int columns = 3;
	public int rows = 3;
	public int frameNumbers = 8;
	public float framesPerSecond = 8f;
	
	//the current frame to display
	private int index = 0;
	
	private SpriteRenderer myRenderer;
	private Color32[] aryPixels;
	private Texture2D originalTexture2D;
	private Texture2D recoloredTexture2D;

	void Awake () 
	{
		gameObject.transform.localScale.Set (scale, scale, scale);
		myRenderer = gameObject.GetComponent<SpriteRenderer> ();
		originalTexture2D = originalSprite.texture;

		if (recolored) 
		{
			recoloredTexture2D = new Texture2D(originalTexture2D.width, originalTexture2D.height);
			colorReplace (aryOldColors, aryNewColors);
			myRenderer.sprite = Sprite.Create (recoloredTexture2D, new Rect (0.0f, 0.0f, recoloredTexture2D.width, recoloredTexture2D.height), new Vector2 (0.5f, 0.5f));
			myRenderer.sharedMaterial.SetTexture ("_MainTex", recoloredTexture2D);
		}
		else
		{
			myRenderer.sprite = Sprite.Create (originalTexture2D, new Rect (0.0f, 0.0f, originalTexture2D.width, originalTexture2D.height), new Vector2 (0.5f, 0.5f));
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(updateTiling());
		
		//set the tile size of the texture (in UV units), based on the rows and columns
		Vector2 size = new Vector2(1f / columns, 1f / rows);
		myRenderer.sharedMaterial.SetTextureScale("_MainTex", size);
		//renderer.sharedMaterial.SetTextureScale("_MainTex", size);
	}
	
	private IEnumerator updateTiling()
	{
		while (true)
		{
			//move to the next index
			index++;
			if (index == frameNumbers)
				index = 0;
			
			//split into x and y indexes
			Vector2 offset = new Vector2((float)index / columns - (index / columns), //x index
			                             (index / columns) / (float)rows);          //y index
			
			//renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
			print ("Index: " + index);
			myRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
			yield return new WaitForSeconds(1f / framesPerSecond);
		}
		
	}
	
	private void colorReplace(Color32[] fromColors, Color32[] toColors){
		aryPixels = originalTexture2D.GetPixels32();
		
		if(aryNewColors.Length != aryOldColors.Length) throw new System.ArgumentException("aryOldColors and aryNewColors should be of equal length", "aryOldColors and aryNewColors");
		for(int i = 0; i<aryOldColors.Length ; i++)
		{
			for (int y = 0; y < originalTexture2D.height; y++) 
			{  
		        for (int x = 0; x < originalTexture2D.width; x++) 
				{  
						if(aryPixels[y*originalTexture2D.width + x].r > fromColors[i].r-tolerance && 
							aryPixels[y*originalTexture2D.width + x].r < fromColors[i].r+tolerance &&
							aryPixels[y*originalTexture2D.width + x].g > fromColors[i].g-tolerance && 
							aryPixels[y*originalTexture2D.width + x].g < fromColors[i].g+tolerance &&
							aryPixels[y*originalTexture2D.width + x].b > fromColors[i].b-tolerance &&
							aryPixels[y*originalTexture2D.width + x].b < fromColors[i].b+tolerance
							){
							aryPixels[y*originalTexture2D.width + x].r=toColors[i].r;
							aryPixels[y*originalTexture2D.width + x].g=toColors[i].g;
							aryPixels[y*originalTexture2D.width + x].b=toColors[i].b;
						}
		        }  
	    	}
		}
		/*
		originalTexture2D.SetPixels32(aryPixels);
    	originalTexture2D.Apply();*/
		
		recoloredTexture2D.SetPixels32(aryPixels);
    	recoloredTexture2D.Apply();
	}

}
