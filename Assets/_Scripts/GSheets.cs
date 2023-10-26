using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class GSheets : MonoBehaviour
{
    public Dictionary<int, float> SpeedData = new();
    public Dictionary<int, float> TimeBetweenEggDropsData = new();
    public Dictionary<int, float> LeftRightDistanceData = new();
    public Dictionary<int, float> ChanceDirectionData = new();

    public IEnumerator Load()
    {
        UnityWebRequest curentResp = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1t51tbdECzuv2HCd7WMHwYR2gLQ8H2v0-Y-4a_cksxWg/values/BigDigital GameLab?key=AIzaSyAKh8NHJ7IjIy_NFT8XuaCZHclATuldY2c");
        yield return curentResp.SendWebRequest();

        string rawResp = curentResp.downloadHandler.text;
        var rawJson = JSON.Parse(rawResp);
        int i = 0;
        foreach (var itemRawJson in rawJson["values"])
        {
            i = i + 1;
            var parseJson = JSON.Parse(itemRawJson.ToString());
            var selectRow = parseJson[0].AsStringList;

            if (i == 3)
            {
                for (int j = 0; j < LevelData.MaxLevel; j++)
                {
                    SpeedData[j + 1] = float.Parse(selectRow[j]);
                    TimeBetweenEggDropsData[j + 1] = float.Parse(selectRow[j + LevelData.MaxLevel + 1]);
                }
            }
            if(i == 23)
            {
                for (int j = 0; j < LevelData.MaxLevel; j++)
                {
                    LeftRightDistanceData[j + 1] = float.Parse(selectRow[j]);
                    ChanceDirectionData[j + 1] = float.Parse(selectRow[j + LevelData.MaxLevel + 1]);
                }
            }
        }
    }
}
