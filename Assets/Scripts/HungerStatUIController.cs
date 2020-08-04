using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerStatUIController : MonoBehaviour
{
    //The Pet who's stats will be displayed on the UI , Set in Editor
    [SerializeField]
    private VirtualPetController pet;

    [SerializeField]
    private Sprite fullImage;
    [SerializeField]
    private Sprite hungryImage;

    private Image imageUI;

    //The Text object that will contain the Stat to be displayed
    private Text StatText;

    // Start is called before the first frame update
    void Start()
    {
        StatText = GetComponent<Text>();
        try
        {
            imageUI = GetComponent<Image>();
        }
        catch
        {
            
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //StatText.text = "Hunger: " + pet.GetHungerInt().ToString();

        if (pet.GetHungerInt() <= 25)
        {
            imageUI.sprite = hungryImage;
        }
        else
            imageUI.sprite = fullImage;
    }
}
