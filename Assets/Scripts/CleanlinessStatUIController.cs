using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CleanlinessStatUIController : MonoBehaviour
{
    //The Pet we are getting the stat from, set in editor
    [SerializeField]
    private VirtualPetController pet;

    //The Stat Text Object to be displayed
    private Text StatText;

    // Start is called before the first frame update
    void Start()
    {
        StatText = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        StatText.text = "Cleanliness: " + pet.GetCleanlinessInt().ToString();
    }
}
