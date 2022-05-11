using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferGenerator : MonoBehaviour
{
    public GameObject ground;
    public int maxBuffer;
    private List<GameObject> bufferList;
    // Start is called before the first frame update
    void Start()
    {
        bufferList = new List<GameObject>();
        for (int i = 0; i < maxBuffer; i++)
        {
            GameObject obj = Instantiate(ground);
            obj.SetActive(false);
            bufferList.Add(obj);
        }
    }

    public GameObject GetPooledObj()
    {
        foreach(GameObject gameObject in bufferList)
        {
            if (!gameObject.activeInHierarchy)
            {
                return gameObject;
            }
        }
        GameObject gameobj = Instantiate(ground);
        gameobj.SetActive(false);
        bufferList.Add(gameobj);
        return gameobj;
    }
}
