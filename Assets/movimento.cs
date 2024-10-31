using ExitGames.Client.Photon.StructWrapping;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class movimento : MonoBehaviour
{
    public GameObject link;
    public GameObject ui;
    public bool canDash;
    public Rigidbody body;
    public float rotazione = 0f;
    public bool DoRotate = false;
    void OnCollisionEnter(Collision collidingObject)
    {
        if (collidingObject.gameObject.tag == "Terrain")
        {
            canDash = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        link = GameObject.Find("Text (TMP)");
    }

    // Update is called once per frame
    void Update()
    { if (DoRotate && canDash)
        {
            body.isKinematic = true;
        }
        else
        {
            body.isKinematic = false;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        transform.localEulerAngles = new Vector3(0f, 0f, transform.localEulerAngles.z);
        if (rotazione < 5f && rotazione > -5f)
        {
            DoRotate = false;
            rotazione = 0f;
        }
        if (rotazione < 0f)
        {
            DoRotate = true;
            rotazione = rotazione + (1000f * Time.deltaTime);
            transform.localEulerAngles = transform.localEulerAngles + (new Vector3(0f, 0f, rotazione) * Time.deltaTime);
        }

        if (rotazione > 0f)
        {
            DoRotate = true;
            rotazione = rotazione - (1000f * Time.deltaTime);
            transform.localEulerAngles = transform.localEulerAngles + (new Vector3(0f, 0f, rotazione) * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            if (body.isKinematic && canDash)
            {
                canDash = false;
                body.isKinematic = false;
                GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(1.5f* Mathf.Abs(rotazione), 400f, 0f), new Vector3(transform.position.x-1, transform.position.y, transform.position.z));
            }
            else if(!(body.isKinematic)&& canDash)
            {
                transform.position = transform.position + (new Vector3(6f, 0, 0) * Time.deltaTime);
            }

        }
        if (Input.GetKey("a"))
        {
            if (body.isKinematic && canDash)
            {
                canDash = false;
                body.isKinematic=false;
                GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(-1.5f * Mathf.Abs(rotazione), 400f, 0f), new Vector3(transform.position.x+1, transform.position.y, transform.position.z));
            }
            else if (!(body.isKinematic) && canDash)
            {
                transform.position = transform.position + (new Vector3(-6f, 0, 0) * Time.deltaTime);
            }
        }
        if (Input.GetKey("e") && rotazione < 1000 && rotazione > -1000 && canDash)
        {
            DoRotate = true;
            rotazione -= (1500f * Time.deltaTime);
        }
        if (Input.GetKey("q") && rotazione < 1000 && rotazione > -1000 && canDash)
        {
            DoRotate = true;
            rotazione += (1500f* Time.deltaTime);
        }

        if(transform.position.y <= -15f)
        {
            link.GetComponent<menu>().resetScore();
            SceneManager.LoadSceneAsync(SceneManager.GetSceneByName("backup").buildIndex);
        }
    }
    public float getRotazione()
    {
        return rotazione;
    }
}
