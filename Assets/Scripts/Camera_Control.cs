using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public float Moving_Speed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.Translate(transform.forward * Time.deltaTime * Moving_Speed);
        //transform.position = target.transform.position;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.transform.position.x, Moving_Speed),
            Mathf.Lerp(transform.position.y, target.transform.position.y, Moving_Speed),
            Mathf.Lerp(transform.position.z, target.transform.position.z, Moving_Speed));
    }
}
