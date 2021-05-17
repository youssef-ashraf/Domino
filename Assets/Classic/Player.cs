using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool turn;
    Piece[] hand;
    public GameObject[] hand_graph;
    public bool[] clicky = new bool[7];
    public bool[] finalclicky = new bool[7];
    public int played;
    public bool played2;
    Game_Controler g;
    bool skipper;
    // Start is called before the first frame update
    public void Start()
    {
        skipper = true;
        g = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();
        hand = GameObject.Find("Game_Starter").GetComponent<Game>().Hand1;
        hand_graph = GameObject.Find("Game_Starter").GetComponent<Game>().Hand1_rand;

    }

    // Update is called once per frame
    void Update()
    {
        if(turn==true)
        {
            
            if (g.begining == true && g.round==1)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (hand[i].big == hand[i].small && hand[i].small == 6 && !clicky[i] && !finalclicky[i]) 
                    {
                        clicky[i] = true;
                        hand_graph[i].AddComponent<Clickable>();
                        hand_graph[i].AddComponent<OnTouchDown>();
                    }
                }
            }
            else if (g.begining == true)
            {
               
                for (int i = 0; i < 7; i++)
                {
                    if (hand[i].big == hand[i].small && !clicky[i] && !finalclicky[i])
                    {
                        clicky[i] = true;
                        hand_graph[i].AddComponent<Clickable>();
                        hand_graph[i].AddComponent<OnTouchDown>();
                    }
                }
            }

            else
            {
                
                for (int i = 0; i < 7; i++)
                {
                    
                    if ((hand[i].big == g.left || hand[i].small == g.left || hand[i].big == g.right || hand[i].small == g.right) && !clicky[i] && !finalclicky[i])
                    {
                        
                        clicky[i] = true;
                        hand_graph[i].AddComponent<Clickable>();
                        hand_graph[i].AddComponent<OnTouchDown>();
                    }
                }
            }

            for (int i = 0; i < 7; i++)
            {

                if(clicky[i])
                {
                    //print(i);
                    skipper = false;
                }
            }
            if(skipper)
            {
                //print("a");
                StartCoroutine(skip());
                
            }
            skipper = true;
        }
    }

    public void setagian(int up, int down)
    {
        turn = false;
        for (int i = 0; i < 7; i++) 
        {
            Destroy(hand_graph[i].GetComponent<Clickable>());
            hand_graph[i].GetComponent<SpriteRenderer>().color = Color.white;
            if (hand[i].big == up && hand[i].small == down)
            {
                finalclicky[i] = true;
            }
        }
        for(int i = 0; i < 7; i++)
        {
            clicky[i] = false;
        }
        for (int i = 0; i < 7; i++)
        {
            hand_graph[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }


    }




    IEnumerator skip()
    {
        turn = false;
        Vector3 vec = new Vector3(0, -2.25f, 0);
        Quaternion eu = Quaternion.identity;
        
        


        GameObject skip = GameObject.Instantiate(GameObject.Find("Skip"), vec, eu);
        yield return new WaitForSeconds(2);
        Destroy(skip);
        yield return new WaitForSeconds(1);
        g.turn = true;
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
            if ( !finalclicky[i] &&(num == hand[i].big || num == hand[i].small))
            {
                playable = true;
            }
        }
        return playable;
    }
}
