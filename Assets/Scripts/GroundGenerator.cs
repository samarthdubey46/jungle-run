using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bufferPoint;
    public Transform maxHeight;
    public Transform minHeight;

    private float miny;
    private float maxy;

    public float maxGap;
    public float minGap;

    public BufferGenerator[] bufferObjects;
    CoinGenerator coinGenerator;

    public bool IsGroundGenerating;

    private float[] groundWidths;
    void Start()
    {
        IsGroundGenerating = false;
        coinGenerator = FindObjectOfType<CoinGenerator>();  
        miny = minHeight.position.y;
        maxy = maxHeight.position.y; 
        int Len = bufferObjects.Length;
        groundWidths = new float[Len];
        for (int i = 0; i < Len; i++)
        {
            groundWidths[i] = bufferObjects[i].ground.GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGroundGenerating && (transform.position.x < bufferPoint.position.x))
        {
            int ran = Random.Range(0, (bufferObjects.Length));
            GameObject Ground = bufferObjects[ran].GetPooledObj();
            float distance = groundWidths[ran] / 2;
            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(miny, maxy);
            transform.position = new Vector3(transform.position.x + distance + gap, height, transform.position.z);
            Ground.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Ground.SetActive(true);
            coinGenerator.GenerateCoins(transform.position, groundWidths[ran]);
            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }
    }
}
