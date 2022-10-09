using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class NPC : MonoBehaviour
{
    private GameObject triggeringNpc;
    private bool triggering;
    
   
    List<InputDevice> leftHandedControllers = new List<InputDevice>();
    InputDevice device;
    bool deviceSet = false;

    public GameObject npcText;

    [SerializeField] private Animator myAnimationController;
    [SerializeField] XRController controller;

    //public Transform target;
    private GameObject player;



    void Start()
    {

        player = GameObject.Find("XR Origin");
        //Debug.Log(player);
    }


    void Update()
    {
        if (leftHandedControllers.Count<1)
        {
            var desiredCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
            InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);
            
            

        }

        if(leftHandedControllers.Count == 1 && !deviceSet)
        {
            device = leftHandedControllers[0];
            //Debug.Log(device.name + device.characteristics);
            deviceSet = true;
        }

        if (triggering)
        {
            npcText.SetActive(true);
            bool triggerValue;
            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                //Debug.Log("Trigger activated");
                //print("Congratulations! Jo Mama");
                npcText.SetActive(false);
                myAnimationController.SetBool("PlayTalk", true);
                //Debug.Log(player);
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