using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public string Score_name;
    public Text[] ch_texts;
    // Start is called before the first frame update


    public void Reset_Data()
    {
        LearnWay.CSVDemo cSVDemo = LearnWay.Instrance.csvDataDic[Score_name];
        ch_texts[0].text = cSVDemo.Name;
        ch_texts[1].text = cSVDemo.PlayTime.ToString();
        ch_texts[2].text = cSVDemo.HistoryScore.ToString();
        ch_texts[3].text = cSVDemo.NewScore.ToString();
        ch_texts[4].text = cSVDemo.TotalTime.ToString();

    }
}
