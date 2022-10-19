using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class TreeData : ScriptableObject
{
    public string tree_name;
    public string tree_type;
    public int point;
    [Multiline (3)]
    public string treeIntroduction;
    public Sprite treeimage;
    public GameObject treeModle;
    
}
