using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFinish : MonoBehaviour {

	public GameObject up;
	public GameObject upRight;
	public GameObject right;
	public GameObject down;
	public GameObject tooth;
	public GameObject flower1;
	public GameObject flower2;
	public GameObject eye;

	public Transform playerFinishPositionFirst;
	public Transform playerFinishPositionLast;
	public ParticleSystem transformationFX;

	bool activate = false;

	GameObject platform;


	void Start()
	{
		platform = transform.parent.gameObject;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !activate)
        {
			activate = true;

            GameObject player = other.gameObject;
			LeanTween.scale(transformationFX.gameObject, Vector3.one * 0.3f, 1);
			transformationFX.startSize = 1;

			ResetPlayer(player);

			LeanTween.move(player, playerFinishPositionFirst.position, 1);
            
            LeanTween.moveLocalY(flower1, -10, 3).setEase(LeanTweenType.easeInBack);
            LeanTween.moveLocalY(flower2, -10, 2).setEase(LeanTweenType.easeInBack).setDelay(0.5f);

			LeanTween.alpha(tooth, 0, 1).setDestroyOnComplete(true); 
			LeanTween.alpha(eye , 0, 0.5f).setDestroyOnComplete(true);

            LeanTween.rotateZ(upRight, -90, 1).setDelay(2);
            LeanTween.rotateZ(right, -270, 1).setDelay(3);

            LeanTween.moveLocalY(upRight, down.transform.localPosition.y, 1);

			LeanTween.moveLocalY(up, -1.2f, 1).setDelay(4);
			LeanTween.moveLocalY(right, -1.2f, 1).setDelay(4);

			LeanTween.move(player, playerFinishPositionLast.position, 1).setDelay(4);
			LeanTween.scale(transformationFX.gameObject, Vector2.zero, 1).setDelay(4).setDestroyOnComplete(true);

			LeanTween.moveLocalY(platform, platform.transform.position.y + 50, 10).setDelay(5);
			LeanTween.delayedCall(5, FinishEvent).setDelay(5);
        }
    }

    private void ResetPlayer(GameObject player)
    {
        player.GetComponent<PlayerControl>().forceDisableControls = true;
        player.GetComponent<FaceControl>().Normal();
        player.transform.rotation = Quaternion.identity;
        player.transform.parent = transform;
        Destroy(player.GetComponent<Rigidbody2D>());
    }

	private void FinishEvent()
	{
		print("Finish!");
	}
}
