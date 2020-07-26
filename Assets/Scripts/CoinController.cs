using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    //Timer for the life of the coin in seconds
    private float lifeTimer;
    private float MAX_LIFESPAN = 15f;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = MAX_LIFESPAN;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        //Debug.Log(lifeTimer.ToString());
        if(lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
