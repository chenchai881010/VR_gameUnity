using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstsetting : MonoBehaviour
{
    public GameObject[] first_trees;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < first_trees.Length; i++)
        {
            first_trees[i].GetComponent<TreePlen_ground>().count_point(false);
        }
        StartCoroutine(playAudio());
    }
    public IEnumerator playAudio()
    {
        yield return new WaitForSeconds(1);
        GameManager.Intrestance.step = 1;
        GameManager.Intrestance.playAudio();
        yield return new WaitForSeconds(10.5f);
        GameManager.Intrestance.playAudio();
    }

}
