using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void do_it(int p,int c1,int c2,int c3)
    {
        GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text = "Player      " + p + "\nBot 1        " + c1 + "\nBot 2        " + c2 + "\nBot 3        " + c3;
        StartCoroutine(ScaleOverTime(0.5f));
        
    }


    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(2, 2, 1);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);


    }
}
