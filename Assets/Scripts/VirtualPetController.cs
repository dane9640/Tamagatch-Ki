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

    //The Max Sleep Value can be set in editor
    [SerializeField]
    private float MAX_SLEEP;

    //Decrease Rate for Sleep can be set in editor
    [SerializeField]
    private float SLEEP_DECREASE_RATE;

    //Decrease Rate for Hunger
    [SerializeField]
    private float HUNGER_DECREASE_RATE;

    //Decrease Rate for Cleanliness
    [SerializeField]
    private float CLEANLINESS_DECREASE_RATE;

    //pet's animation controller
    private Animator anim;


    //Hunger stat
    private float Hunger;

    //Clean Stat
    private float Cleanliness;

    //Sleep Stat
    private float SleepStat;

    //Whether Pet is Alive or not
    private bool Alive;

    //Whether Pet is tired or not
    private bool isTired;

    //wether the pet is sleeping or not
    private bool isSleeping;

    //Age of Pet
    private int Age;
    //How long it takes to age up in seconds
    private float AgeUpTimer = 120f;

    //Poop Object that Spawns when cleanliness get to a certain level
    [SerializeField]
    private GameObject poop;

    //whether the pet has pooped or not since the last cleaning
    private bool hasPooped;

    //The poop object that is set to destroy when cleaned
    private GameObject poopToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        SleepStat = MAX_SLEEP;
        isSleeping = false;
        Hunger = MAX_HUNGER;
        Cleanliness = MAX_CLEANLINESS;
        Alive = true;
        isTired = false;
        hasPooped = false;
        Age = 1;

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseHunger();
        DecreaseCleanliness();
        DecreaseSleep();

        if (isSleeping)
        {
            IncreaseSleep();
        }
        anim.SetBool("isSleeping", isSleeping);

        if (AgeUpTimer > 0)
        {
            AgeUpTimer -= Time.deltaTime;
        }else if (AgeUpTimer <= 0)
        {
            AgeUp();
            AgeUpTimer = 120f;
        }

        CheckAlive();
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

    public void SetSleepStat(float newValue)
    {
        SleepStat = newValue;
    }

    public float GetSleepStat()
    {
        return SleepStat;
    }

    public bool GetIsTired()
    {
        return isTired;
    }

    public void SetIsTired(bool value)
    {
        isTired = value;
    }

    public bool GetIsSleeping()
    {
        return isSleeping;
    }

    public void SetIsSleeping(bool value)
    {
        isSleeping = value;
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

    //Decreases Sleep by the Decrease Rate
    //Once it reaches 20 the pet gets tired.
    //TODO When Sleep Reaches 0 happiness subtracted by one
    public void DecreaseSleep()
    {
        SleepStat -= Time.deltaTime * SLEEP_DECREASE_RATE;

        if(SleepStat <= 20f)
        {
            isTired = true;
        }

    }

    //Increases Sleep stat until it reaches max value
    public void IncreaseSleep()
    {
        bool sleepyTime = true;
        if(sleepyTime)
        {
            SleepStat += 3 * Time.deltaTime;
            if (SleepStat >= MAX_SLEEP)
            { 
                isSleeping = false;
                isTired = false;

                //anim.SetBool("isSleeping", isSleeping);
            }
        }

    }

    //Feeds The Pet at the expense of Cleanliness
    public void Feed()
    {
        Hunger = MAX_HUNGER;
        Cleanliness = Cleanliness * .70f;
        anim.SetTrigger("EatButtonPressed");
    }

    //Cleans the Pet at the expense of Hunger
    public void Clean()
    {
        Cleanliness = MAX_CLEANLINESS;
        Hunger = Hunger * .90f;
        hasPooped = false;
        Destroy(poopToDestroy);
        anim.SetTrigger("CleanButtonPressed");
    }

    //Makes the Pet Sleep when called
    //Set is tired to false when sleep reaches max again
    public void Sleep()
    {
        isSleeping = true;
        anim.SetBool("isSleeping", isSleeping);

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

    //Increases the age by one
    public void AgeUp()
    {
        Age++;

    }


}
