using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    public bool turn;
    Piece[] hand;
    GameObject[] hand_graph;
    // Start is called before the first frame update
    void Start()
    {
        var s = gameObject.name.Split('_')[1];

        
        if (s == "2")
        {
            hand = GameObject.Find("Game_Starter").GetComponent<Game>().Hand2;
            hand_graph = GameObject.Find("Game_Starter").GetComponent<Game>().Hand2_rand;
        }
        if (s == "3")
        {
            hand = GameObject.Find("Game_Starter").GetComponent<Game>().Hand3;
            hand_graph = GameObject.Find("Game_Starter").GetComponent<Game>().Hand3_rand;
        }
        if (s == "4")
        {
            hand = GameObject.Find("Game_Starter").GetComponent<Game>().Hand4;
            hand_graph = GameObject.Find("Game_Starter").GetComponent<Game>().Hand4_rand;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
