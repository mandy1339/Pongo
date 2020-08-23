using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerProjectileSelection : MonoBehaviour
{
    [SerializeField] private GameObject projectileButtons;
    [SerializeField] private TMP_Text text_WannaBuy;
    [SerializeField] private Button button_OKBuy;
    [SerializeField] private TMP_Text text_CoinBalance;
    private int _itemToBuyCost;
    private string _itemToBuy;
    [SerializeField] private TMP_Text cost1;
    [SerializeField] private TMP_Text cost2;
    [SerializeField] private TMP_Text cost3;
    [SerializeField] private TMP_Text cost4;
    [SerializeField] private TMP_Text cost5;
    [SerializeField] private TMP_Text cost6;
    [SerializeField] private TMP_Text cost7;
    [SerializeField] private TMP_Text cost8;
    private GameObject ui_WannaBuyCanvas;
    private GameObject lockImage1;
    private GameObject checkImage1;
    private GameObject lockImage2;
    private GameObject checkImage2;
    private GameObject lockImage3;
    private GameObject checkImage3;
    private GameObject lockImage4;
    private GameObject checkImage4;
    private GameObject lockImage5;
    private GameObject checkImage5;
    private GameObject lockImage6;
    private GameObject checkImage6;
    private GameObject lockImage7;
    private GameObject checkImage7;
    private GameObject lockImage8;
    private GameObject checkImage8;
    

    // Start is called before the first frame update
    void Start()
    {
        // Display players coin balance
        text_CoinBalance.text = PongoCoinManager.GetBalance().ToString();

        _itemToBuyCost = 0;     // variable used later to know cost of clicked item
        ui_WannaBuyCanvas = GameObject.FindGameObjectWithTag("buy_ui_tag").transform.GetChild(0).gameObject;
        lockImage1  = GameObject.Find("LockImage1");
        checkImage1 = GameObject.Find("CheckImage1");
        lockImage2  = GameObject.Find("LockImage2");
        checkImage2 = GameObject.Find("CheckImage2");
        lockImage3  = GameObject.Find("LockImage3");
        checkImage3 = GameObject.Find("CheckImage3");
        lockImage4  = GameObject.Find("LockImage4");
        checkImage4 = GameObject.Find("CheckImage4");
        lockImage5  = GameObject.Find("LockImage5");
        checkImage5 = GameObject.Find("CheckImage5");
        lockImage6  = GameObject.Find("LockImage6");
        checkImage6 = GameObject.Find("CheckImage6");
        lockImage7  = GameObject.Find("LockImage7");
        checkImage7 = GameObject.Find("CheckImage7");
        lockImage8  = GameObject.Find("LockImage8");
        checkImage8 = GameObject.Find("CheckImage8");
        
        
        
        
        // hide all the check images first
        checkImage1.SetActive(false);
        checkImage2.SetActive(false);
        checkImage3.SetActive(false);
        checkImage4.SetActive(false);
        checkImage5.SetActive(false);
        checkImage6.SetActive(false);
        checkImage7.SetActive(false);
        checkImage8.SetActive(false);
        // and then show it only on the active projectile
        string chosenProjectile = PlayerPrefs.GetString("ChosenProjectile", "none");
        switch (chosenProjectile)
        {
            case "Ball01": checkImage1.SetActive(true); break;
            case "Ball02": checkImage2.SetActive(true); break;
            case "Ball03": checkImage3.SetActive(true); break;
            case "Ball04": checkImage4.SetActive(true); break;
            case "Football01": checkImage5.SetActive(true); break;
            //case "Triangle01": checkImage6.SetActive(true); break;
            case "Arrow": checkImage6.SetActive(true); break;
            case "Triangle02": checkImage7.SetActive(true); break;
            //case "Triangle03": checkImage8.SetActive(true); break;
            case "Rocket": checkImage8.SetActive(true); break;
            default: checkImage1.SetActive(true); break;
        }


        // Unlock the balls owned by the player
        lockImage1.SetActive(false);        
        lockImage2.SetActive(false);
        lockImage3.SetActive(!InventoryManager.DoesPlayerOwnInventoryItem("Ball03"));
        lockImage4.SetActive(!InventoryManager.DoesPlayerOwnInventoryItem("Ball04"));
        lockImage5.SetActive(!InventoryManager.DoesPlayerOwnInventoryItem("Football01"));
        lockImage6.SetActive(!InventoryManager.DoesPlayerOwnInventoryItem("Arrow"));
        lockImage7.SetActive(!InventoryManager.DoesPlayerOwnInventoryItem("Triangle02"));
        lockImage8.SetActive(!InventoryManager.DoesPlayerOwnInventoryItem("Rocket"));
        


        SetItemCostText();

    }

    private void SetItemCostText()
    {
        if (lockImage2.activeSelf) {cost2.text = InventoryManager.GetItemCost("Ball02").ToString(); }
        if (lockImage3.activeSelf) {cost3.text = InventoryManager.GetItemCost("Ball03").ToString();    }
        if (lockImage4.activeSelf) {cost4.text = InventoryManager.GetItemCost("Ball04").ToString();    }
        if (lockImage5.activeSelf) {cost5.text = InventoryManager.GetItemCost("Football01").ToString();}
        if (lockImage6.activeSelf) {cost6.text = InventoryManager.GetItemCost("Arrow").ToString();}
        if (lockImage7.activeSelf) {cost7.text = InventoryManager.GetItemCost("Triangle02").ToString();}
        if (lockImage8.activeSelf) {cost8.text = InventoryManager.GetItemCost("Rocket").ToString(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton01()
    {
        PlayerPrefs.SetString("ChosenProjectile", "Ball01");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnClickButton02()
    {
        if(lockImage2.activeSelf)
        {
            PromptBuy("Ball02");
        }
        else
        {
            PlayerPrefs.SetString("ChosenProjectile", "Ball02");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }public void OnClickButton03()
    {
        if (lockImage3.activeSelf)
        {
            PromptBuy("Ball03");
        }
        else
        {
            PlayerPrefs.SetString("ChosenProjectile", "Ball03");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }public void OnClickButton04()
    {
        if (lockImage4.activeSelf)
        {
            PromptBuy("Ball04");
        }
        else
        {
            PlayerPrefs.SetString("ChosenProjectile", "Ball04");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }public void OnClickButton05()
    {
        if (lockImage5.activeSelf)
        {
            PromptBuy("Football01");
        }
        else
        {
            PlayerPrefs.SetString("ChosenProjectile", "Football01");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void OnClickButton06()
    {
        if (lockImage6.activeSelf)
        {
            PromptBuy("Arrow");
        }
        else
        {
            PlayerPrefs.SetString("ChosenProjectile", "Arrow");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void OnClickButton07()
    {
        if (lockImage7.activeSelf)
        {
            PromptBuy("Triangle02");
        }
        else
        {
            PlayerPrefs.SetString("ChosenProjectile", "Triangle02");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }public void OnClickButton08()
    {
        if (lockImage8.activeSelf)
        {
            PromptBuy("Rocket");
        }
        else
        {
            PlayerPrefs.SetString("ChosenProjectile", "Rocket");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private void PromptBuy(string itemToBuy)
    {
        _itemToBuyCost = 0;
        _itemToBuy = "";
        _itemToBuy = itemToBuy;
        ui_WannaBuyCanvas.SetActive(true);
        _itemToBuyCost = InventoryManager.GetItemCost(itemToBuy);
        if(_itemToBuyCost > PongoCoinManager.GetBalance())
        {
            text_WannaBuy.text = $"You Can't Afford This Item?";
            button_OKBuy.gameObject.SetActive(false);
        }
        else
        {
            text_WannaBuy.text = $"Do You Want To Buy This Item For {_itemToBuyCost} PongoCoins?";
            button_OKBuy.gameObject.SetActive(true);
        }
        

        // disable buttons while on confirmation form
        Button[] buttons = projectileButtons.transform.GetComponentsInChildren<Button>();
        foreach (Button b in buttons)
        {
            b.enabled = false;
        }
    }


    public void OnClickYesBuyPrompt()
    {
        ui_WannaBuyCanvas.SetActive(false);

        // do transaction
        PongoCoinManager.Spend(_itemToBuyCost);
        InventoryManager.AddToInventory(_itemToBuy);

        // update displayed balance
        text_CoinBalance.text = PongoCoinManager.GetBalance().ToString();

        // re-enable buttons after exiting confirmation
        Button[] buttons = projectileButtons.transform.GetComponentsInChildren<Button>();
        foreach (Button b in buttons)
        {
            b.enabled = true;
        }
        // refresh to show the current selection
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickNoBuyPrompt()
    {
        ui_WannaBuyCanvas.SetActive(false);

        // re-enable buttons after exiting confirmation
        Button[] buttons = projectileButtons.transform.GetComponentsInChildren<Button>();
        foreach (Button b in buttons)
        {
            b.enabled = true;
        }
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("LevelSelectionScreen");
    }
}
