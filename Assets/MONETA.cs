using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MONETA : menu
{
    [Serialize]
    public GameObject link;
    // Start is called before the first frame update
    void Start()
    {
        link = GameObject.Find("Text (TMP)");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = transform.localEulerAngles + (new Vector3(0f, 200f, 0f) * Time.deltaTime);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        link.GetComponent<menu>().scorePlusOne();
        Destroy(gameObject);
    }
}
