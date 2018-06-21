using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGenerator : MonoBehaviour {

    SpriteRenderer current;
    SpriteRenderer shadow;

    void Start () {
        current = GetComponent<SpriteRenderer>();
        GameObject shadowObj = new GameObject();

        shadowObj.name = "Shadow";
        shadowObj.transform.parent = transform;
        shadowObj.transform.localPosition = Vector3.zero;

        SpriteRenderer shadow = shadowObj.AddComponent<SpriteRenderer>();

        shadow.sprite = current.sprite;
        shadow.sortingLayerName = current.sortingLayerName;
        shadow.sortingOrder = current.sortingOrder + 1;

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
