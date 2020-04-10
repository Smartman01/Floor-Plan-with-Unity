using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class situationsController : MonoBehaviour
{
    Dropdown dropdown;

    [SerializeField]
    GameObject[] npc;
    
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();

        npc = GameObject.FindGameObjectsWithTag("NPC");

        dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(dropdown);
        });
    }

    private void DropdownValueChanged(Dropdown dropdown)
    {
        foreach (GameObject n in npc)
        {
            NPC_Controller controller = n.GetComponent<NPC_Controller>();

            if (dropdown.value != 0)
                controller.normalSituation = false;
            else
                controller.normalSituation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
