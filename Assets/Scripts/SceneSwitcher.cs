using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ideally can be used in every scene
public class SceneSwitcher : MonoBehaviour
{
    //pet needed to send player to death scene assigned in editor
    [SerializeField]
    VirtualPetController pet;

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (pet.GetAlive() == false)
            {
                SceneManager.LoadScene(1);
            }
        }
        catch
        {

        }
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void EndApplication()
    {
        Application.Quit();
    }
}
