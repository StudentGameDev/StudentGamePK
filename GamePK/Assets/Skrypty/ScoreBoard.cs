﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    [SerializeField]
    GameObject playerScoreboardItem;

    [SerializeField]
    Transform playerScoreboardList;

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
        }
    }

    // Update is called once per frame
    void Update () {

        //if (!File.Exists(path))
        //{
        //    // Create a file to write to.
        //    using (StreamWriter sw = File.CreateText(path))
        //    {
        //        sw.WriteLine("Hello");
        //        sw.WriteLine("And");
        //        sw.WriteLine("Welcome");
        //    }
        //}
    }
}
