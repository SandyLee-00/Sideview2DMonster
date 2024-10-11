using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerUserData
{
    public string Name;
    public int KillCount;

    public ServerUserData(string name, int killCount)
    {
        Name = name;
        KillCount = killCount;
    }
}
