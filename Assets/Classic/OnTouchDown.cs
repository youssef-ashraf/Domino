using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class OnTouchDown : MonoBehaviour
{
    Game_Controler g;
    GameObject game;
    Player p;
    public bool left, right;
    public bool choice = true;

    private void Start()
    {
        left = true;
        right = true;
        game = GameObject.Find("Game_Controler");
        g = GameObject.Find("Game_Controler").GetComponent<Game_Controler>();
        p = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {

        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i) 
        {
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
        if (choice)
        {


            choice = false;


            int up = int.Parse(gameObject.name.Split('_')[0]);
            int down = int.Parse(gameObject.name.Split('_')[1]);
            

            StartCoroutine(ScaleOverTime(1));

            if (((up == g.left && up == g.right) || (down == g.left && down == g.right) || (up == g.left && down == g.right) || (down == g.left && up == g.right)) && (g.left != g.right) && left && right)
            {
                //print(g.left != g.right);
                var gl = GameObject.FindGameObjectsWithTag("Piece");
                var ogl = GameObject.FindGameObjectsWithTag("clone");
                int array1OriginalLength = gl.Length;
                Array.Resize<GameObject>(ref gl, array1OriginalLength + ogl.Length);
                Array.Copy(ogl, 0, gl, array1OriginalLength, ogl.Length);
                foreach (GameObject obj in gl)
                {
                    obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

                }


                var list1 = FindObjectsOfType<Clickable>();
                var list2 = FindObjectsOfType<OnTouchDown>();
                foreach (Component l in list1)
                {
                    
                    Destroy(l);
                }
                foreach (Component l in list2)
                {
                    if (l != gameObject.GetComponent<OnTouchDown>())
                        Destroy(l);
                }




                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                g.lefty.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                g.righty.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                g.lefty.AddComponent<onT_L_R>().cho = "left";
                g.righty.AddComponent<onT_L_R>().cho = "right";
                left = false;
                right = false;
                
            }

            else
            {
                p.setagian(up, down);
            }

            if (g.begining && g.round == 1)
            {
                g.lefty = gameObject;
                g.righty = gameObject;
                g.leftpiece.big = 6;
                g.leftpiece.small = 6;
                g.rightpiece.big = 6;
                g.rightpiece.small = 6;

                StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                g.V_left.x -= 0.72f;
                g.V_right.x += 0.72f;
                g.right = 6;
                g.left = 6;
                g.begining = false;
                //
                
            }


            else if (g.begining)
            {
                g.lefty = gameObject;
                g.righty = gameObject;
                g.leftpiece.big = up;
                g.leftpiece.small = down;
                g.rightpiece.big = up;
                g.rightpiece.small = down;

                StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                g.V_left.x -= 0.72f;
                g.V_right.x += 0.72f;
                g.right = up;
                g.left = down;
                g.begining = false;
                //
            }



            else if (up == down)
            {
                //print(g.left_played + " " + g.right_played);


                if (up == g.left && left)
                {
                    g.lefty = gameObject;

                    if (g.left_played == 5)
                    {
                        g.V_left.x += 0.48f;
                        g.V_left.y += 0.48f;
                    }




                    if (g.left_played < 5)
                    {
                        g.left_played++;
                        g.leftpiece.big = up;
                        g.leftpiece.small = down;

                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        g.V_left.x -= 0.72f;
                        g.left = up;
                        // 
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        //print("l true");
                        //if (g.left_played == 6)
                        //{
                        //    g.V_left.x -= 0.48f;
                        //}

                        g.left_played++;
                        g.leftpiece.big = up;
                        g.leftpiece.small = down;

                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, -1)));

                        g.V_left.y += 0.72f;
                        g.left = up;
                    }
                    if (g.left_played > 6)
                    {
                        if (g.left_played == 7)
                        {
                            g.V_left.x += 0.48f;
                            g.V_left.y -= 0.48f;
                        }

                        g.left_played++;
                        g.leftpiece.big = up;
                        g.leftpiece.small = down;

                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        g.V_left.x += 0.72f;
                        g.left = up;
                        // 
                    }
                }
                else if (right)
                {
                    g.righty = gameObject;
                    if (g.right_played == 5)
                    {
                        g.V_right.x -= 0.48f;
                        g.V_right.y -= 0.48f;
                    }





                    if (g.right_played < 5)
                    {
                        g.right_played++;
                        g.rightpiece.big = up;
                        g.rightpiece.small = down;

                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        g.V_right.x += 0.72f;
                        g.right = up;
                        // 
                    }


                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        //if (g.right_played == 6)
                        //{
                        //    g.V_right.x += 0.48f;
                        //}
                        //print("r true");
                        g.right_played++;
                        g.rightpiece.big = up;
                        g.rightpiece.small = down;

                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, -1)));

                        g.V_right.y -= 0.72f;
                        g.right = up;
                    }
                    else if (g.right_played > 6)
                    {
                        if (g.right_played == 7)
                        {
                            g.V_right.x -= 0.48f;
                            g.V_right.y += 0.48f;
                        }

                        g.right_played++;
                        g.rightpiece.big = up;
                        g.rightpiece.small = down;

                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        g.V_right.x -= 0.72f;
                        g.right = up;
                        // 
                    }
                }



            }

            else
            {








                /////////////////////////////////////////////////////////////////////////////////////////////






















                if (up == g.left && left)
                {
                    g.lefty = gameObject;
                    if (g.left_played < 5)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, -1)));
                        g.V_left.x -= 0.72f;
                        g.left = down;
                        // 
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, 2)));
                        g.V_left.y += 0.72f;
                        g.left = down;
                    }
                    else if (g.left_played > 6)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, 1)));
                        g.V_left.x += 0.72f;
                        g.left = down;

                    }
                }
                else if (up == g.right && right)
                {
                    g.righty = gameObject;
                    if (g.right_played < 5)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, 1)));
                        g.V_right.x += 0.72f;
                        g.right = down;
                        // 
                    }
                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_right.y -= 0.72f;
                        g.right = down;
                    }
                    else if (g.right_played > 6)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, -1)));
                        g.V_right.x -= 0.72f;
                        g.right = down;

                    }
                }
                else if (down == g.left && left)
                {
                    g.lefty = gameObject;
                    if (g.left_played < 5)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, 1)));
                        g.V_left.x -= 0.72f;
                        g.left = up;
                        // 
                    }
                    else if (g.left_played > 4 && g.left_played < 7)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        //StartCoroutine(flip2(1, 2, new Vector3(0, 0, 2)));
                        g.V_left.y += 0.72f;
                        g.left = up;

                    }
                    else if (g.left_played > 6)
                    {
                        checkleft(up, down);
                        g.left_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_left, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, -1)));
                        g.V_left.x += 0.72f;
                        g.left = up;

                    }
                }
                else if (down == g.right && right)
                {
                    g.righty = gameObject;
                    if (g.right_played < 5)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, -1)));
                        g.V_right.x += 0.72f;
                        g.right = up;
                        // 
                    }
                    else if (g.right_played > 4 && g.right_played < 7)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, 2)));
                        g.V_right.y -= 0.72f;
                        g.right = up;

                    }
                    else if (g.right_played > 6)
                    {
                        checkright(up, down);
                        g.right_played++;
                        StartCoroutine(moveToPosition(gameObject.transform, g.V_right, 1));
                        StartCoroutine(flip2(1, 0, new Vector3(0, 0, 1)));
                        g.V_right.x -= 0.72f;
                        g.right = up;

                    }
                }
            }



            //else if(gameObject.co)
            //print("me " + g.V_left + "    " + g.V_right);
            
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
            var list1 = FindObjectsOfType<Clickable>();
            var list2 = FindObjectsOfType<OnTouchDown>();
            foreach (Component l in list1)
            {
                Destroy(l);
            }
            foreach (Component l in list2)
            {
                if(l != gameObject.GetComponent<OnTouchDown>())
                    Destroy(l);
            }

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

            Destroy(gameObject.GetComponent<OnTouchDown>());



            

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
            ///////////////////////////////////////////////////////////////////////////////////////

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

        

    }


}
