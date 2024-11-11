using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class generazione : MonoBehaviour
{
    public GameObject trigger;
    public GameObject cannone;
    public GameObject spike;
    public GameObject blocchi;
    public GameObject bordi;
    public int value;
    public String seed;
    public GameObject piattaforma;
    public GameObject moneta;
    public GameObject backround;
    private GameObject backroundRef;
    public Material backroundMaterial;
    private float backroundScale;
    // Start is called before the first frame update
    void Start()
    {
        backroundMaterial.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        cannone.tag = "Terrain";
        piattaforma.tag = "Terrain";
        int i = 0;
        while (i != 2)
        {

            if (Random.Range(0f, 1f) > 0.6f)
            {
                if(Random.Range(0f, 1f) > 0.05f) {
                Instantiate(blocchi, new Vector3((i + 1) * 4.25f, transform.position.y, transform.position.z), transform.localRotation);
                Instantiate(bordi, new Vector3(((i + 1) * 4.25f) + 2.9f, transform.position.y, transform.position.z), transform.localRotation);
                Instantiate(bordi, new Vector3(((i + 1) * 4.25f) - 2.9f, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(-90f, 180f, 0f)));
                    if (Random.Range(0, 100) < 50)
                    {
                        Instantiate(moneta, new Vector3(((i + 1) * 4.25f), transform.position.y + 2.75f, transform.position.z), transform.localRotation);
                    }
                    if (Random.Range(0, 100) < 50)
                    {
                        Instantiate(spike, new Vector3(((i + 1) * 4.25f) + 0.6f, transform.position.y - 0.1f, transform.position.z), Quaternion.Euler(new Vector3(90f, 0, 7f))).AddComponent<spikeScript>().AddComponent<BoxCollider>().size = new Vector3(0.2f, 2.5f, 2.5f);
                        Instantiate(spike, new Vector3(((i + 1) * 4.25f), transform.position.y, transform.position.z), transform.localRotation).AddComponent<spikeScript>().AddComponent<BoxCollider>().size = new Vector3(0.7f, 2.5f, 2.5f);
                        Instantiate(spike, new Vector3(((i + 1) * 4.25f) - 0.5f, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0f, 0, 0f))).AddComponent<spikeScript>().AddComponent<BoxCollider>().size = new Vector3(0.7f, 2.5f, 2.5f);
                    }
                }

                


            }
            else if (Random.Range(0f, 1f) < 0.60f)
            {
                if (Random.Range(0, 100) < 75)
                {
                    Instantiate(piattaforma, new Vector3((i + 1) * 4.25f, transform.position.y + 2, transform.position.z), transform.localRotation).AddComponent<BoxCollider>();
                    if (Random.Range(0, 100) < 40)
                    {
                        Instantiate(moneta, new Vector3(((i + 1.05f) * 4.25f), transform.position.y + 4.5f, transform.position.z), transform.localRotation);
                    }
                }
            }
            if (Random.Range(0f, 1f) > 0.3f)
            {
                backroundScale = Random.Range(1, 3);
                backroundRef = Instantiate(backround, new Vector3((((i + 1) * 4.25f) + Random.Range(3f, 6f)), transform.position.y + Random.Range(-4f, 8f), transform.position.z + Random.Range(8f, 24f)), transform.localRotation);
                backroundRef.transform.localScale = new Vector3(backroundRef.transform.localScale.x * backroundScale, backroundRef.transform.localScale.y * backroundScale, backroundRef.transform.localScale.z* backroundScale);
                backroundRef.GetComponent<Renderer>().material = backroundMaterial;
            }
            i++;
        }
        Instantiate(trigger, new Vector3((i + 1) * 4.25f, transform.position.y +0.35f, transform.position.z), transform.localRotation).AddComponent<scriptCannone>().AddComponent<BoxCollider>().isTrigger = true;
        Instantiate(cannone, new Vector3((i + 1) * 4.25f, transform.position.y, transform.position.z), transform.localRotation).AddComponent<MeshCollider>();
        Instantiate(bordi, new Vector3(((i + 1) * 4.25f) + 2.9f, transform.position.y, transform.position.z), transform.localRotation);
        Instantiate(bordi, new Vector3(((i + 1) * 4.25f) - 2.9f, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(-90f, 180f, 0f)));
    }
    // Update is called once per frame
    void Update()

    {

    }
}