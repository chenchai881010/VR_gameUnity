using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LearnWay : MonoBehaviour
{
    public static LearnWay Instrance;
    // Start is called before the first frame update
    //��ưO���һݪ���
    private string filePath;
    private string[] fileData;
    //�]�wKEY��Ū��
    private string[] Keys;
    //�ĤG�椧�᪺���O���
    public CSVDemo m_csvDemo;
    //�إߦr��H�K�d��
    public Dictionary<string, CSVDemo> csvDataDic = new Dictionary<string, CSVDemo>();
    //�]�m�}�C[��r�}�C]
    public GameObject[] text_objs;
    public GameObject textDemo;
    public GameObject putpoint;
    public class CSVDemo
    {
        public string ID {get; set;}
        public string Name { get; set; }
        public int PlayTime { get; set; }
        public int HistoryScore { get; set; }
        public int NewScore { get; set; }
        public int TotalTime { get; set; }
    }
    private void Awake()
    {
        if (Instrance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instrance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(VOICRPLAY());
        filePath = Application.dataPath + "/Resources_CH/LearningProcess.csv";
        fileData =File.ReadAllLines(filePath);
        Keys = fileData[0].Split(',');
        for (int x = 1; x < fileData.Length; x++)
        {
            string[] linedata = fileData[x].Split(',');
            CSVDemo csvDemo = new CSVDemo();
            for (int y = 0; y < linedata.Length; y++)
            {
                if (Keys[y] == "ID")
                {
                    csvDemo.ID = linedata[y];
                }
                else if (Keys[y] == "Name")
                {
                    csvDemo.Name = linedata[y];
                }
                else if (Keys[y] == "PlayTime")
                {
                    csvDemo.PlayTime =int.Parse(linedata[y]);
                }
                else if (Keys[y] == "HistoryScore")
                {
                    csvDemo.HistoryScore = int.Parse(linedata[y]);
                }
                else if (Keys[y] == "NewScore")
                {
                    csvDemo.NewScore = int.Parse(linedata[y]);
                }
                else if (Keys[y] == "TotalTime")
                {
                    csvDemo.TotalTime = int.Parse(linedata[y]);
                }
            }
            csvDataDic[csvDemo.ID] = csvDemo;
        }
    }

    // Update is called once per frame
    private IEnumerator VOICRPLAY()
    {
        yield return new WaitForSeconds(1);
        GameManager.Intrestance.playAudio();
    }

    //-------------------------------------------------------------------
    //�d��
    public void getdata(string scarch)
    {
        CSVDemo csvDemo1 = csvDataDic[scarch];
        
        Debug.Log("ID=" + csvDemo1.ID + "�AName=" + csvDemo1.Name+ "�A�C������=" + csvDemo1.PlayTime);
        SaveDatas();
    }


    //�����ɮ�
    public void SaveDatas()
    {
        FileStream fs =new FileStream(filePath,FileMode.Open);
        StreamWriter sw = new StreamWriter(fs);
        for (int i = 0; i < fileData.Length; i++)
        {
            if (i == 0)
            {
                sw.WriteLine(fileData[0]);
            } 
            else if (i == fileData.Length)
            {
                sw.Write(csvDataDic["CH0" + i].ID + "," + csvDataDic["CH0" + i].Name +
                    "," + csvDataDic["CH0" + i].PlayTime + "," + csvDataDic["CH0" + i].HistoryScore + ","
                    + csvDataDic["CH0" + i].NewScore + "," + csvDataDic["CH0" + i].TotalTime);
            }
            else
            {
                sw.WriteLine(csvDataDic["CH0" + i].ID + "," + csvDataDic["CH0" + i].Name +
                    "," + csvDataDic["CH0" + i].PlayTime + "," + csvDataDic["CH0" + i].HistoryScore + ","
                    + csvDataDic["CH0" + i].NewScore + "," + csvDataDic["CH0" + i].TotalTime);
            }
        }
        sw.Close();
        fs.Close();
        Debug.Log("SAVE_FINSH");
    }
    //�}���ɮ�+Ū���
    public void OpenData()
    {

        if (text_objs[0] == null)
        {
            putpoint = GameObject.Find("item_G");
            for (int i = 0; i < 7; i++)
            {
                text_objs[i] = Instantiate(textDemo, putpoint.transform);
                text_objs[i].GetComponent<GetScore>().Score_name = "CH0" + (i + 1);
            }
        }
        for (int i = 0; i < text_objs.Length; i++)
        {
            text_objs[i].GetComponent<GetScore>().Reset_Data();
        }
    }



    //��Ƨ�s����
    public void trestData()
    {
       
    }
}
