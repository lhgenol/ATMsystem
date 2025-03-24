using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] public UserData userData { get; private set; }
    
    public UserInfo userInfo;
    
    public GameObject popupBank;
    public GameObject popupLogin;

    // public const string nameKey = "Name";
    // public const string cashKey = "Cash";
    // public const string balanceKey = "Balence";
    // public const string idKey = "Id";
    // public const string passwordKey = "Password";

    private string savePath;
    
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
        
        savePath = Path.Combine(Application.persistentDataPath, "userData.json");   // 저장 경로 설정
        Debug.Log($"Json 파일 경로: {savePath}");
        
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

    public void SetUserData(UserData newUserData)
    {
        userData = newUserData;
        SaveUserData();
        if (userInfo != null)
        {
            userInfo.Refresh();
        }
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
        // PlayerPrefs.SetString(nameKey, userData.name);
        // PlayerPrefs.SetInt(cashKey, userData.cash);
        // PlayerPrefs.SetInt(balanceKey, userData.balance);
        // PlayerPrefs.SetString(idKey, userData.id);
        // PlayerPrefs.SetString(passwordKey, userData.password);
        // PlayerPrefs.Save();
        
        string json = JsonUtility.ToJson(userData); // userData를 Json 형식 문자열로 직렬화
        File.WriteAllText(savePath, json);  // Json 문자열을 경로에 저장
        Debug.Log($"저장 성공: {json}");
    }

    public void LoadUserData()
    {
        // if (PlayerPrefs.HasKey(nameKey))
        // {
        //     string name = PlayerPrefs.GetString(nameKey);
        //     int cash = PlayerPrefs.GetInt(cashKey);
        //     int balance = PlayerPrefs.GetInt(balanceKey);
        //     string id = PlayerPrefs.GetString(idKey);
        //     string password = PlayerPrefs.GetString(passwordKey);
        //     
        //     userData = new UserData(name, cash, balance, id, password);
        // }
        // else
        // {
        //     userData = new UserData("이현", 100000, 50000, "", "");
        // }

        if (File.Exists(savePath))  // json 파일이 있으면 그 안의 데이터를 UserData 객체로 변환
        {
            string json = File.ReadAllText(savePath);   // 경로의 파일에서 Json 문자열을 읽음
            userData = JsonUtility.FromJson<UserData>(json);    // Json 문자열을 userData 객체로 역직렬화
            Debug.Log($"불러온 데이터: {json}");
        }
        else
        {
            Debug.Log("저장된 데이터가 없습니다.");
        }
    }
}