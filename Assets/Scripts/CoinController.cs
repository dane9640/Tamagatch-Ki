using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    //Players Inventory used to add coins to inventory
    [SerializeField]
    private PlayerInventory inventory;

    //Timer for the life of the coin in seconds
    private float lifeTimer;
    private float MAX_LIFESPAN = 5f;

    //Coins Collider
    CircleCollider2D collider;


    //value of the coin
    private int coinValue;

    //whether coin has been clicked or not
    private bool isClicked;

    private AudioSource destroySound;


    

    // Start is called before the first frame update
    void Start()
    {
        destroySound = GetComponent<AudioSource>();
        isClicked = false;
        lifeTimer = MAX_LIFESPAN;
        collider = GetComponent<CircleCollider2D>();
        //Sets the coin value to 1-5;
        coinValue = (int)Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
       // lifeTimer -= Time.deltaTime;
       // if(lifeTimer <= 0f)
       // {
       //     Destroy(gameObject);
       // }
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Pet")
        {
            AudioClip clip = destroySound.clip;
            Renderer rend = GetComponent<Renderer>();
            inventory.AddCoins(coinValue);
            rend.enabled = false;
            destroySound.Play();
            Destroy(gameObject, clip.length);

        }
        
    }

    public void OnDestroy()
    {
        if (isClicked)
        {
            inventory.AddCoins(coinValue);
        }
        
    }

    public void SetIsClicked(bool value)
    {
        isClicked = value;
    }

    public bool GetIsClicked()
    {
        return isClicked;
    }

    public AudioSource GetDestroySound()
    {
        return destroySound;
    }
}
