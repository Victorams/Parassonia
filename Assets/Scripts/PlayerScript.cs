using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private Ray crosshairRay;
    // Start is called before the first frame update

	private LightSwitchScript lightSwitchScript;

    void Start()
    {
        crosshairRay =  new Ray(this.transform.position, this.transform.forward);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed primary button.");
        }



        RaycastHit hit;
		if (Physics.Raycast(crosshairRay, out hit))
		{
		    if (hit.collider.tag.Equals("LightSwitch"))
		    {
		         // hit player
		    }
		 
		}
    }
}
