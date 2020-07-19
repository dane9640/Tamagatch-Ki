using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Whether Pet is clean or not
    private bool IsClean;


    // Start is called before the first frame update
    void Start()
    {
        Hunger = MAX_HUNGER;
        Cleanliness = MAX_CLEANLINESS;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseHunger();
        DecreaseCleanliness();
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

    //End Getter and Setter Functions-------------------|

    //Decreases Hunger by the decrease rate
    private void DecreaseHunger()
    {

        Hunger -= Time.deltaTime * HUNGER_DECREASE_RATE;

    }

    //Decreases Cleanliness Stat by the Decrease Rate
    private void DecreaseCleanliness()
    {
        Cleanliness -= Time.deltaTime * CLEANLINESS_DECREASE_RATE;
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
    }

}
