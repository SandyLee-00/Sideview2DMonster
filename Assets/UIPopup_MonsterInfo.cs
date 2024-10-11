using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup_MonsterInfo : MonoBehaviour
{
    public Button BackgroundButton;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI GradeText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI HealthText;

    private void Start()
    {
        BackgroundButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        });
    }

    private void Init(GameObject monster)
    {
        LocalMonsterData monsterData = monster.GetComponent<Monster>().monsterData;
        NameText.text = monsterData.Name;
        GradeText.text = monsterData.Grade;
        SpeedText.text = monsterData.Speed.ToString();
        HealthText.text = monsterData.Health.ToString();
    }
}
