using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGenerator : MonoBehaviour {

    SpriteRenderer current;
    SpriteRenderer shadow;

    public float shadowScalefactor = 0.2f;

    void Start () {
        current = GetComponent<SpriteRenderer>();
        GameObject shadowObj = new GameObject();

        Vector3 currentScale = current.transform.localScale;

            shadowObj.name = "Shadow";
            shadowObj.transform.parent = transform;
        shadowObj.transform.localPosition = new Vector3(0, 0, 0);
        shadowObj.transform.localScale = new Vector3(currentScale.x + shadowScalefactor, currentScale.y + shadowScalefactor, currentScale.z);

        SpriteRenderer shadow = shadowObj.AddComponent<SpriteRenderer>();

        shadow.sprite = current.sprite;
        shadow.sortingLayerName = "Default";
        shadow.sortingOrder = -1;

        Color tmp = shadow.GetComponent<SpriteRenderer>().color;
        tmp = Color.black;
        tmp.a = 0.3f;
        shadow.GetComponent<SpriteRenderer>().color = tmp;

        //Необходим ассет SPRITE FX
       // _2dxFX_Clipping clipArea = shadowObj.AddComponent<_2dxFX_Clipping>();
       // clipArea._ClipLeft = 0.5f;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
