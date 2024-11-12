using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour
{
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start && transform.position.y < 2000f)
        {
            transform.position += new Vector3(0f,3f,0f);
        }
        else
        {
            TransitionStop();
        }
    }

    public void TransitionStart()
    {
        start = true; 
    }
    public void TransitionStop()
    {
        start = false;
    }
}
