using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCamera : MonoBehaviour
{
    private int current_w = 0;
    private int current_h = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1.777778f, 1.777778f, 1.777778f);
        SetRes();
        transform.localScale = new Vector3((float)current_w / current_h, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width != current_w || Screen.height != current_h)
        {
            SetRes();
            transform.localScale = new Vector3((float)current_w / current_h, transform.localScale.y, transform.localScale.z);
        }
    }

    private void SetRes()
    {
        current_w = Screen.width;
        current_h = Screen.height;
    }
}
