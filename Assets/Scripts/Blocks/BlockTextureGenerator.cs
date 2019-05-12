using UnityEngine; 
using System.Collections; 

public class BlockTextureGenerator:MonoBehaviour 
{
	[ExecuteInEditMode]

	[Header ("Graphic Layers")]
	public SpriteRenderer baseLayer; 
	public SpriteRenderer grassLayer; 
	public SpriteRenderer shadowLayer; 
	public SpriteRenderer decoLayer; 


	void Start ()
	{
		CreateTexture (); 
	}
	
	public void CreateTexture()
	{
		baseLayer.sprite = Resources.Load < Sprite > ("Art/Blocks/TestLayers/base" + Random.Range(1, 4).ToString()); 
		grassLayer.sprite = Resources.Load < Sprite > ("Art/Blocks/TestLayers/grass" + Random.Range(1, 4).ToString()); 
		shadowLayer.sprite = Resources.Load < Sprite > ("Art/Blocks/TestLayers/downShadow" + Random.Range(1, 4).ToString()); 
		decoLayer.sprite = Resources.Load < Sprite > ("Art/Blocks/TestLayers/Deco" + Random.Range (1, 4).ToString ()); 
	}
}
