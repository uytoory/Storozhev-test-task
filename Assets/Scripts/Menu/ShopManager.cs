using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _goldsText;
    [SerializeField] private ShopItemData[] _shopItemsSO;
    [SerializeField] private GameObject[] _shopPanelsGO;
    [SerializeField] private ShopPanel[] _shopPanels;
    [SerializeField] private Button[] _myPurchaseBtns;
    [SerializeField] private Button _reset;
    [SerializeField] private Button _addGold;
    [SerializeField] private Button _addCoin;

    void Start()
    {
        _reset.onClick.AddListener(ResetGame);
        _addCoin.onClick.AddListener(ButtonCoins);
        _addGold.onClick.AddListener(ButtonGolds);

        for (int i = 0; i < _shopItemsSO.Length; i++)
        {
            _shopPanelsGO[i].SetActive(true);    
                
        }
        
        _coinsText.text = "Coins: " + Progress.Instance.Coins.ToString();
        _goldsText.text = "Golds: " + Progress.Instance.Golds.ToString();
        LoadPanels();
        CheckPurchaseable();
    }


    public void CheckPurchaseable()
    {
        for (int i = 0; i < _shopItemsSO.Length; i++)
        {
            if(_shopItemsSO[i].IsBought != true)
            {
                if (Progress.Instance.Coins >= _shopItemsSO[i].Currency.Coins) 
                {
                    if(Progress.Instance.Golds >= _shopItemsSO[i].Currency.Golds)
                    {
                        _myPurchaseBtns[i].interactable = true;
                    }               
                } 
            }
            else
            {
                _myPurchaseBtns[i].interactable = false;                 
            }
        }       
    }

    public void PurchaseItem(int btnNo)
    {
        if (Progress.Instance.Coins >= _shopItemsSO[btnNo].Currency.Coins)
        {
            if( Progress.Instance.Golds >= _shopItemsSO[btnNo].Currency.Golds)
            {
            Progress.Instance.MinusCoins(_shopItemsSO[btnNo].Currency.Coins);
            Progress.Instance.MinusGolds(_shopItemsSO[btnNo].Currency.Golds);
            _goldsText.text = "Golds: " + Progress.Instance.Golds.ToString();
            _coinsText.text = "Coins: " + Progress.Instance.Coins.ToString();
            _shopItemsSO[btnNo].IsBought = true;
            _shopPanelsGO[btnNo].gameObject.GetComponent<Image>().color = new Color(1,1,1,1);    
            CheckPurchaseable();          
            }
        }
        else
        {
            Debug.Log("Недостаточно денег");
            CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < _shopItemsSO.Length; i++)
        {
            _shopPanels[i].titleTxt.text = _shopItemsSO[i].Name;
            _shopPanels[i].descriptionTxt.text = _shopItemsSO[i].Description;
            _shopPanels[i].CoinsTxt.text = "Coins: " + _shopItemsSO[i].Currency.Coins.ToString();
            _shopPanels[i].GoldTxt.text = "Golds: " + _shopItemsSO[i].Currency.Golds.ToString();
            _shopPanels[i].Image.sprite = _shopItemsSO[i].Sprite;
            _shopPanels[i].IsBought = _shopItemsSO[i].IsBought;
            if(_shopItemsSO[i].IsBought == true)
            {
                _shopPanels[i].gameObject.GetComponent<Image>().color = new Color(1,1,1,1); ;   
            }        
        }
    }

    public void ResetGame()
    {
        for (int i = 0; i < _shopItemsSO.Length; i++)
        {
            _shopItemsSO[i].IsBought = false;
        }
        Progress.Instance.DeleteFile();
        SceneManager.LoadScene(0);
    }

    public void ButtonGolds()
    {
        Progress.Instance.AddGolds(50);       
        _goldsText.text = "Golds: " + Progress.Instance.Golds.ToString();
        CheckPurchaseable();     
    }

    public void ButtonCoins()
    {
        Progress.Instance.AddCoins(50);       
        _coinsText.text = "Coins: " + Progress.Instance.Coins.ToString();
        CheckPurchaseable();       
    }
}
