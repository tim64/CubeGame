using System.Collections;
using UnityEngine;

public class FaceControl : MonoBehaviour
{

    public Sprite normal;
    public Sprite down;
    public Sprite left;
    public Sprite right;
    public Sprite scary;
    public Sprite bad;
    public Sprite jump1;
    public Sprite jump2;
    public Sprite jump3;
    public Sprite pause;

    public bool idleAnim;
    public int randomAnimationTime = 2;

    private void Start()
    {
        if (idleAnim)
        {
            StartCoroutine("StartIdleAnimation");
        }
    }

    IEnumerator StartIdleAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(randomAnimationTime);
            Normal();
        }
    }

    public void Normal()
    {
        int rand = Random.Range(1, 5);
        if (rand == 1)
            GetComponent<SpriteRenderer>().sprite = normal;
        if (rand == 2)
            GetComponent<SpriteRenderer>().sprite = right;
        if (rand == 3)
            GetComponent<SpriteRenderer>().sprite = left;
        if (rand == 4)
            GetComponent<SpriteRenderer>().sprite = down;
    }

    public void Jump()
    {
        int rand = Random.Range(1, 4);
        if (rand == 1)
            GetComponent<SpriteRenderer>().sprite = jump1;
        if (rand == 2)
            GetComponent<SpriteRenderer>().sprite = jump2;
        if (rand == 3)
            GetComponent<SpriteRenderer>().sprite = jump3;
    }

    public void Bad()
    {
        GetComponent<SpriteRenderer>().sprite = bad;
    }

    public void Pause()
    {
        GetComponent<SpriteRenderer>().sprite = pause;
    }
}