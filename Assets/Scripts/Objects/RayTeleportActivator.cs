using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayTeleportActivator : MonoBehaviour
{
    public List<Torch> torches;
    public bool activated;

    public GameObject enterTrigger;
    public GameObject ray;


    void Start()
    {
        enterTrigger.SetActive(false);
        ray.SetActive(false);
    }

    void CheckTeleportState() 
    {
        foreach (var torch in torches)
        {
            if (!torch.lightOn)
            {
                return;
            }
        }

        enterTrigger.SetActive(true);
        ray.SetActive(true);
    }

}
