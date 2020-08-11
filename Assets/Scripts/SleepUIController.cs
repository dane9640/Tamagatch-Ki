using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepUIController : MonoBehaviour
{
    //The Pet that the UI Gets the sleep stat from.
    [SerializeField]
    private VirtualPetController pet;

    private Image UIImage;

    //whether the Image is enabled or not
    //image should be enabled when pet is tired
    bool isEnabled;
    // Start is called before the first frame update
    void Start()
    {
        UIImage = GetComponent<Image>();
        UIImage.enabled = pet.GetIsTired();
    }

    // Update is called once per frame
    void Update()
    {
        UIImage.enabled = pet.GetIsTired();
    }
}
