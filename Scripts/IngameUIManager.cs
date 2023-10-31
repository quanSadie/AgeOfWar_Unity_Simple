using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Manager in-game UI (shop, buy, etc...)
public class IngameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject ShopMenu;
    public static int gold = 10000;
    [SerializeField] private TextMeshProUGUI goldText;
    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "Gold: " + gold;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + gold;
        if (gold <= 0)
        {
            goldText.text = "Out of gold!";
            goldText.color = Color.red;
        }
    }

    public void OpenShop()
    {
        ShopMenu.SetActive(true);
    }

    public void CloseShop()
    {
        ShopMenu.SetActive(false);
    }
}
