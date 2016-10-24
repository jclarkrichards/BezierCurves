using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bezier : MonoBehaviour
{

    public Transform c0, c1, c2, c3;
    public float timeDuration = 1;
    public bool checkToCalculate = false;
    public float u;
    public Vector3 p0123;
    public bool moving = false;
    public float timeStart;

	void Start()
    {
        List<int> lint = new List<int>();
        lint.Add(2);
        lint.Add(4);
        lint.Add(8);
        lint.Add(13);
        lint.Add(5);
        lint.Add(9);
        //print(lint.Count);
        List<int> lintR = lint.GetRange(1, lint.Count-1);
        List<int> lintL = lint.GetRange(0, lint.Count - 1);
        for (int i = 0; i < lintL.Count; i++)
            print(lintL[i]);
        //print(lint.ToArray());
        //print(lintR.ToArray());
        //print(lintL.ToArray());
    }
	// Update is called once per frame
	void Update ()
    {
        if(checkToCalculate)
        {
            checkToCalculate = false;
            moving = transform;
            timeStart = Time.time;
        }

        if (moving)
        {
            u = (Time.time - timeStart) / timeDuration;
            if (u >= 1)
            {
                u = 1;
                moving = false;
            }
            //4-point Bezier curve calculation
            Vector3 p01, p12, p23, p012, p123;
            p01 = (1 - u) * c0.position + u * c1.position;
            p12 = (1 - u) * c1.position + u * c2.position;
            p23 = (1 - u) * c2.position + u * c3.position;
            p012 = (1 - u) * p01 + u * p12;
            p123 = (1 - u) * p12 + u * p23;
            p0123 = (1 - u) * p012 + u * p123;
            transform.position = p0123;
        }
	
	}
}
