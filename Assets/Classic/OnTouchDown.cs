using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTouchDown : MonoBehaviour
{
    Game_Controler g;
    GameObject game;
    Player p;
    
    private void Start()
    {
        game = GameObject.Find("Game_Controler");
        g = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();
        p = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update ()
    {
        
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i) {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            if (Physics.Raycast(ray, out hit)) {
                hit.transform.gameObject.SendMessage("OnMouseDown");
              }
           }
       }
    }



    public void OnMouseDown()
    {
        int up = int.Parse(gameObject.name.Split('_')[0]);
        int down = int.Parse(gameObject.name.Split('_')[1]);
        p.setagian(up, down);

        StartCoroutine(ScaleOverTime(1));


        if (g.begining && g.round == 1)
        {
            g.leftpiece.big = 6;
            g.leftpiece.small = 6;
            g.rightpiece.big = 6;
            g.rightpiece.small = 6;

            StartCoroutine(moveToPosition(gameObject.transform,new Vector3(g.lp,0, 4.185483f),1));
            g.rp += 0.72f;
            g.lp -= 0.72f;
            g.right = 6;
            g.left = 6;
            g.begining = false;
            //p.setagian(up, down);
        }


        else if (up == down)
        {
            if (up == g.left)
            {
                g.leftpiece.big = up;
                g.leftpiece.small = down;

                StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                g.lp -= 0.72f;
                g.left = up;
               // p.setagian(up, down);
            }
            else
            {
                g.rightpiece.big = up;
                g.rightpiece.small = down;

                StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                g.rp += 0.72f;
                g.right = up;
               // p.setagian(up, down);
            }



        }

        else
        {
            if (up == g.left && (g.leftpiece.big != g.leftpiece.small))
            {
                print("yes");
                g.leftpiece.small = down;
                g.lp -= 0.24f;
            }
            else if (up == g.right && (g.rightpiece.big != g.rightpiece.small))
            {
                g.leftpiece.small = down;
                g.rp += 0.24f;
            }
            else if (down == g.left && (g.leftpiece.big != g.leftpiece.small))
            {
                g.leftpiece.big = up;
                g.lp -= 0.24f;
            }
            else if (down == g.right && (g.rightpiece.big != g.rightpiece.small))
            {
                g.leftpiece.big = up;
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





            if (up==g.left)
            {
                
                StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                StartCoroutine(flip2(1, 0, new Vector3(0, 0, -1)));
                g.lp -= 0.72f;
                g.left = down;
               // p.setagian(up, down);
            }
            else if (up == g.right)
            {
                
                StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                StartCoroutine(flip2(1, 0, new Vector3(0, 0, 1)));
                g.rp += 0.72f;
                g.right = down;
               // p.setagian(up, down);
            }
            else if(down == g.left)
            {
                
                StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.lp, 0, 4.185483f), 1));
                StartCoroutine(flip2(1, 0, new Vector3(0, 0, 1)));
                g.lp -= 0.72f;
                g.left = up;
               // p.setagian(up, down);
            }
            else if(down == g.right)
            {
                
                StartCoroutine(moveToPosition(gameObject.transform, new Vector3(g.rp, 0, 4.185483f), 1));
                StartCoroutine(flip2(1, 0, new Vector3(0, 0, -1)));
                g.rp += 0.72f;
                g.right = up;
               // p.setagian(up, down);
            }
        }
        

        //else if(gameObject.co)
        

    }



    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(0.04f, 0.04f, 1);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        
    }



     IEnumerator moveToPosition(Transform transform, Vector3 position, float time)
    {
        
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
        var list1 = FindObjectsOfType<Clickable>();
        var list2 = FindObjectsOfType<OnTouchDown>();
        foreach (Component l in list1)
        {
            Destroy(l);
        }
        foreach (Component l in list2)
        {
            Destroy(l);
        }
        g.turn = true;
    }


    IEnumerator flip2(float time, float wait, Vector3 v)
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

}