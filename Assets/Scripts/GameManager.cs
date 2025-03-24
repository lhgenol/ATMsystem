using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] public UserData userData { get; private set; }
    public UserInfo userInfo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // PlayerPrefs.DeleteAll();
        LoadUserData();
    }

    public void Start()
    {
        if (userInfo == null)
        {
            userInfo = FindObjectOfType<UserInfo>();
        }
        
        // UpdateName("이현");
        // UpdateCash(100001);
        // UpdateBalance(50001);
        
        SaveUserData();
    }
    
    public void UpdateName(string newName)
    {
        userData.name = newName;
        userInfo.Refresh();
        SaveUserData();
    }
    
    public void UpdateCash(int amount)
    {
        userData.cash += amount;
        userInfo.Refresh();
        SaveUserData();
    }

    public void UpdateBalance(int amount)
    {
        userData.balance += amount;
        userInfo.Refresh();
        SaveUserData();
    }

    public void SaveUserData()
    {
        PlayerPrefs.SetString("Name", userData.name);
        PlayerPrefs.SetInt("Cash", userData.cash);
        PlayerPrefs.SetInt("Balance", userData.balance);
        PlayerPrefs.Save();
    }

    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            string name = PlayerPrefs.GetString("Name");
            int cash = PlayerPrefs.GetInt("Cash");
            int balance = PlayerPrefs.GetInt("Balance");
            userData = new UserData(name, cash, balance);
        }
        else
        {
            userData = new UserData("이현", 100000, 50000);
        }
    }
}