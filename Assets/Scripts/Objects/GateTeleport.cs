using System;
using UnityEditor;
using UnityEngine;

public class GateTeleport : MonoBehaviour
{

    public Transform teleportPoint;
    public AudioSource teleportSound;
    public ParticleSystem teleportParticleFX;

    private bool activate = false;

    void Start()
    {
        if (teleportPoint == null)
        {
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !activate)
        {
            activate = true;

            MoveTeleportFX(coll);
            MovePlayer(coll);
        }
    }

    private void MovePlayer(Collider2D coll)
    {
        LeanTween.rotate(coll.gameObject, Vector3.zero, 3);
        LeanTween.move(coll.gameObject, transform.position, 3).onComplete = () => TeleportAction(coll);
    }

    private void MoveTeleportFX(Collider2D coll)
    {
        teleportParticleFX.transform.parent = coll.transform;
        teleportParticleFX.transform.localScale = Vector3.one;
        teleportParticleFX.transform.localPosition = Vector3.zero;
        teleportParticleFX.gameObject.SetActive(true);
        teleportParticleFX.Play();
    }

    private void TeleportAction(Collider2D coll)
    {
        GameObject player = coll.gameObject;
        Rigidbody2D playerRig = player.GetComponent<Rigidbody2D>();

        Camera.main.transform.position = teleportPoint.position;
        playerRig.Sleep();

        player.transform.position = teleportPoint.position;
        LeanTween.delayedCall(0.2f, () => EndTeleportation(playerRig));
    }

    public void MoveCameraToNextPort()
    {
        EditorGUIUtility.PingObject(teleportPoint);
        Selection.activeGameObject = teleportPoint.gameObject;
        SceneView.lastActiveSceneView.FrameSelected();
        Selection.activeGameObject = teleportPoint.gameObject;
    }

    void EndTeleportation(Rigidbody2D playerRig)
    {
        playerRig.WakeUp();
        activate = false;
        //TODO: Добавить звук телепорта
    }

}