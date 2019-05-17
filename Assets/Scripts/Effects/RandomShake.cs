using UnityEngine;

public class RandomShake : MonoBehaviour
{

    public float shakeRadius = 0.1f;
    public float randomPeriod = 0.1f;
    public float centerDistance = 0.1f;
    public bool isMovingObject = false;

    [Header("Offsets")]
    public float xOffset = 0;
    public float yOffset = 0;

    private Vector3 startPosition;
    private Vector3 localPosition;
    private Vector3 worldPosition;

    void Start()
    {
        startPosition = transform.localPosition;

        LeanTween.delayedCall(randomPeriod, Shake).setLoopClamp();
       	LeanTween.delayedCall(0.5f, CheckRadius).setLoopClamp();
    }

    private void CheckRadius()
    {
			if (Vector3.Distance(startPosition, transform.localPosition) > centerDistance)
					transform.localPosition = startPosition;
    }

    void Shake()
    {
			if (isMovingObject)
            transform.localPosition = transform.position + (Vector3)Random.insideUnitCircle * shakeRadius;
        else
            transform.localPosition = transform.localPosition + (Vector3)Random.insideUnitCircle * shakeRadius;
						
        transform.localPosition = new Vector3(transform.localPosition.x, startPosition.y, 0);
    }

}
