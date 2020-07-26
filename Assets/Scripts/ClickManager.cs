using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

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

            Debug.Log("Mouse was Clicked. No make it do something");
            Debug.Log("Mouse Position in world: " + mousePosition2D.ToString());

            //Sends a Raycast2d to the 2d mouse position in direction zero
            //not sure what that means
            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            //If the collider detects something
            if (hit.collider != null)
            {
                //if game object that was clicked has the tag coin
                if(hit.collider.gameObject.tag.ToString() == "Coin")
                {
                    CoinController coin = hit.collider.gameObject.GetComponent<CoinController>();
                    coin.SetIsClicked(true);
                    //Destroys the coin
                    Destroy(hit.collider.gameObject);
                }
                Debug.Log("Something was Clicked!");
                Debug.Log(hit.collider.gameObject.tag.ToString());
            }
            else
            {
                Debug.Log("Nothing was Clicked");
            }
        }
    }
}
