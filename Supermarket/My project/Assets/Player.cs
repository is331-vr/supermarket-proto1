using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject triggeringNpc;
    private bool triggering;

    //public GameObject npcText;

  


    void Start()
    {
    }


    void Update()
    {
        if (triggering)
        {
            //npcText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            { //print("Congratulations! Jo Mama");
          
            }
        } else {
            //npcText.SetActive(false);
          
        }
            //print("Player is triggering " + triggeringNpc);
        
    }


    void OnTriggerEnter(Collider other )
    {
        if(other.tag == "NPC")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = false;
            triggeringNpc = null;
        }
    }
}
