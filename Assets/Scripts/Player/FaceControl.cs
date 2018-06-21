 using UnityEngine;
using System.Collections;

public class FaceControl : MonoBehaviour {

    public Sprite[] normal_sprites;
    public Sprite[] evil_sprites;

	 Sprite normal;
	 Sprite down;
	 Sprite left;
	 Sprite right;


	 Sprite scary;
	 Sprite bad;

	 Sprite jump1;
	 Sprite jump2;
	 Sprite jump3;

     Sprite pause;

    private void Start()
    {
        ToNormal();
    }

    public void ToNormal()
    {
        normal = normal_sprites[0];
        down = normal_sprites[1];
        left = normal_sprites[2];
        right = normal_sprites[3];
        scary = normal_sprites[4];
        bad = normal_sprites[5];
        jump1 = normal_sprites[6];
        jump2 = normal_sprites[7];
        jump3 = normal_sprites[8];
    }

    public void ToEvil()
    {
        normal = evil_sprites[0];
        down = evil_sprites[1];
        left = evil_sprites[2];
        right = evil_sprites[3];
        scary = evil_sprites[4];
        bad = evil_sprites[5];
        jump1 = evil_sprites[6];
        jump2 = evil_sprites[7];
        jump3 = evil_sprites[8];
    }


    public void Normal()
	{
		int rand = Random.Range (1, 5);
		if (rand == 1)
			GetComponent<SpriteRenderer> ().sprite = normal;
		if (rand == 2)
			GetComponent<SpriteRenderer> ().sprite = right;
		if (rand == 3)
			GetComponent<SpriteRenderer> ().sprite = left;
		if (rand == 4)
			GetComponent<SpriteRenderer> ().sprite = down;
	}

	public void Jump()
	{
		int rand = Random.Range (1, 4);
		if (rand == 1)
			GetComponent<SpriteRenderer> ().sprite = jump1;
		if (rand == 2)
			GetComponent<SpriteRenderer> ().sprite = jump2;
		if (rand == 3)
			GetComponent<SpriteRenderer> ().sprite = jump3;
	}

	public void Bad()
	{
		GetComponent<SpriteRenderer> ().sprite = bad;
	}

    public void Pause( )
    {
        GetComponent<SpriteRenderer>().sprite = pause;
    }
}
