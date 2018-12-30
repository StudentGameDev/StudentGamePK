using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// Tablica, scrollowalna z wynikami ładowanymi z pliku
public class ScoreBoard : MonoBehaviour {

    [SerializeField]
    GameObject playerScoreboardItem;

    [SerializeField]
    Transform playerScoreboardList;

    [SerializeField]
    ScrollRect scroll;

    void Start () {
        string path = String.Format(@"{0}\scores.txt", Environment.CurrentDirectory);

        using (StreamReader sr = File.OpenText(path))
        {
            string rowLine = "";
            List<string> lines = new List<string>();
            while ((rowLine = sr.ReadLine()) != null)
            {
                lines.Add(rowLine);               
            }

            lines.Reverse();

            foreach (var line in lines)
            {
                GameObject itemGO = (GameObject)Instantiate(playerScoreboardItem, playerScoreboardList);
                PlayerScoreboardItem item = itemGO.GetComponent<PlayerScoreboardItem>();

                if (item != null)
                {
                    var lineElements = line.Split(';');
                    if (lineElements.Length == 3)
                    {
                        item.Setup(lineElements[0], lineElements[2], lineElements[1]);
                    }
                }
            }

            scroll.verticalNormalizedPosition = 1f;
        }
    }
}
