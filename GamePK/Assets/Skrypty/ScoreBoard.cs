using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField]
    GameObject playerScoreboardItem;

    [SerializeField]
    Transform playerScoreboardList;

    [SerializeField]
    ScrollRect scroll;

    // Use this for initialization
    void Start () {
        string path = String.Format(@"{0}\scores.txt", Environment.CurrentDirectory);

        using (StreamReader sr = File.OpenText(path))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                GameObject itemGO = (GameObject) Instantiate(playerScoreboardItem, playerScoreboardList);
                PlayerScoreboardItem item = itemGO.GetComponent<PlayerScoreboardItem>();

                if (item != null)
                {
                    var lineElements = line.Split(';');
                    if (lineElements.Length == 3)
                    {
                        item.Setup(lineElements[0], lineElements[1], lineElements[2]);
                    }
                }
                
            }
            scroll.verticalNormalizedPosition = 1f;
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
