using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoteMovement : MonoBehaviour
{
    public Rigidbody theRRB;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180, speedInput;

    public bool b_enableControls;

    private float turnInput;

    // Start is called before the first frame update
    void Start()
    {
        b_enableControls = false;
        theRRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_enableControls == true)
        {
            speedInput = 0f;

            if (Input.GetAxis("Vertical") > 0)
            {
                speedInput = Input.GetAxis("Vertical") * forwardAccel * 50;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                speedInput = Input.GetAxis("Vertical") * reverseAccel * 50;
            }

            turnInput = Input.GetAxis("Horizontal");

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));

            transform.position = theRRB.transform.position;
        }
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(speedInput) > 0)
        {
            theRRB.AddForce(transform.forward * speedInput);
        }
    }
}
