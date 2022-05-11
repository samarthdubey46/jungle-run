using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endPoint;
    void Start()
    {
        endPoint = GameObject.Find("DestroyPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < endPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
