using UnityEngine;

public class SceneLoadTrigger : MonoBehaviour
{
    [Scene]
    public string[] newScenes;
    public GameObject nextLevel;

    private bool activate = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !activate)
        {
            activate = true;
            GameObject coin = Instantiate(nextLevel, Vector2.zero, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
    }
}
