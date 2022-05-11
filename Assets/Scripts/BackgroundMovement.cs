using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer back;
    public float back_speed;
    void Start()
    {
        back = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        back.material.mainTextureOffset += new Vector2(back_speed * Time.deltaTime, 0);
    }
}
