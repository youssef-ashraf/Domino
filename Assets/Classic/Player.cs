using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool turn;
    Piece[] hand;
    GameObject[] hand_graph;
    bool[] clicky = new bool[7];
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("Game_Starter").GetComponent<Game>().Hand1;
        hand_graph = GameObject.Find("Game_Starter").GetComponent<Game>().Hand1_rand;

    }

    // Update is called once per frame
    void Update()
    {
        if(turn==true)
        {
            if(GameObject.Find("Game_Controler").GetComponent<Game_Controler>().begining == true && GameObject.Find("Game_Controler").GetComponent<Game_Controler>().round==1)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (hand[i].big == hand[i].small && hand[i].small == 6 && !clicky[i]) 
                    {
                        clicky[i] = true;
                        hand_graph[i].AddComponent<Clickable>();
                    }
                }
            }
        }
    }
}
