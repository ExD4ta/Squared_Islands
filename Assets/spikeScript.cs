using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikeScript : MonoBehaviour
{
    public GameObject camera;
    public GameObject link;
    // Start is called before the first frame update
    void Start()
    {
        link = GameObject.Find("Text (TMP)");
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //camera.GetComponent<Camera>().backgroundColor = Color.Lerp(new Color(48f, 136f, 207f),new Color(0f,0f,200f),100f);
        link.GetComponent<menu>().resetScore();
        SceneManager.LoadSceneAsync(SceneManager.GetSceneByName("backup").buildIndex);
    }
}
