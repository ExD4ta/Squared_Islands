using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : menu
{
    public Object oggetto;
    public GameObject playerReference;
    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = oggetto.GetComponent<Transform>().position + new Vector3(11.5f,6,-40);
        gameObject.GetComponent<Camera>().orthographicSize = 6 + Mathf.Abs(playerReference.GetComponent<movimento>().rotazione/150);

    }
}
