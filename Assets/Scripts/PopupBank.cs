using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject transferPanel;
    public GameObject buttonPanel;
    public GameObject errorPanel;
    public GameObject loginPanel;
    
    public TMP_InputField depositInput;
    public TMP_InputField withdrawInput;
    public TMP_InputField transferUserInput;
    public TMP_InputField transferAmountInput;
    
    public TextMeshProUGUI errorText;

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

    public void OpenTransferPanel()
    {
        buttonPanel.SetActive(false);
        transferPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        transferPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }

    // 입금 처리
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

    // 출금 처리
    public void WithdrawAmount(int amount)
    {
        if (GameManager.Instance.userData.balance >= amount)
        {
            GameManager.Instance.userData.balance -= amount;
            GameManager.Instance.UpdateCash(amount);
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }

    // 송금 처리
    public void TransferAmount()
    {
        string targetID = transferUserInput.text; // 송금 대상의 ID 가져오기

        if (string.IsNullOrWhiteSpace(targetID))
        {
            ShowError("송금 대상을 입력하세요.");
            return;
        }
        
        UserData sender = GameManager.Instance.GetCurrentUser();    // 발신자(로그인 유저) 정보
        UserData receiver = GameManager.Instance.FindUserID(targetID);  // 수신자 정보
        
        if (receiver == null)
        {
            ShowError("송금 대상이\n존재하지 않습니다.");
            return;
        }

        if (string.IsNullOrWhiteSpace(transferAmountInput.text))
        {
            ShowError("송금 금액을 입력하세요.");
            return;
        }

        if (!int.TryParse(transferAmountInput.text, out int amount) || amount <= 0)
        {
            ShowError("송금할 수 없습니다.");
            return;
        }
        
        if (sender.balance < amount)
        {
            ShowError("잔액이 부족합니다.");
            return;
        }
        
        if (targetID == sender.id)
        {
            ShowError("자신에게 송금할 수 없습니다.");
            return;
        }
        
        sender.balance -= amount;   // 발신 처리
        receiver.balance += amount; // 수신 처리

        if (GameManager.Instance.userInfo != null)
        {
            GameManager.Instance.userInfo.Refresh();
        }
        
        GameManager.Instance.SaveUserData();
        Debug.Log($"송금 완료: {sender.name}이 {receiver.name}에게 {amount}원 송금");
    
        transferUserInput.text = "";
        transferAmountInput.text = "";
    }

    // 금액 입력값 입금 처리
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
        
        depositInput.text = "";
    }

    // 금액 입력값 출금 처리
    public void WithdrawInputAmount()
    {
        if (int.TryParse(withdrawInput.text, out int amount))
        {
            WithdrawAmount(amount);
        }
        else
        {
            withdrawInput.text = "";
        }
        
        withdrawInput.text = "";
    }
    
    private void ShowError(string massage)
    {
        errorText.text = massage;
        errorPanel.SetActive(true);
    }

    public void GotoLoginPanel()
    {
        loginPanel.SetActive(true);
    }

    public void CloseErrorPanel()
    {
        errorPanel.SetActive(false);
    }
}
