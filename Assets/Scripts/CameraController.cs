using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Vector3 lastpos;
    private float distance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastpos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x - lastpos.x;
        transform.position = new Vector3(transform.position.x + distance, transform.position.y,transform.position.z);
        lastpos = player.transform.position;
    }
}
