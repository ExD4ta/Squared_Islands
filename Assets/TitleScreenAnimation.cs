using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenAnimation : MonoBehaviour
{
    private GameObject spinning_platform;
    private GameObject dissolve;
    // Start is called before the first frame update
    void Start()
    {
        spinning_platform = GameObject.Find("title_platform");
        dissolve = GameObject.Find("RawImage");
    }

    // Update is called once per frame
    void Update()
    {
        spinning_platform.transform.Rotate(0f, 0f, 150f * Time.deltaTime);
        if(dissolve.GetComponent<RawImage>().color != new Color(0f, 0f, 0f, 0f))
        {
            dissolve.GetComponent<RawImage>().color = new Color(0f, 0f, 0f, dissolve.GetComponent<RawImage>().color.a - (0.2f * Time.deltaTime));
        }
    }
}
