using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            transform.position += new Vector3(0f, 2000f * Time.deltaTime, 0f);
        }
        else if (start && transform.position.y > 2000f)
        {
            TransitionStop();
            SceneManager.LoadScene("ui");
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
