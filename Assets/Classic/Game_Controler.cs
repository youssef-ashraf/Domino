using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controler : MonoBehaviour
{
    public int round = 1;
    int left,right,lp,rp,play_num=0;
    public bool begining;






    // Start is called before the first frame update
    void Start()
    {
        begining = true;
        Game g = GameObject.Find("Game_Starter").GetComponent<Game>();
        if (round==1)
        {
            foreach(Piece x in g.Hand1)
            {
                if (x.big == x.small && x.small == 6)
                {
                    play_num = 1;
                }
            }

            foreach (Piece x in g.Hand2)
            {
                if (x.big == x.small && x.small == 6) 
                { 
                    play_num = 2;
                }
            }

            foreach (Piece x in g.Hand3)
            {
                if (x.big == x.small && x.small == 6)
                {
                    play_num = 3;
                }
            }

            foreach (Piece x in g.Hand4)
            {
                if (x.big == x.small && x.small == 6)
                {
                    play_num = 4;
                }
            }

        }

        lp = 0;
        rp = 0;
        if (play_num == 1)
            GameObject.Find("Player").GetComponent<Player>().turn = true;
        else GameObject.Find("CPU_" + play_num.ToString()).GetComponent<CPU>().turn = true;

    }

    // Update is called once per frame
    void Update()
    {
        //if (play_num == 1)
        //{
        //    GameObject.Find("Player").GetComponent<Player>().turn = true;
        //}
        //else 
        //{ 
        //    GameObject.Find("CPU_" + play_num.ToString()).GetComponent<CPU>().turn = true; 
        //}
    }
}
