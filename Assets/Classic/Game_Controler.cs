using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controler : MonoBehaviour
{
    public int round = 1;
    public int left, right, play_num=0; //Left playable - Right playable - Player number
    public bool begining,turn;
    public Piece leftpiece, rightpiece;
    public int turn_num = 0;       // for debugging
    public int left_played, right_played;
    public Vector3 V_left, V_right;






    // Start is called before the first frame update
    void Start()
    {

        V_left = new Vector3(0, 0, 0);
        V_right = new Vector3(0, 0, 0);
        leftpiece = new Piece();
        rightpiece = new Piece();
        left_played = 0;
        right_played = 0;

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

        if (play_num == 1)
            GameObject.Find("Player").GetComponent<Player>().turn = true;
        else GameObject.Find("CPU_" + play_num.ToString()).GetComponent<CPU>().turn = true;

    }

    // Update is called once per frame
    void Update()
    {
        



        if (turn)
        {
            turn_num++;
            




            








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
