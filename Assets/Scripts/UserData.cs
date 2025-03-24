using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string name;
    public int cash;
    public int balance;
    public string id;
    public string password;
    
    public UserData(string name, int cash, int balance, string id, string password)
    {
        this.name = name;
        this.cash = cash;
        this.balance = balance;
        this.id = id;
        this.password = password;
    }
}