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
    
    public UserData(string name, int cash, int balance)
    {
        this.name = name;
        this.cash = cash;
        this.balance = balance;
    }
}