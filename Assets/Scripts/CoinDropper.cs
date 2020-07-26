using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinDropper : MonoBehaviour
{
    private float randomTimer;
    [SerializeField]
    private GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        //starts timer at 30 to 1 seconds ramdomly
        randomTimer = Random.Range(1f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-9.5f, 9.5f),
            6f);

        if (randomTimer >= 0)
        {
            //Debug.Log(randomTimer.ToString());
            randomTimer -= Time.deltaTime;
        }
        else
        {
            Instantiate(coin);
            coin.transform.position = spawnPosition;
            randomTimer = Random.Range(1f, 30f);
        }
    }
}
