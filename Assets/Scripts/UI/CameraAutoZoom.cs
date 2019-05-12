using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class CameraAutoZoom:MonoBehaviour 
    {

    // this is the time it takes the camera to go from max zoom to min zoom.
    public float scaleTime; 
    public float maxSize; // max zoom out size of our camera
public float minSize; // min zoom out size of our camera
public float minSpeed; // min speed the camera cares about.. this or slower = min Zoomout
public float maxSpeed; // the max speed our camera careas about.. this or faster = max zoomout
public GameObject Player; 

    private PlayerControl playerScript; 
    private Camera cam; 
    private bool isScaling; 
    private float currentSize; 
    private float targetSize; 
    private float speedRange; // this is used for lerp function
private float sizeDelta; // how long it takes to change the camera size 1 unit;


    void Start()
    {
        playerScript = Player.GetComponent < PlayerControl > (); 
        cam = GetComponent < Camera > (); 

        isScaling = false; 
        currentSize = maxSize; 
        speedRange = maxSpeed - minSpeed; 
        sizeDelta = (maxSize - minSize)/scaleTime; 

    }

    void Update()
    {
        // if we are currently scaling don't check movement
        if (isScaling)
            return;
        CheckSize(playerScript.Speed);
    }

    void CheckSize(float speed)
    {
        // clamp our speed between min and max
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        // normalize the speed between a value of 0 and 1 for lerp
        speed = speed - minSpeed;  // this sets our speed in the range from 0->speedRange
        speed /= speedRange;  // now speed is Normalized between 0->1

        targetSize = Mathf.Lerp(minSize, maxSize, speed);
        if (targetSize != currentSize)
            StartCoroutine(ChangeSize());
    }

    IEnumerator ChangeSize()
    {

        bool zoomOut = false;
        if (currentSize < targetSize)
            zoomOut = true;
        if (currentSize > targetSize)
            zoomOut = false;
        isScaling = true;
        while (currentSize != targetSize)
        {
            if (zoomOut)
            {
                currentSize += sizeDelta * Time.deltaTime;
                if (currentSize > targetSize)
                    currentSize = targetSize;
            }
            else
            {
                currentSize -= sizeDelta * Time.deltaTime;
                if (currentSize < targetSize)
                    currentSize = targetSize;
            }
            cam.orthographicSize = currentSize;
            yield return null;
        }
        isScaling = false;
    }
}
