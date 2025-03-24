using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] public UserData userData { get; private set; }
    
    public UserInfo userInfo;
    public GameObject popupBank;
    public GameObject popupLogin;

    public const string nameKey = "Name";
    public const string cashKey = "Cash";
    public const string balanceKey = "Balence";
    public const string idKey = "Id";
    public const string passwordKey = "Password";
    
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
        
        LoadUserData();
    }

    public void Start()
    {
        if (userInfo == null)
        {
            userInfo = FindObjectOfType<UserInfo>();
        }
        
        SaveUserData();
        popupBank.SetActive(false);
        popupLogin.SetActive(true);
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
        PlayerPrefs.SetString(nameKey, userData.name);
        PlayerPrefs.SetInt(cashKey, userData.cash);
        PlayerPrefs.SetInt(balanceKey, userData.balance);
        PlayerPrefs.SetString(idKey, userData.id);
        PlayerPrefs.SetString(passwordKey, userData.password);
        PlayerPrefs.Save();
    }

    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey(nameKey))
        {
            string name = PlayerPrefs.GetString(nameKey);
            int cash = PlayerPrefs.GetInt(cashKey);
            int balance = PlayerPrefs.GetInt(balanceKey);
            string id = PlayerPrefs.GetString(idKey);
            string password = PlayerPrefs.GetString(passwordKey);
            
            userData = new UserData(name, cash, balance, id, password);
        }
        else
        {
            userData = new UserData("이현", 100000, 50000, "", "");
        }
    }
}