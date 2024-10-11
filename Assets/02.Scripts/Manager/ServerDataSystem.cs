using Firebase.Database;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ServerDataSystem
{
    private string userId;
    private DatabaseReference databaseReference;

    private int userIdCount = 0;

    public void Init()
    {
        userId = SystemInfo.deviceUniqueIdentifier;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser()
    {
        ServerUserData newUser = new ServerUserData(userId, 0);
        string json = JsonUtility.ToJson(newUser);
        databaseReference.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }
}