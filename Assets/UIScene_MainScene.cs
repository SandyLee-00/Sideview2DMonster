using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScene_MainScene : MonoBehaviour
{
    public TextMeshProUGUI KillMonsterText;

    public void SetKillMonsterText(int killMonsterCount)
    {
        KillMonsterText.text = $"죽인 몬스터 수 : {killMonsterCount}";
    }
}
