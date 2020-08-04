using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualPetController : MonoBehaviour
{
    //The max hunger value, Can be set in editor.
    [SerializeField]
    private float MAX_HUNGER;

    //The max cleanliness value, Can e set in editor.
    [SerializeField]
    private float MAX_CLEANLINESS;

    //Decrease Rate for Hunger
    [SerializeField]
    private float HUNGER_DECREASE_RATE;

    //Decrease Rate for Cleanliness
    [SerializeField]
    private float CLEANLINESS_DECREASE_RATE;

    //Hunger stat
    private float Hunger;

    //Clean Stat
    private float Cleanliness;

    //Whether Pet is Alive or not
    private bool Alive;

    //Whether Pet is tired or not
    private bool isTired;

    //Age of Pet
    private int Age;
    //How long it takes to age up in seconds
    private float AgeUpTimer = 120f;

    //Poop Object that Spawns when cleanliness get to a certain level
    [SerializeField]
    private GameObject poop;

    private bool hasPooped;

    private GameObject poopToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
        Hunger = MAX_HUNGER;
        Cleanliness = MAX_CLEANLINESS;
        Alive = true;
        isTired = false;
        hasPooped = false;
        Age = 1;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseHunger();
        DecreaseCleanliness();

        if (AgeUpTimer > 0)
        {
            AgeUpTimer -= Time.deltaTime;
        }else if (AgeUpTimer <= 0)
        {
            AgeUp();
            AgeUpTimer = 120f;
        }

        CheckAlive();
        Debug.Log(Age.ToString());
    }

    //Getter and Setter Functions-------------------------|

    public float GetHunger()
    {
        return Hunger;
    }

    public int GetHungerInt()
    {
        return (int)Hunger;
    }

    public void SetHunger(float newValue)
    {
        Hunger = newValue;
    }

    public float GetCleanliness()
    {
        return Cleanliness;
    }

    public int GetCleanlinessInt()
    {
        return (int)Cleanliness;
    }

    public void SetCleanliness(float newValue)
    {
        Cleanliness = newValue;
    }

    public bool GetAlive()
    {
        return Alive;
    }

    public void SetAlive(bool newValue)
    {
        Alive = newValue;
    }

    //End Getter and Setter Functions-------------------|

    //Decreases Hunger by the decrease rate
    //the rate doubles if the cleanliness gets to 0
    private void DecreaseHunger()
    {

        Hunger -= Time.deltaTime * HUNGER_DECREASE_RATE;

        if(Cleanliness <= 0f)
        {
            Hunger -= Time.deltaTime * (2 * HUNGER_DECREASE_RATE);
        }

    }

    //Decreases Cleanliness Stat by the Decrease Rate
    private void DecreaseCleanliness()
    {
        Cleanliness -= Time.deltaTime * CLEANLINESS_DECREASE_RATE;
        if (Cleanliness <= 0f && !hasPooped)
        {
            Vector3 spawnPos = new Vector3(gameObject.transform.position.x,
                gameObject.transform.position.y - .2f, 0f);
            poopToDestroy = Instantiate(poop, spawnPos, new Quaternion());
            hasPooped = true;
        }
    }

    //Feeds The Pet at the expense of Cleanliness
    public void Feed()
    {
        Hunger = MAX_HUNGER;
        Cleanliness = Cleanliness * .70f;
    }

    //Cleans the Pet at the expense of Hunger
    public void Clean()
    {
        Cleanliness = MAX_CLEANLINESS;
        Hunger = Hunger * .90f;
        hasPooped = false;
        Destroy(poopToDestroy);
    }

    //Checks the pets stats if hunger gets to 0 the pet dies
    public void CheckAlive()
    {
        if( Hunger <= 0f )
        {
            Alive = false;
            
        }
        else
        {
            Alive = true;
        }
    }

    public void AgeUp()
    {
        Age++;

    }

}
