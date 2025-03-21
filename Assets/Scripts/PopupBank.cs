using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject buttonPanel;

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
}
