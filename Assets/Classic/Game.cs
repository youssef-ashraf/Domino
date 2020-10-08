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
    Piece[] Hand1 = new Piece[7];
    Piece[] Hand2 = new Piece[7];
    Piece[] Hand3 = new Piece[7];
    Piece[] Hand4 = new Piece[7];


    // Start is called before the first frame update
    void Start()
    {
        float start_pos = -2.88f;

        int count = 27;
        for (int i = 6; i >= 0; i--)
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
        for (int i = 0; i <7; i++)
        {
            Hand1[i] = Pieces[i];
        }
        for (int i = 7; i < 14; i++)
        {
            Hand2[i-7] = Pieces[i];
        }
        for (int i = 14; i < 21; i++)
        {
            Hand3[i-14] = Pieces[i];
        }
        for (int i = 21; i < 28; i++)
        {
            Hand4[i-21] = Pieces[i];
        }


        //Visualisation For Hand1
        foreach(Piece x in Hand1)
        {
            var g = GameObject.Find(x.big.ToString() + '_' + x.small.ToString());
            g.transform.position = new Vector3(start_pos, -3.9f, g.transform.position.z);
            start_pos = start_pos + 0.96f;
        }
        start_pos= -2.88f;

        //Visualisation For Hand2
        foreach (Piece x in Hand2)
        {
            var g = GameObject.Find("random");
            GameObject.Instantiate(g, new Vector3(start_pos, 3.9f, g.transform.position.z),Quaternion.identity);
            start_pos = start_pos + 0.96f;
        }


        ////Visualisation For Hand3
        //foreach (Piece x in Hand3)
        //{
        //    var g = GameObject.Find(x.big.ToString() + '_' + x.small.ToString());
        //    g.transform.position = new Vector3(start_pos, -3.9f, g.transform.position.z);
        //    start_pos = start_pos + 0.96f;
        //}


        ////Visualisation For Hand4
        //foreach (Piece x in Hand4)
        //{
        //    var g = GameObject.Find(x.big.ToString() + '_' + x.small.ToString());
        //    g.transform.position = new Vector3(start_pos, -3.9f, g.transform.position.z);
        //    start_pos = start_pos + 0.96f;
        //}


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class Piece
{
   public int big;
   public int small;
}
