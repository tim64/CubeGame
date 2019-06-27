using UnityEngine;

public class LevelUnLoadTrigger : MonoBehaviour
{
    public GameObject[] nextLevels;

    private bool activate = false;

    void Start() => GetComponent<SpriteRenderer>().enabled = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !activate)
        {
            activate = true;
            LevelController.instance.UnLoadLevel(nextLevels);
            Destroy(gameObject);
        }
    }
}
