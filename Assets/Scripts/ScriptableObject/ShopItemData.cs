using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "Custom Assets/ShopItemData")]
[Serializable]
public class ShopItemData : ScriptableObject 
{
    #region Properties
    public string Name => _name;
    public string Description => _description;
    public ProgressData Currency => _currencies;
    public Sprite Sprite => _sprite;
    public bool IsBought; 
    #endregion

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private ProgressData _currencies;
    [SerializeField] private Sprite _sprite;
    // [SerializeField] bool _isBought;
    [SerializeField] private DateTime _startTime;
}
