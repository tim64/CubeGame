using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;

    public Transform levelContainer;
    public GameObject firstLevelPrefab;

    void Awake()
    {
        if (instance == null) 
        { 
            instance = this; 
	    } 
        else if(instance == this)
        {
	        Destroy(gameObject);
	    }
    }

    public void LoadFirstLevel()
    {
        LevelData data = firstLevelPrefab.GetComponent<LevelData>();
        GameObject firstLevel = Instantiate(firstLevelPrefab, data.defaultPosition, Quaternion.identity);
        LevelOrginezer(firstLevel, data);
    }

    public void LoadLevel(LevelData[] nextLevels)
    {
        for (int i = 0; i < nextLevels.Length; i++)
        {
            GameObject newLevel = Instantiate(nextLevels[i].gameObject, nextLevels[i].defaultPosition, Quaternion.identity);
            LevelOrginezer(newLevel, nextLevels[i]);
        }
    }

    public void LoadLevel(LevelData nextLevel)
    {
        GameObject newLevel = Instantiate(nextLevel.gameObject, nextLevel.defaultPosition, Quaternion.identity);
        LevelOrginezer(newLevel, nextLevel);
    }

    public void UnLoadLevel(GameObject[] oldLevels)
    {
        for (int i = 0; i < oldLevels.Length; i++)
        {
            Destroy(oldLevels[i]);
        }
    }

    public void UnLoadLevel(GameObject oldLevel)
    {
        Destroy(oldLevel);
    }

    void LevelOrginezer(GameObject newLevel, LevelData nextLevel)
    {
        newLevel.name = nextLevel.name;
        newLevel.transform.parent = levelContainer;
    }
}
