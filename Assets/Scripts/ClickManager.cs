using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private Renderer rend;
    // Update is called once per frame
    void Update()
    {
        //Checks if the Left Mouse button was clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 of the mouse position converted to world position from
            //screen position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 of the mouse position converted from vector3 getting rid of
            //z axis
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            //Sends a Raycast2d to the 2d mouse position in direction zero
            //not sure what that means
            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            //If the collider detects something
            if (hit.collider != null)
            {
                //if game object that was clicked has the tag coin
                if(hit.collider.gameObject.tag.ToString() == "Coin")
                {
                    //sets the renderer to the coin game object
                    rend = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    //gets the coins controller
                    CoinController coin = hit.collider.gameObject.GetComponent<CoinController>();
                    //gets clip for length so it's not destroyed until clip plays
                    AudioClip clip = coin.GetDestroySound().clip;
                    //plays destroy sound
                    coin.GetDestroySound().Play();
                    //lets coin know it's been clicked.
                    coin.SetIsClicked(true);
                    //hides coin until able to be destroyed.
                    rend.enabled = false;
                    //Destroys the coin after the sound effect plays
                    Destroy(hit.collider.gameObject, clip.length);
                }
            }

        }
    }
}
