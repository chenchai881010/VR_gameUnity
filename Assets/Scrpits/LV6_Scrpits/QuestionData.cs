using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class QuestionData : ScriptableObject
{
    public int id;
    [Multiline(3)]
    public string Question;
    [Multiline(3)]
    public string[] Answers;
    public int[] Answers_point;
}
