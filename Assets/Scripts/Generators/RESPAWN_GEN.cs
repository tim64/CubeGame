using UnityEngine;

public class RESPAWN_GEN : MonoBehaviour
{
    public GameObject respawnPillarPrefab;

    void Start()
    {
        GameObject newRespawn = Instantiate(respawnPillarPrefab, transform.position, Quaternion.identity);
        newRespawn.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}