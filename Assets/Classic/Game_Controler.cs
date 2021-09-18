using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controler : MonoBehaviour
{
    public int round = 1;               // round num
    public int left, right, play_num=0; //Left playable - Right playable - Player number
    public bool begining,turn;           // controllers
    public Piece leftpiece, rightpiece; //left and right in the form of whole piece
    public int turn_num = 0;       // for debugging
    public int left_played, right_played; 
    public Vector3 V_left, V_right;
    public GameObject lefty, righty;  // left and right actual objects


    int p_score, cpu1, cpu2, cpu3;  //Scores
    public float timer;

    public bool checker = true;
    bool final_won;
    public string winner;

    // Start is called before the first frame update
    public void Start()
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

        if (checker)
        {
            checkwin();
            checkclosed();
        }

        if(final_won)
        {
            timer+= Time.deltaTime;
            if (timer < 3.5f)
                return;

            if(winner == "pl")
            {
                for (int i = 2; i < 5; i++)
                {
                    p_score += GameObject.Find("CPU_" + i).GetComponent<CPU>().get_score();
                }

                

                if (p_score < 101)
                {
                    FindObjectOfType<Next>().grow();
                }
                
            }


            else if (winner == "c2")
            {
                for (int i = 3; i < 5; i++)
                {
                    cpu1 += GameObject.Find("CPU_" + i).GetComponent<CPU>().get_score();
                }
                cpu1 += GameObject.Find("Player").GetComponent<Player>().get_score();

                

                if (cpu1 < 101)
                {
                    FindObjectOfType<Next>().grow();
                }
            }


            else if (winner == "c3")
            {
                cpu2 += GameObject.Find("Player").GetComponent<Player>().get_score();
                cpu2 += GameObject.Find("CPU_2").GetComponent<CPU>().get_score();
                cpu2 += GameObject.Find("CPU_4").GetComponent<CPU>().get_score();
                

                if (cpu2 < 101)
                {
                    FindObjectOfType<Next>().grow();
                }
            }


            else if (winner == "c4")
            {
                cpu3 += GameObject.Find("Player").GetComponent<Player>().get_score();
                cpu3 += GameObject.Find("CPU_2").GetComponent<CPU>().get_score();
                cpu3 += GameObject.Find("CPU_3").GetComponent<CPU>().get_score();
                

                if (cpu3 < 101)
                {
                    FindObjectOfType<Next>().grow();
                }
            }

            else
            {
                FindObjectOfType<Next>().grow();
            }


            for (int i = 2; i < 5; i++)
            {
                GameObject.Find("CPU_" + i).GetComponent<CPU>().flip_all();
            }


            FindObjectOfType<score>().do_it(p_score,cpu1,cpu2,cpu3);
            final_won = false;
            turn = false;
            
            
        }

        else if (turn)
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


    void checkwin()
    {
        bool won = true;
        var p = GameObject.Find("Player").GetComponent<Player>();
        var cp2 = GameObject.Find("CPU_2").GetComponent<CPU>();
        var cp3 = GameObject.Find("CPU_3").GetComponent<CPU>();
        var cp4 = GameObject.Find("CPU_4").GetComponent<CPU>();

        for(int i=0;i<7;i++)
        {
            if(!p.finalclicky[i])
            {
                
                won = false;
                break;
            }
        }
        if(won)
        {
            winner = "pl";
            turn = false;
            checker = false;
            final_won = true;
            return;
        }

        won = true;
        for (int i = 0; i < 7; i++)
        {
            if (!cp2.finalclicky[i])
            {
                won = false;
                break;
            }
        }
        if (won)
        {
            winner = "c2";
            turn = false;
            checker = false;
            final_won = true;
            return;
        }

        won = true;
        for (int i = 0; i < 7; i++)
        {
            if (!cp3.finalclicky[i])
            {
                won = false;
                break;
            }
        }
        if (won)
        {
            winner = "c3";
            turn = false;
            checker = false;
            final_won = true;
            return;
        }

        won = true;
        for (int i = 0; i < 7; i++)
        {
            if (!cp4.finalclicky[i])
            {
                won = false;
                break;
            }
        }
        if (won)
        {
            winner = "c4";
            turn = false;
            checker = false;
            final_won = true;
            return;
        }

    }

    


    void checkclosed()
    {
        bool closed = true;
        var p = GameObject.Find("Player").GetComponent<Player>();
        var cp2 = GameObject.Find("CPU_2").GetComponent<CPU>();
        var cp3 = GameObject.Find("CPU_3").GetComponent<CPU>();
        var cp4 = GameObject.Find("CPU_4").GetComponent<CPU>();

        if(p.check(left))
        {
            closed = false;
        }
        if (p.check(right))
        {
            closed = false;
        }
        if (cp2.check(left))
        {
            closed = false;
        }
        if (cp2.check(right))
        {
            closed = false;
        }
        if (cp3.check(left))
        {
            closed = false;
        }
        if (cp3.check(right))
        {
            closed = false;
        }
        if (cp4.check(left))
        {
            closed = false;
        }
        if (cp4.check(right))
        {
            closed = false;
        }

        if(closed)
        {
            var sc1 = p.get_score();
            var sc2 = cp2.get_score();
            var sc3 = cp3.get_score();
            var sc4 = cp4.get_score();
            print(sc1 + " " + sc2 + " " + sc3 + " " + sc4);
            if (sc1 < sc2 && sc1 < sc3 && sc1 < sc4)
            {
                winner = "pl";
            }
            if (sc2 < sc1 && sc2 < sc3 && sc2 < sc4)
            {
                winner = "c2";
            }
            if (sc3 < sc1 && sc3 < sc2 && sc3 < sc4)
            {
                winner = "c3";
            }
            if (sc4 < sc1 && sc4 < sc2 && sc4 < sc3)
            {
                winner = "c4";
            }

            turn = false;
            checker = false;
            final_won = true;
            return;
        }
    }






}
