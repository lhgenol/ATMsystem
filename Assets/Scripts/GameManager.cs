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
    
    private UserDataList userDataList;
    private UserData loginUser;
    
    public UserInfo userInfo;
    
    public GameObject popupBank;
    public GameObject popupLogin;

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
        
        savePath = Path.Combine(Application.persistentDataPath, "users.json");   // 저장 경로 설정
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

    public UserData GetCurrentUser()    // 현재 로그인한 유저 반환
    {
        return loginUser;
    }

    public void SetUserData(UserData newUserData)   // 새로운 유저 데이터 설정
    {
        if (userDataList == null)
        {
            userDataList = new UserDataList();
        }
        
        // UserData existingUser = userDataList.users.Find(user => user.id == newUserData.id);
        
        // 중복 유저 확인
        UserData existingUser = null;
        foreach (UserData user in userDataList.users)
        {
            if (user.id == newUserData.id)
            {
                existingUser = user;
                break;
            }
        }
        
        if (existingUser != null)
        {
            // 기존 유저 업데이트(덮어씌우기)
            existingUser.name = newUserData.name;
            existingUser.cash = newUserData.cash;
            existingUser.balance = newUserData.balance;
            existingUser.password = newUserData.password;
        }
        else
        {
            userDataList.users.Add(newUserData);    // 새 유저 추가
        }
        
        userData = newUserData;
        loginUser = newUserData;
        SaveUserData();
        
        if (userInfo != null)
        {
            userInfo.Refresh();
        }
    }

    // 유저 데이터를 JSON 파일에 저장
    public void SaveUserData()
    {
        if (userDataList == null)
        {
            userDataList = new UserDataList();
        }
        
        string json = JsonUtility.ToJson(userDataList, true); // userDataList를 JSON 문자열로 직렬화
        File.WriteAllText(savePath, json);  // JSON 문자열을 경로에 저장
        Debug.Log($"유저 데이터리스트 저장 성공: {json}");
    }
    
    // JSON 파일에서 유저 데이터를 로드
    public void LoadUserData()
    {
        if (File.Exists(savePath))  // JSON 파일 존재여부 확인
        {
            string json = File.ReadAllText(savePath);   // 경로의 파일에서 JSON 문자열을 읽음
            Debug.Log($"불러온 데이터: {json}");
            
            userDataList = JsonUtility.FromJson<UserDataList>(json);    // Json 문자열을 userDataList 객체로 역직렬화
    
            Debug.Log($"불러온 유저 수: {userDataList.users.Count}");
        }
        else
        {
            Debug.Log("저장된 데이터가 없습니다.");
            userDataList = new UserDataList();
        }
    }

    public UserData FindUserID(string userID)
    {
        if (userDataList == null || userDataList.users == null)
        {
            Debug.Log("유저 데이터 리스트 정보가 없습니다.");
            userDataList = new UserDataList();
            return null;
        }

        foreach (UserData user in userDataList.users)   // ID가 일치하는 유저를 찾아서 반환
        {
            if (user.id == userID)
            {
                return user;
            }
        }

        return null;
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
}