using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CPU : MonoBehaviour
{
    public bool turn;
    public Piece[] hand;
    GameObject[] hand_graph;
    public string s;
    public bool[] clicky = new bool[7];
    public bool[] finalclicky = new bool[7];
    List<Piece> l = new List<Piece>();
    Game_Controler g;
    // Start is called before the first frame update
    public void Start()
    {
        g = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();
        s = gameObject.name.Split('_')[1];


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
        if (turn)
        {
            if (GameObject.Find("Game_Controler").GetComponent<Game_Controler>().begining == true && GameObject.Find("Game_Controler").GetComponent<Game_Controler>().round == 1)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (hand[i].big == hand[i].small && hand[i].small == 6 && !clicky[i] && !finalclicky[i])
                    {
                        clicky[i] = true;
                        hand_graph[i].AddComponent<CPU_Move>();
                        hand_graph[i].GetComponent<CPU_Move>().commit(hand[i].big, hand[i].small, gameObject.GetComponent<CPU>());
                    }
                }
            }
            else if (GameObject.Find("Game_Controler").GetComponent<Game_Controler>().begining)
            {
                l.Clear();
                for (int i = 0; i < 7; i++)
                {
                    if (hand[i].big == hand[i].small && !clicky[i] && !finalclicky[i])
                    {
                        clicky[i] = true;
                        l.Add(hand[i]);

                    }
                }
                System.Random rnd = new System.Random();
                try
                {
                    var li = l.ToArray().OrderBy(x => rnd.Next()).ToArray()[0];
                    for (int i = 0; i < 7; i++)
                    {
                        if (li.big == hand[i].big && li.small == hand[i].small)
                        {

                            hand_graph[i].AddComponent<CPU_Move>();
                            hand_graph[i].GetComponent<CPU_Move>().commit(hand[i].big, hand[i].small, gameObject.GetComponent<CPU>());


                        }
                    }
                }
                catch (System.Exception e)
                {
                    StartCoroutine(skip());
                }

            }
            else
            {
                l.Clear();
                for (int i = 0; i < 7; i++)
                {
                    if ((hand[i].big == g.left || hand[i].small == g.left || hand[i].big == g.right || hand[i].small == g.right) && !clicky[i] && !finalclicky[i])
                    {
                        clicky[i] = true;
                        l.Add(hand[i]);

                    }
                }
                System.Random rnd = new System.Random();

                try
                {
                    Piece li = l.ToArray().OrderBy(x => rnd.Next()).ToArray()[0];

                    for (int i = 0; i < 7; i++)
                    {
                        if (li.big == hand[i].big && li.small == hand[i].small)
                        {

                            hand_graph[i].AddComponent<CPU_Move>();
                            hand_graph[i].GetComponent<CPU_Move>().commit(hand[i].big, hand[i].small, gameObject.GetComponent<CPU>());

                        }
                    }
                }
                catch (System.Exception e)
                {
                    StartCoroutine(skip());
                }
            }


        }
    }


    public void setagian(int up, int down)
    {
        for (int i = 0; i < 7; i++)
        {
            if (hand[i].big == up && hand[i].small == down)
            {
                finalclicky[i] = true;

            }
        }
        for (int i = 0; i < 7; i++)
        {
            clicky[i] = false;
        }
        //for (int i = 0; i < 7; i++)
        //{
        //    print("clicky[" + i + "] =" + clicky[i]);
        //    print("finalclicky[" + i + "] =" + finalclicky[i]);
        //}
    }
    IEnumerator skip()
    {
        turn = false;
        Vector3 vec;
        Quaternion eu;
        if (s == "2")
        {
            vec = new Vector3(0, 2.25f, 0);
            eu = Quaternion.identity;
        }
        else if (s == "3")
        {
            vec = new Vector3(-5, 0, 0);
            eu = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            vec = new Vector3(5, 0, 0);
            eu = Quaternion.Euler(0, 0, 90);
        }


        GameObject skip = GameObject.Instantiate(GameObject.Find("Skip"), vec, eu);
        yield return new WaitForSeconds(2);
        Destroy(skip);
        yield return new WaitForSeconds(1);
        g.turn = true;
    }

    public void flip_all()
    {
        for (int i = 0; i < 7; i++)
        {
            if (!clicky[i] && !finalclicky[i])
            {
                clicky[i] = true;
                hand_graph[i].AddComponent<CPU_Move>();
                hand_graph[i].GetComponent<CPU_Move>().flipper(hand[i].big, hand[i].small);
            }
        }
    }

    public int get_score()
    {
        int score = 0;
        for (int i = 0; i < 7; i++)
        {
            if (!clicky[i] && !finalclicky[i])
            {
                score += hand[i].big + hand[i].small;
            }
        }
        return score;
    }


    public bool check(int num)
    {
        bool playable = false;
        for (int i = 0; i < 7; i++)
        {
            if (!finalclicky[i] && (num == hand[i].big || num == hand[i].small))
            {
                playable = true;
            }
        }
        return playable;
    }

}
