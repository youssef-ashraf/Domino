using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
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

    private void OnMouseDown()
    {
        Transform sin = GameObject.Find("Single").transform;
        Transform mult = GameObject.Find("Multi").transform;
        Transform bot1 = GameObject.Find("bot1").transform;
        Transform bot2 = GameObject.Find("bot2").transform;
        Transform bot3 = GameObject.Find("bot3").transform;


        StartCoroutine(moveToPosition(sin, new Vector3(sin.position.x + 0.2f, sin.position.y, sin.position.z), 0.2f, 0));
        StartCoroutine(moveToPosition(mult, new Vector3(mult.position.x - 0.2f, mult.position.y, mult.position.z), 0.2f, 0));
        StartCoroutine(moveToPosition(sin, new Vector3(sin.position.x - 8, sin.position.y, sin.position.z), 1, 0.2f));
        StartCoroutine(moveToPosition(mult, new Vector3(mult.position.x + 8, mult.position.y, mult.position.z), 1, 0.2f));


        StartCoroutine(moveToPosition(bot1, new Vector3(bot1.position.x , bot1.position.y + 9.1f, bot1.position.z), 1, 1.2f));
        StartCoroutine(moveToPosition(bot2, new Vector3(bot2.position.x + 10.2f, bot2.position.y, bot2.position.z), 1, 1.2f));
        StartCoroutine(moveToPosition(bot3, new Vector3(bot3.position.x - 10.2f, bot3.position.y, bot3.position.z), 1, 1.2f));


        StartCoroutine(moveToPosition(bot1, new Vector3(bot1.position.x, bot1.position.y + 9, bot1.position.z), 0.2f, 2.2f));
        StartCoroutine(moveToPosition(bot2, new Vector3(bot2.position.x + 10, bot2.position.y, bot2.position.z), 0.2f, 2.2f));
        StartCoroutine(moveToPosition(bot3, new Vector3(bot3.position.x - 10, bot3.position.y, bot3.position.z), 0.2f, 2.2f));

    }


    IEnumerator moveToPosition(Transform transform, Vector3 position, float time,float wait)
    {
        yield return new WaitForSeconds(wait);
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }


        

    }
}
