using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

/// <summary>
/// 데이터 로드해서 딕셔너리로 만들어주는 함수 갖고있는 로더 클래스
/// Loader에 컴포넌트로 붙혀놓는다.
/// private 이지만 파일 이름과 변수명 동일하게 쓰려고 _안 붙힌다.
/// </summary>
public class CSVLoader : MonoBehaviour
{
    private string _csvPath = "CSV";

    private string csfFileName = "SampleMonster";

    public Dictionary<string, LocalMonsterData> MakeLocalMonsterData()
    {
        List<Dictionary<string, object>> _tempData = CSVReader.Read($"{_csvPath}/{csfFileName}");

        Dictionary<string, LocalMonsterData> dic = new Dictionary<string, LocalMonsterData>();

        for (int i = 0; i < _tempData.Count; i++)
        {
            LocalMonsterData data = new LocalMonsterData();

            data.Id = _tempData[i]["Id"].ToString();
            data.Name = _tempData[i]["Name"].ToString();
            data.Grade = _tempData[i]["Grade"].ToString();
            data.Speed = float.Parse(_tempData[i]["Speed"].ToString());
            data.Health = int.Parse(_tempData[i]["Health"].ToString());
            
            dic.Add(data.Id, data);
        }

        if (dic == null)
        {
            Logging.LogError($"LocalMonsterData");
        }

        return dic;
    }
}
