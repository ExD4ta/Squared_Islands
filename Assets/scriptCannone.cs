using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class scriptCannone : MonoBehaviour
{
    private GameObject player;
    private bool scaletrigger = false;

    public void disableScaleTrigger()
    {
        scaletrigger = false;
    }
    public void enableScaleTrigger()
    {
        scaletrigger = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (scaletrigger && player.transform.localScale.x > 0.05f)
        {
            player.transform.localScale -= new Vector3(0.002f, 0.002f, 0.002f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enableScaleTrigger();
        player.GetComponent<movimento>().disableControls();
        player.GetComponent<salto>().disableJump();
    }
}
