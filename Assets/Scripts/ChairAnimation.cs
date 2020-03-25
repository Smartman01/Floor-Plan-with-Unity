using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAnimation : MonoBehaviour
{
    Animator anim;

    public Transform sitPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        anim.SetBool("Turn_In", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Turn_In", false);
    }
}
