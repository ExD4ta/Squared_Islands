using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
    
{
    bool canJump = true;
    bool unlock = true;
    public void disableJump()
    {
        unlock = false;
    }
    public void enableJump()
    {
        unlock = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && unlock)
        {
            jump();
        }
    }

    void jump()
    {
        if (canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0f, 400f, 0f), new Vector3(transform.position.x, transform.position.y-1, transform.position.z));
            
        }
    }

    void OnCollisionEnter(Collision collidingObject)
    {
        if (collidingObject.gameObject.tag == "Terrain" && unlock)
        {
            canJump = true;
        }
    }
}
