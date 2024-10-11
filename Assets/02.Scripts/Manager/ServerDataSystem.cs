using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ServerDataSystem
{
    private string userId;
    private DatabaseReference databaseReference;

    public ServerUserData User;

    public void Init()
    {
        userId = SystemInfo.deviceUniqueIdentifier;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser()
    {
        User = new ServerUserData(userId, 0);
        string json = JsonUtility.ToJson(User);
        databaseReference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }

    public void SaveUserData()
    {
        databaseReference.Child("users").Child(userId).Child("KillCount").SetValueAsync(User.KillCount);
    }

    public void LoadUserData()
    {
        databaseReference.Child("users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if(task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if(snapshot.Exists)
                {
                    User = JsonUtility.FromJson<ServerUserData>(snapshot.GetRawJsonValue());
                }
                else
                {
                    CreateUser();
                }
            }
            else
            {
                Debug.LogError("ServerDataSystem LoadUserData Error : " + task.Exception.Message);
            }
        });
    }
}