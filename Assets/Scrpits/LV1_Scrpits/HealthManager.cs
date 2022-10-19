using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public GameObject[] healthItem;//0 = 面罩眼鏡 1 = 氧氣瓶
    public GameObject[] put_Point;//生成點

    private int[] put_number = new int[3];//t紀錄放置點
    private GameObject[] input_obj = new GameObject[3];
    private int number;
    private float nextTime;
    private int count;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        number = Random.Range(0, put_Point.Length);
        input_obj[0] = Instantiate(healthItem[0],put_Point[number].transform.position,Quaternion.identity);
        put_number[0] = number;
        for (int i = 1; i < 2; )
        {
            number = Random.Range(0, put_Point.Length);
            if (number != put_number[0])
            {
                put_number[1] = number;
                input_obj[1] = Instantiate(healthItem[1], put_Point[number].transform.position, Quaternion.identity);
                i++;
            }
        }
        for (int i = 1; i < 2;)
        {
            number = Random.Range(0, put_Point.Length);
            if (number != put_number[0] && number != put_number[1])
            {
                put_number[2] = number;
                input_obj[2] = Instantiate(healthItem[2], put_Point[number].transform.position, Quaternion.identity);
                i++;
            }
        }
        nextTime = 10;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTime <= 0)
        {
            inputHealth();
        }
        else
        {
            nextTime -= Time.deltaTime;
        }
    }
    public void inputHealth()
    {
        nextTime = 10;

        if (input_obj[count] != null)
        {
            Destroy(input_obj[count], 0.5f);
        }
        for (int i = 1; i < 2;)
        {
            number = Random.Range(0, put_Point.Length);
            if (number != put_number[0] && number != put_number[1] && number != put_number[2])
            {
                put_number[count] = number;
                input_obj[count] = Instantiate(healthItem[count], put_Point[number].transform.position, Quaternion.identity);
                i++;
            }
        }
        count++;
        if (count>2)
        {
            count = 0;
        }
    }
}
