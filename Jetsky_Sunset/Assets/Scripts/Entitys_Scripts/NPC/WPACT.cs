using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPACT : MonoBehaviour
{
    public float speed = 5.0f;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoints")
        {
            target = other.gameObject.GetComponent<Waypoints>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }


}