using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    Player p;
    
    // Start is called before the first frame update
    void Start()
    {
        p = FindObjectOfType<Player>();
        for (int i = 0; i < 7; i++)
        {
            if(!p.finalclicky[i])
            {
                p.hand_graph[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);



    }
    

}
