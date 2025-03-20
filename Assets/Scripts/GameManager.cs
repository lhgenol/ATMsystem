using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;
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
        }
        
        userData = new UserData("이현", 100000, 50000);
    }

    public void Start()
    {
        if (userInfo == null)
        {
            userInfo = FindObjectOfType<UserInfo>();
        }
        
        UpdateName("이유림");
        UpdateCash(500);
        UpdateBalance(500);
    }
    
    public void UpdateName(string newName)
    {
        userData.name = newName;
        userInfo.Refresh();
    }
    
    public void UpdateCash(int amount)
    {
        userData.cash += amount;
        userInfo.Refresh();
    }

    public void UpdateBalance(int amount)
    {
        userData.balance += amount;
        userInfo.Refresh();
    }
}
