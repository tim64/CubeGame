/// Let's draw trees with a recursive algorithm in Unity!
/// 2014 Aaron San Filippo (@AeornFlippout)
/// Let me know if you have fun with this or make any cool additions :)

//INSTRUCTIONS:
//1. attach this component to an object in your scene that the camera can see.
// (see further instructions below)


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TreeParms
{

	public float branchAngle = 15.0f; 	//how far left/right each branch goes from its parent.
	public float minScale = 0.05f; 		//what's the minimum scale of each branch?
	public float scaleChange = 0.05f; 	//how much smaller than its parent is each branch?
	public float angleRandom = 5.0f;	//how much random variation is there in the angle for each branch?
	public float scaleRandom = 0.1f;	// how much random variation is there in the scale for each branch?

	public int maxDepth = 15;			//what's the maximum "depth" of the recursive algorithm?

}

public class Tree : MonoBehaviour {


	//2. point this at a prefab that's a skinny quad or something with height of 1 unit, where the origin is at the base.
	//for instance - make an 'empty' object with a child 'quad' offset by .5 units in the Y direction.
	public GameObject trunkPrefab;


	public Vector3    trunkTopOffset = new Vector3(0, 1, 0);

	// 3. Play around with these parameters.
	//Note: careful with "scaleChange" and especially "max depth" - it can make the algorithm take a VERY long time.
	public TreeParms  parms;

	//4. push this checkbox to re-calculate in the Unity editor at runtime.
	public bool reCalulateNow = false;

	Transform root;
	List<GameObject> trunks = new List<GameObject>(1000000);

	// Use this for initialization
	void Start () {
		root = transform;
		MakeTree(root.position, 0, 1.0f, 0);
	}
	

	void Update () {
		if(reCalulateNow)
		{
			reCalulateNow = false;
			for(int i=0;i<trunks.Count; i++)
			{
				GameObject.Destroy( trunks[i]);
			}

			MakeTree(root.position, 0, 1.0f, 0);

		}
	}


	void MakeTree(Vector3 startPos, float angle, float scale, int depth)
	{
		//create a quaternion specified with euler angles where we rotate around 'x'
		Quaternion rot = Quaternion.Euler( 0, 0,angle);// *  Quaternion.AngleAxis( Random.Range(0,360), Vector3.up);

		//make a trunk
		GameObject obj = (GameObject)GameObject.Instantiate(trunkPrefab, startPos, rot);
		obj.transform.localScale = new Vector3(scale,scale,scale);

		trunks.Add(obj);

		//are we at the minimum scale?
		if(scale < parms.minScale || depth >= parms.maxDepth)
			return; 	//done with this 'leaf'!


		Vector3 topPos = startPos + (rot * (trunkTopOffset * scale));

		//make a left branch
		MakeTree( topPos, 
		         angle - parms.branchAngle + Random.Range(-parms.angleRandom, parms.angleRandom) , 
		         scale - (parms.scaleChange + Random.Range(0, parms.scaleRandom)),
		         depth+1);

		//make a right branch
		MakeTree( topPos, 
		         angle + parms.branchAngle+ Random.Range(-parms.angleRandom, parms.angleRandom), 
		         scale - (parms.scaleChange + Random.Range(0, parms.scaleRandom) ), 
		         depth+1);
	}
}