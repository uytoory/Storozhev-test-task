using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public int Coins;
    public int Golds;   

    public static Progress Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Load();
    }

    public void AddCoins(int value)
    {
        Coins += value;
        Save();
    }   

    public void AddGolds(int value)
    {
        Golds += value;
        Save();
    }

    public void MinusCoins(int value)
    {
        Coins -= value;
        Save();
    }   

    public void MinusGolds(int value)
    {
        Golds -= value;
        Save();
    }


    [ContextMenu("DeleteFile")]
    public void DeleteFile()
    {
        SaveSystem.DeleteFile();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        SaveSystem.Save(this);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        ProgressData progressData = SaveSystem.Load();
        if(progressData != null)
        {           
            Coins = progressData.Coins;
            Golds = progressData.Golds;             
        }
        else
        {
            Coins = 0;
            Golds = 0;
        }
    }
}
