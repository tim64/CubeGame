using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class SpawnPointSystem : MonoBehaviour {

    public GameObject characterPrefab;
	public PortalEffect portal;
    public float delaySpawn;
    public CinemachineVirtualCamera virtualCam;


    public enum AnimationType
    {
        NONE, SCALE, TWIST, ALPHA, COLOR
    }

    [SerializeField]
    private AnimationType appearType;
    public float tweenTime = 0.5f;
    public Color startColor = Color.white;
    public float startAngle = 45;

    private int currentTwinId;
    private LTDescr descr;
    private GameObject character;

    
    public AnimationType AppearType
    {
        get
        {
            return appearType;
        }

        set
        {
            appearType = value;
            switch (appearType)
            {
                case AnimationType.NONE:
                    break;
                case AnimationType.SCALE: 
                    currentTwinId = LeanTween.scale(character, Vector2.one, tweenTime).setFrom(Vector2.zero).id;
                    descr = LeanTween.descr(currentTwinId);
                    break;
                case AnimationType.TWIST:
                    currentTwinId = LeanTween.rotateZ(character, 0, tweenTime).setEase(LeanTweenType.linear).setFrom(startAngle).id;
                    descr = LeanTween.descr(currentTwinId);
                    break;
                case AnimationType.ALPHA:
                    currentTwinId = LeanTween.alpha(character, 1, tweenTime).setFrom(0).id;
                    break;
                case AnimationType.COLOR:
                    character.GetComponent<SpriteRenderer>().color = Color.green;
                    currentTwinId = LeanTween.color(character, Color.white, tweenTime).id;
                    break;
                default:
                    break;
            }
        }
    }

    void Start ()
    {
		portal.TwistOpenTween ();
		LeanTween.delayedCall (delaySpawn, delegate() {
			
			Vector2 position = transform.position;
			character = Instantiate (characterPrefab, position, Quaternion.identity);
			//уменьшаем персонажа перед анимацией скейла
			if (appearType == AnimationType.SCALE) character.transform.localScale = Vector2.zero;
            virtualCam.Follow = character.transform;
            //Camera.main.GetComponent<Camera2DFollow> ().target = character.transform;
            // Camera.main.GetComponent<CameraAutoZoom>().Player = character;
            //Camera.main.GetComponent<CameraAutoZoom>().enabled = true;

            AppearType = AppearType; //Setting force call

			//Tween
			if (descr != null) {
				descr.setOnComplete (delegate() {
					portal.CloseTween ();
					//TODO Сделать более нормальное удаление материала прыгучести
					LeanTween.delayedCall(1f, delegate() {
						character.GetComponent<BoxCollider2D>().sharedMaterial = null;
					});

				});
			}

		});

       

    }
}
