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
            g.lefty = gameObject;
            g.righty = gameObject;
            g.leftpiece.big = 6;
            g.leftpiece.small = 6;
            g.rightpiece.big = 6;
            g.rightpiece.small = 6;


            if (g.play_num == 3)
                StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
            else if (g.play_num == 4)
                StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));

            StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
            g.right = 6;
            g.left = 6;
            g.begining = false;
            p.setagian(up, down);
            g.V_left.x -= 0.72f;
            g.V_right.x += 0.72f;
        }
        else if(g.begining)
        {
            g.lefty = gameObject;
            g.righty = gameObject;
            g.leftpiece.big = up;
            g.leftpiece.small = down;
            g.rightpiece.big = up;
            g.rightpiece.small = down;


            if (g.play_num == 3)
                StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
            else if (g.play_num == 4)
                StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));

            StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
            g.right = up;
            g.left = down;
            g.begining = false;
            p.setagian(up, down);
            g.V_left.x -= 0.72f;
            g.V_right.x += 0.72f;
        }

        else if (up == down)
        {
            //print(g.left_played + " "+ g.right_played);
            if (up == g.left)
            {
                g.lefty = gameObject;

                if (g.left_played == 5 )
                {
                    g.V_left.x += 0.48f;
                    g.V_left.y += 0.48f;
                }
                


                



                if (g.left_played < 5)
                {
                    g.left_played++;

                    if (g.play_num == 3)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                    else if (g.play_num == 4)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.leftpiece.big = up;
                    g.leftpiece.small = down;

                    StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                    g.V_left.x -= 0.72f;
                    g.left = up;
                    p.setagian(up, down);
                }

                else if (g.left_played > 4 && g.left_played < 7)
                {
                    //if(g.left_played == 6)
                    //{
                    //    g.V_left.x -= 0.48f;
                    //}

                    //print("r true");
                    g.left_played++;
                    g.leftpiece.big = up;
                    g.leftpiece.small = down;

                    StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                    if (g.play_num == 2)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));

                    g.V_left.y += 0.72f;
                    g.left = up;
                    p.setagian(up, down);
                }
                else if (g.left_played > 6)
                {
                    if (g.left_played == 7)
                    {
                        g.V_left.x += 0.48f;
                        g.V_left.y -= 0.48f;
                    }

                        g.left_played++;

                    if (g.play_num == 3)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                    else if (g.play_num == 4)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.leftpiece.big = up;
                    g.leftpiece.small = down;

                    StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                    g.V_left.x += 0.72f;
                    g.left = up;
                    p.setagian(up, down);
                }

            }
            else
            {
                g.righty = gameObject;
                if (g.right_played == 5 )
                {
                    g.V_right.x -= 0.48f;
                    g.V_right.y -= 0.48f;
                }
                


                if (g.right_played < 5)
                {
                    g.right_played++;
                    if (g.play_num == 3)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                    else if (g.play_num == 4)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.rightpiece.big = up;
                    g.rightpiece.small = down;

                    StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                    g.V_right.x += 0.72f;
                    g.right = up;
                    p.setagian(up, down);
                }

                else if (g.right_played > 4 && g.right_played < 7)
                {
                    //if (g.right_played == 6)
                    //{
                    //    g.V_right.x += 0.48f;
                    //}
                    //print("l true");
                    g.right_played++;
                    g.rightpiece.big = up;
                    g.rightpiece.small = down;

                    StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                    if (g.play_num == 2)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));

                    g.V_right.y -= 0.72f;
                    g.right = up;
                    p.setagian(up, down);
                }
                else if (g.right_played > 6)
                {
                    if (g.right_played == 7)
                    {
                        g.V_right.x -= 0.48f;
                        g.V_right.y += 0.48f;
                    }

                    g.right_played++;
                    if (g.play_num == 3)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                    else if (g.play_num == 4)
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                    g.rightpiece.big = up;
                    g.rightpiece.small = down;

                    StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                    g.V_right.x -= 0.72f;
                    g.right = up;
                    p.setagian(up, down);
                }


            }



        }
        else
        {
            














            if (p.s == "2")
            {
                if (up == g.left)
                {
                    g.lefty = gameObject;
                    if (g.left_played < 5)
                    {

                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                        g.V_left.x -= 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_left.y += 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 6)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_left.x += 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                    
                }
                else if (up == g.right)
                {
                    g.righty = gameObject;
                    if (g.right_played < 5)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_right.x += 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_right.y -= 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 6)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                        g.V_right.x -= 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                }
                else if (down == g.left)
                {
                    g.lefty = gameObject;
                    if (g.left_played < 5)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_left.x -= 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        checkleft(up,down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_left.y += 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }

                    else if (g.left_played > 6)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                        g.V_left.x += 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }


                }
                else if (down == g.right)
                {
                    g.righty = gameObject;
                    if (g.right_played < 5)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                        g.V_right.x += 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        checkright(up,down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_right.y -= 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }

                    else if (g.right_played > 6)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_right.x -= 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }
                }
            }
 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (p.s == "3")
            {
                if (up == g.left)
                {
                    g.lefty = gameObject;
                    if (g.left_played < 5)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_left.x -= 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        checkleft(up,down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_left.y += 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 6)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -2)));
                        g.V_left.x += 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                }
                else if (up == g.right)
                {
                    g.righty = gameObject;
                    if (g.right_played < 5)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_right.x += 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                        g.V_right.y -= 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 6)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_right.x -= 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                }
                else if (down == g.left)
                {
                    g.lefty = gameObject;
                    if (g.left_played < 5)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_left.x -= 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                        g.V_left.y += 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 6)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_left.x += 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }
                }
                else if (down == g.right)
                {
                    g.righty = gameObject;
                    if (g.right_played < 5)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_right.x += 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        checkright(up,down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_right.y -= 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }
                    if (g.right_played > 6)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -2)));
                        g.V_right.x -= 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }
                }
            }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (p.s == "4")
            {
                if (up == g.left)
                {
                    g.lefty = gameObject;
                    if (g.left_played < 5)
                    {
                        checkleft(up,down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_left.x -= 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_left.y += 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 6)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -2)));
                        g.V_left.x += 0.72f;
                        g.left = down;
                        p.setagian(up, down);
                    }
                }
                else if (up == g.right)
                {
                    g.righty = gameObject;
                    if (g.right_played < 5)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_right.x += 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        checkright(up,down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                        g.V_right.y -= 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 6)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_right.x -= 0.72f;
                        g.right = down;
                        p.setagian(up, down);
                    }
                }
                else if (down == g.left)
                {
                    g.lefty = gameObject;
                    if (g.left_played < 5)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_left.x -= 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        checkleft(up,down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 1)));
                        g.V_left.y += 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }
                    else if (g.left_played > 6)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_left.x += 0.72f;
                        g.left = up;
                        p.setagian(up, down);
                    }
                }
                else if (down == g.right)
                {
                    g.righty = gameObject;
                    if (g.right_played < 5)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_right.x += 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        checkright(up,down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 2, new Vector3(0, 0, -1)));
                        g.V_right.y -= 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }
                    else if (g.right_played > 6)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, -2)));
                        g.V_right.x -= 0.72f;
                        g.right = up;
                        p.setagian(up, down);
                    }
                }
            }

        }



        //print("cpu "+ p.s +" ,turn "+g.turn_num+": "+ g.V_left + "      " + g.V_right);
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

        var vec = transform.eulerAngles;
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;
        transform.eulerAngles = vec;
        g.turn = true;
        
        
    }

    void checkleft(int up, int down)
    {
        if (up == g.left && (g.leftpiece.big != g.leftpiece.small) && g.left_played < 5)
        {

            g.V_left.x -= 0.24f;
        }
        else if (down == g.left && (g.leftpiece.big != g.leftpiece.small) && g.left_played < 5)
        {

            g.V_left.x -= 0.24f;

        }
        else if (up == g.left && (g.leftpiece.big != g.leftpiece.small) && g.left_played > 6)
        {
            // print("true1");
            g.V_left.x += 0.24f;
        }
        else if (down == g.left && (g.leftpiece.big != g.leftpiece.small) && g.left_played > 6)
        {
            //print("true3");
            g.V_left.x += 0.24f;
        }
        //////////////////////////////////////////////////////////////////////////
        

        if (g.left_played == 5)
        {
            if (g.leftpiece.big == g.leftpiece.small)
            {
                g.V_left.x += 0.72f;
                g.V_left.y += 0.96f;
            }
            else
            {
                g.V_left.x += 0.48f;
                g.V_left.y += 0.72f;
            }


        }
        else if (g.left_played == 6 && g.leftpiece.big != g.leftpiece.small)
        {
            g.V_left.y += 0.24f;
        }

        else if (g.left_played == 7)
        {
            if (g.leftpiece.big == g.leftpiece.small)
            {
                g.V_left.x += 0.96f;
                g.V_left.y -= 0.72f;
            }
            else
            {
                g.V_left.x += 0.48f;
                g.V_left.y -= 0.48f;
            }


        }


        if (up == g.left)
        {

            g.leftpiece.big = up;
            g.leftpiece.small = down;
        }

        else if (down == g.left)
        {

            g.leftpiece.big = up;
            g.leftpiece.small = down;
        }
    }

    void checkright(int up, int down)
    {

        if (up == g.right && (g.rightpiece.big != g.rightpiece.small) && g.right_played < 5)
        {

            g.V_right.x += 0.24f;
        }



        else if (down == g.right && (g.rightpiece.big != g.rightpiece.small) && g.right_played < 5)
        {

            g.V_right.x += 0.24f;

        }
        else if (up == g.right && (g.rightpiece.big != g.rightpiece.small) && g.right_played > 6)
        {
            //print("true2");
            g.V_right.x -= 0.24f;
        }

        else if (down == g.right && (g.rightpiece.big != g.rightpiece.small) && g.right_played > 6)
        {
            //print("true4");
            g.V_right.x -= 0.24f;
        }
        /////////////////////////////////////////////////////////////////////////////////

        if (g.right_played == 5)
        {
            if (g.rightpiece.big == g.rightpiece.small)
            {
                g.V_right.x -= 0.72f;
                g.V_right.y -= 0.96f;
            }
            else
            {
                g.V_right.x -= 0.48f;
                g.V_right.y -= 0.72f;
            }


        }




        else if (g.right_played == 6 && g.rightpiece.big != g.rightpiece.small)
        {
            g.V_right.y -= 0.24f;
        }

        else if (g.right_played == 7)
        {
            if (g.rightpiece.big == g.rightpiece.small)

            {
                g.V_right.x -= 0.96f;
                g.V_right.y += 0.72f;
            }
            else
            {
                g.V_right.x -= 0.48f;
                g.V_right.y += 0.48f;
            }


        }


        if (up == g.right)
        {

            g.rightpiece.big = up;
            g.rightpiece.small = down;
        }
        else if (down == g.right)
        {

            g.rightpiece.big = up;
            g.rightpiece.small = down;
        }
    }


    public void flipper(int up, int down)
    {
        StartCoroutine(flip(1, up, down));
        StartCoroutine(flip2(1, 1, new Vector3(0, 1, 0)));
    }
    
}
