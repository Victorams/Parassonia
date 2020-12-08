using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private Ray crosshairRay;
    // Start is called before the first frame update

	[SerializeField] private float interactionDistance;

	private LightSwitchScript lightSwitchScript;
	private RaycastHit hit;


    void Start()
    {
        crosshairRay =  new Ray(this.transform.position, this.transform.forward);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
        

		
		
 
			if(Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hit, interactionDistance )){
				// Then you could find your GO with a specific tag by doing something like:
				if(hit.collider.tag == "LightSwitch") {
				    lightSwitchScript = hit.collider.gameObject.GetComponent<LightSwitchScript>();
				    lightSwitchScript.toggleState();
				}else{
				}	
			}
		}
		
    }
}
