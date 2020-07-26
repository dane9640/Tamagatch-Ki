using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUIController : MonoBehaviour
{
    [SerializeField]
    private PlayerInventory inventory;

    private Text StatText;

    // Start is called before the first frame update
    void Start()
    {
        StatText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       StatText.text = "Coins: " + (this.inventory.GetTotalCoins().ToString());
    }
}
