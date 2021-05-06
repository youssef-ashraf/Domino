using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onT_L_R : MonoBehaviour
{
    bool choice = true;
    public string cho;
    // Start is called before the first frame update
    void Start()
    {
        
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
        //
        if (choice)
        {
            choice = false;
            var comp = FindObjectOfType<OnTouchDown>();
            
            if(cho == "left")
            {
                comp.left = true;
                comp.choice = true;
                comp.OnMouseDown();
            }

            if (cho == "right")
            {
                comp.right = true;
                comp.choice = true;
                comp.OnMouseDown();
            }


            var gl = GameObject.FindGameObjectsWithTag("Piece");
            var ogl = GameObject.FindGameObjectsWithTag("clone");
            int array1OriginalLength = gl.Length;
            Array.Resize<GameObject>(ref gl, array1OriginalLength + ogl.Length);
            Array.Copy(ogl, 0, gl, array1OriginalLength, ogl.Length);
            foreach (GameObject obj in gl)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            }

            var list1 = FindObjectsOfType<onT_L_R>();
            foreach (Component l in list1)
            {

                Destroy(l);
            }

        }
    }
}
