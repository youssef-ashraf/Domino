using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controler : MonoBehaviour
{
    public int round = 1;
    public int left, right, play_num=0; //Left playable - Right playable - Left position - Right position
    public float lp, rp;
    public bool begining,turn;
    public Piece leftpiece, rightpiece;
    public float rf = 1, lf = 1;






    // Start is called before the first frame update
    void Start()
    {
        leftpiece = new Piece();
        rightpiece = new Piece();
        lp = 0;
        rp = 0;

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
        if (turn)
        {
            if(rp>5)
            {
                rf = 2;
            }
            if (lp > 5)
            {
                lf = 2;
            }



            GameObject.Find("Player").GetComponent<Player>().turn = false;
            for (int i = 2; i < 5; i++)
            { 
                GameObject.Find("CPU_" + i).GetComponent<CPU>().turn = false; 
            }
            
            if (play_num == 1)
            {
                play_num = 3;
            }
            else if (play_num == 3)
            {
                play_num = 2;
            }
            else if (play_num == 2)
            {
                play_num = 4;
            }
            else if (play_num == 4)
            {
                play_num = 1;
            }

            if (play_num == 1)
                GameObject.Find("Player").GetComponent<Player>().turn = true;
            else GameObject.Find("CPU_" + play_num.ToString()).GetComponent<CPU>().turn = true;
            turn = false;
        }
    }
}
