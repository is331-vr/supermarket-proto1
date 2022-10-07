using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject triggeringNpc;
    private bool triggering;

    public GameObject npcText;

    [SerializeField] private Animator myAnimationController;

    //public Transform target;
    private GameObject player;
  

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {
        if (triggering)
        {
            npcText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //print("Congratulations! Jo Mama");
                npcText.SetActive(false);
                myAnimationController.SetBool("PlayTalk", true);

                transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));


                //DialogueTrigger.TriggerDialogue();
            }
        }
        else
        {
            npcText.SetActive(false);
            myAnimationController.SetBool("PlayTalk", false);
        }
        //print("Player is triggering " + triggeringNpc);

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            triggeringNpc = null;
        }
    }
}