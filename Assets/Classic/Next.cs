using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    Game_Controler g;
    // Start is called before the first frame update
    void Start()
    {
        g = FindObjectOfType<Game_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SendMessage("OnMouseDown");
                }
            }
        }
    }



    public void OnMouseDown()
    {
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach(GameObject clone in clones)
        {
            Destroy(clone);
        }

        var pieces = GameObject.FindGameObjectsWithTag("Piece");
        foreach (GameObject piece in pieces)
        {
            piece.transform.position = new Vector3(12,4,0);
            piece.transform.rotation = new Quaternion(0, 0, 0, 0);
            piece.transform.localScale = new Vector3(0.08f, 0.08f, 1);
        }
        FindObjectOfType<Game>().Awake();
        g.round++;
        g.left = new int(); g.right = new int();
        g.timer = 0;
        g.turn_num = 0;
        g.lefty = null;
        g.righty = null;


        var pl = FindObjectOfType<Player>();
        pl.clicky = new bool[7];
        pl.finalclicky = new bool[7];
        pl.Start();

    var cpus = FindObjectsOfType<CPU>();
        for(int i = 0;i<3;i++)
        {
            cpus[i].clicky = new bool[7];
            cpus[i].finalclicky = new bool[7];
            cpus[i].Start();
        }

        if(g.winner =="pl")
        {
            g.play_num = 1;
        }
        else if (g.winner == "c2")
        {
            g.play_num = 2;
        }
        else if (g.winner == "c3")
        {
            g.play_num = 3;
        }
        else if (g.winner == "c4")
        {
            g.play_num = 4;
        }
        

        GameObject.Find("Scoreboard").transform.localScale = new Vector3(0,0,1);
        gameObject.transform.localScale = new Vector3(0, 0, 1);
        
        


        g.Start();
        g.checker = true;
        //if (g.winner == "pl")
        //{
            
        //    pl.turn = true;
        //}
        //else if (g.winner == "c2")
        //{
        //    cpus[0].turn = true;
        //}
        //else if (g.winner == "c3")
        //{
        //    cpus[1].turn = true;
        //}
        //else if (g.winner == "c4")
        //{
        //    cpus[2].turn = true;
        //}

    }

    public void grow()
    {
        StartCoroutine(ScaleOverTime(0.5f));
    }


    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(0.8f, 0.8f, 1);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);


    }

}
