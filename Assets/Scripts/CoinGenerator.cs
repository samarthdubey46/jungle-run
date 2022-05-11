using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public BufferGenerator bufferObject;
    public void GenerateCoins(Vector3 position, float GroundWidth)
    {
        int ShouldGenerateCoin_Possibility = Random.Range(1, 100);

        if(ShouldGenerateCoin_Possibility < 50)
        {
            return;
        }
        int NumberOfCoins = (int)Random.Range(3f, (GroundWidth - 1f));
        for (int i = 0; i < NumberOfCoins; i++)
        {
            GameObject coin = bufferObject.GetPooledObj();
            float x = (position.x - (GroundWidth/2)) - 1;
            coin.transform.position = new Vector3(x + i, position.y + 2, 0);
            coin.SetActive(true);
        }


    }
}
