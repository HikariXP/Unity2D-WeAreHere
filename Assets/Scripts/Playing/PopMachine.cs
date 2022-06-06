using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopMachine : MonoBehaviour
{
    public GameObject GM;

    public float chance;

    public int RandoM;

    public GameObject Pops;

    void Start()
    {
        GM = GameObject.Find("GM");
        chance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (chance <= 0.5)
        {
            chance += Time.deltaTime;
        }
        else
        {
            RandoM = UnityEngine.Random.Range(0,2);
            if (RandoM > 1)
            {
                Vector3 v3 = new Vector3(transform.position.x, transform.position.y);
                Instantiate(Pops,v3, Quaternion.identity);
                RandoM = 0;
                chance = 0;
            }
        }
    }
}
