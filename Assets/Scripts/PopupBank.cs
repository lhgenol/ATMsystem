using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject buttonPanel;
    public GameObject errorPanel;
    public TMP_InputField depositInput;

    public void OpenDepositPanel()
    {
        buttonPanel.SetActive(false);
        depositPanel.SetActive(true);
    }

    public void OpenWithdrawPanel()
    {
        buttonPanel.SetActive(false);
        withdrawPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }

    public void DepositAmount(int amount)
    {
        if (GameManager.Instance.userData.cash >= amount)
        {
            GameManager.Instance.userData.cash -= amount;
            GameManager.Instance.UpdateBalance(amount);
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }

    public void DepositInputAmount()
    {
        if(int.TryParse(depositInput.text, out int amount))
        {
            DepositAmount(amount);
        }
        else
        {
            depositInput.text = "";
        }
    }

    public void CloseErrorPanel()
    {
        errorPanel.SetActive(false);
    }
}
