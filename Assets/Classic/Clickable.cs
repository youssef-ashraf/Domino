using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    int going=100;
    bool isgoing = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isgoing)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r - 0.01f, gameObject.GetComponent<SpriteRenderer>().color.g - 0.01f, gameObject.GetComponent<SpriteRenderer>().color.b - 0.01f);
            going -= 1;
            if (going == 0)
            {
                isgoing = false;
            }
        }
        if(!isgoing)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r + 0.01f, gameObject.GetComponent<SpriteRenderer>().color.g + 0.01f, gameObject.GetComponent<SpriteRenderer>().color.b + 0.01f);
            going += 1;
            if (going == 100)
            {
                isgoing = true;
            }
        }

    }
}
