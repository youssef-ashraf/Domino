using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_Move : MonoBehaviour
{
    Game_Controler g;
    GameObject game;


    private void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void commit(int up,int down,CPU p)
    {

        p.turn = false;
        game = GameObject.Find("Game_Controler");
        g = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();


        gameObject.GetComponent<SpriteRenderer>().color = Color.white;


        StartCoroutine(flip(1,up,down));
        StartCoroutine(flip2(1, 1, new Vector3(0, 1, 0)));


        
        StartCoroutine(ScaleOverTime(1));


        if (g.begining && g.round == 1)
        {
            g.leftpiece.big = 6;
            g.leftpiece.small = 6;
            g.rightpiece.big = 6;
            g.rightpiece.small = 6;


            if (g.play_num == 3)
                StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
            else if (g.play_num == 4)
                StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));

            StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
            g.rp += 0.72f;
            g.lp -= 0.72f;
            g.right = 6;
            g.left = 6;
            g.begining = false;
            p.setagian(up, down);
        }
        else if (up == down)
        {
            if (g.play_num == 3)
                StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
            else if (g.play_num == 4)
                StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));

            if (up == g.left)
                {
                    g.leftpiece.big = up;
                    g.leftpiece.small = down;

                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                    g.lp -= 0.72f;
                    g.left = up;
                    p.setagian(up, down);
                }
                else
                {
                    g.rightpiece.big = up;
                    g.rightpiece.small = down;

                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                    g.rp += 0.72f;
                    g.right = up;
                    p.setagian(up, down);
                }



        }
        else
        {
            if(up == g.left&&(g.leftpiece.big!=g.leftpiece.small))
            {
                
                g.lp -= 0.24f;
            }
            else if (up == g.right && (g.rightpiece.big != g.rightpiece.small))
            {
                
                g.rp += 0.24f;
            }
            else if (down == g.left && (g.leftpiece.big != g.leftpiece.small))
            {
                
                g.lp -= 0.24f;
            }
            else if (down == g.right && (g.rightpiece.big != g.rightpiece.small))
            {
                
                g.rp += 0.24f;
            }





            if (up == g.left)
            {
                g.leftpiece.big = up;
                g.leftpiece.small = down;
            }
            else if (up == g.right)
            {
                g.rightpiece.big = up;
                g.rightpiece.small = down;
            }
            else if (down == g.left)
            {
                g.leftpiece.big = up;
                g.leftpiece.small = down;
            }
            else if (down == g.right)
            {
                g.rightpiece.big = up;
                g.rightpiece.small = down;
            }





            if (p.s == "2")
            {
                if (up == g.left)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                    StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                    g.lp -= 0.72f;
                    g.left = down;
                    p.setagian(up, down);
                    
                }
                else if (up == g.right)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                    StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.rp += 0.72f;
                    g.right = down;
                    p.setagian(up, down);
                    
                }
                else if (down == g.left)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                    StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.lp -= 0.72f;
                    g.left = up;
                    p.setagian(up, down);
                    
                }
                else if (down == g.right)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                    StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                    g.rp += 0.72f;
                    g.right = up;
                    p.setagian(up, down);
                    
                }
            }
            if (p.s == "3")
            {
                if (up == g.left)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                    StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                    g.lp -= 0.72f;
                    g.left = down;
                    p.setagian(up, down);
                    
                }
                else if (up == g.right)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                    //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.rp += 0.72f;
                    g.right = down;
                    p.setagian(up, down);
                    
                }
                else if (down == g.left)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                    //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.lp -= 0.72f;
                    g.left = up;
                    p.setagian(up, down);
                    
                }
                else if (down == g.right)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                    StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                    g.rp += 0.72f;
                    g.right = up;
                    p.setagian(up, down);
                    
                }
            }

            if (p.s == "4")
            {
                if (up == g.left)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                    StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                    g.lp -= 0.72f;
                    g.left = down;
                    p.setagian(up, down);
                    
                }
                else if (up == g.right)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                    //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.rp += 0.72f;
                    g.right = down;
                    p.setagian(up, down);
                    
                }
                else if (down == g.left)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                    //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.lp -= 0.72f;
                    g.left = up;
                    p.setagian(up, down);
                    
                }
                else if (down == g.right)
                {
                    
                    StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                    StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                    g.rp += 0.72f;
                    g.right = up;
                    p.setagian(up, down);
                    
                }
            }

        }
        
    }

        IEnumerator flip(float time,int up,int down)
    {
        
        float currentTime = 0.0f;
        do
        {
            transform.Rotate(new Vector3(0,1,0) * (90 * Time.deltaTime));
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find(up + "_" + down).GetComponent<SpriteRenderer>().sprite;
    }
    IEnumerator flip2(float time, float wait,Vector3 v)
    {
        yield return new WaitForSeconds(wait);
        float currentTime = 0.0f;
        do
        {
            transform.Rotate(v * (90 * Time.deltaTime));
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }



    IEnumerator ScaleOverTime(float time)
    {
        
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(0.04f, 0.04f, 1);

        float currentTime = 0.0f;
        yield return new WaitForSeconds(2);
        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);


    }


    
    IEnumerator moveToPosition(Transform transform, Vector3 position, float time)
    {
        yield return new WaitForSeconds(2);
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
        g.turn = true;
        
    }
}
