using UnityEngine;

public class LevelLoadTrigger : MonoBehaviour
{
    public LevelData[] nextLevels;

    private bool activate = false;

    void Start() => GetComponent<SpriteRenderer>().enabled = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !activate)
        {
            activate = true;
            LevelController.instance.LoadLevel(nextLevels);
            Destroy(gameObject);
        }
    }
}
