using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngineInternal;

public class Game : MonoBehaviour
{
    Piece[] Pieces = new Piece[28];
    public Piece[] Hand1 = new Piece[7];
    public Piece[] Hand2 = new Piece[7];
    public Piece[] Hand3 = new Piece[7];
    public Piece[] Hand4 = new Piece[7];

    public GameObject[] Hand1_rand = new GameObject[7];
    public GameObject[] Hand2_rand = new GameObject[7];
    public GameObject[] Hand3_rand = new GameObject[7];
    public GameObject[] Hand4_rand = new GameObject[7];


    // Start is called before the first frame update
    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        float start_pos = -2.88f;
        int i = 0;
        int count = 27;
        for ( i = 6; i >= 0; i--)
            for (int j = i; j >= 0; j--,count--)
            {
                Pieces[count] = new Piece();
                Pieces[count].big = i;
                Pieces[count].small = j;

            }


        //Shuffling
        System.Random rnd = new System.Random();
        Pieces = Pieces.OrderBy(x => rnd.Next()).ToArray();


        
        //Distribution
        for ( i = 0; i <7; i++)
        {
            Hand1[i] = Pieces[i];
        }
        for ( i = 7; i < 14; i++)
        {
            Hand2[i-7] = Pieces[i];
        }
        for ( i = 14; i < 21; i++)
        {
            Hand3[i-14] = Pieces[i];
        }
        for ( i = 21; i < 28; i++)
        {
            Hand4[i-21] = Pieces[i];
        }


        i = 0;
        //Visualisation For Hand1
        foreach (Piece x in Hand1)
        {
            var g = GameObject.Find(x.big.ToString() + '_' + x.small.ToString());
            Hand1_rand[i] = g;
            g.transform.position = new Vector3(start_pos, -3.9f, g.transform.position.z);
            start_pos = start_pos + 0.96f;
            i++;
        }
        start_pos= -2.88f;


         i = 0;
        //Visualisation For Hand2
        foreach (Piece x in Hand2)
        {   
            var g = GameObject.Find("random");
            Hand2_rand[i] = GameObject.Instantiate(g, new Vector3(start_pos, 3.9f, g.transform.position.z), Quaternion.identity);
            Hand2_rand[i].tag = "clone";
            start_pos = start_pos + 0.96f;
            i++;
        }
        start_pos = -2.88f;


        i = 0;
        //Visualisation For Hand3
        foreach (Piece x in Hand3)
        {
            var g = GameObject.Find("random");
            Hand3_rand[i] = GameObject.Instantiate(g, new Vector3(-7.8f, start_pos, g.transform.position.z), Quaternion.Euler(0,0,90));
            Hand3_rand[i].tag = "clone";
            start_pos = start_pos + 0.96f;
            i++;
        }
        start_pos = -2.88f;


        i = 0;
        //Visualisation For Hand4
        foreach (Piece x in Hand4)
        {
            var g = GameObject.Find("random");
            Hand4_rand[i] = GameObject.Instantiate(g, new Vector3(7.8f, start_pos, g.transform.position.z), Quaternion.Euler(0, 0, 90));
            Hand4_rand[i].tag = "clone";
            start_pos = start_pos + 0.96f;
            i++;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Piece
{
   public int big;
   public int small;
}
