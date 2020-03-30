using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectNPC : MonoBehaviour
{
    followPlayer fp;

    public Dropdown npcDropdown;

    public GameObject[] NPCs;

    List<string> npcName;

    // Start is called before the first frame update
    void Start()
    {
        npcDropdown = GetComponent<Dropdown>();

        fp = Camera.main.GetComponent<followPlayer>();

        NPCs = GameObject.FindGameObjectsWithTag("NPC");

        npcName = new List<string>();

        foreach (GameObject gb in NPCs)
            npcName.Add(gb.name);

        npcDropdown.ClearOptions();

        npcDropdown.AddOptions(npcName);

        fp.target = GameObject.Find(npcName[0]).transform;

        npcDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(npcDropdown);
        });
    }

    void DropdownValueChanged(Dropdown change)
    {
        Debug.Log(npcName[change.value]);

        fp.target = GameObject.Find(npcName[change.value]).transform;
    }
}
