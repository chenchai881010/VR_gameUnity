using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CHData : ScriptableObject
{
    public int Class_ID;
    public string Class_name;
    public Sprite[] Game_images;
    [Space]
    [Multiline(3)]
    public string HowToPlay;
    [Space]
    [Multiline(3)]
    public string Class_Introduction;

    public string PlayScene;
    public AudioClip CHvoice;
}
