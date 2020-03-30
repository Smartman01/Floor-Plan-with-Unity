using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float desiredAngle = target.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(5f, desiredAngle, 0);
        transform.position = target.position - (rotation * offset);

        transform.LookAt(target);
    }
}
