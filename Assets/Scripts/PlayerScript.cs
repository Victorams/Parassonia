using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private CharacterController pController;
	private Ray crosshairRay;
    // Start is called before the first frame update

	[SerializeField] private float interactionDistance;

	private LightSwitchScript lightSwitchScript;
	private RaycastHit hit;

	
	[SerializeField] private float defaultHeight;
	[SerializeField] private float crouchHeight;
	[SerializeField] private float crouchTime;


	void Start()
    {

        crosshairRay =  new Ray(this.transform.position, this.transform.forward);

		pController = GetComponent<CharacterController>();
		defaultHeight = pController.height;
    }

	void crouch()
    {

		print("senta :" + pController.height);
		if (pController.height > crouchHeight)
		{
			pController.radius = 0.1f;
			pController.height = Mathf.Lerp(pController.height, crouchHeight, crouchTime * Time.deltaTime);
		}
	}

	void getUp()
    {
		
		print("levanta:" + pController.height);
		if (pController.height < defaultHeight)
		{
			float lastHeight = pController.height;
			pController.height = Mathf.Lerp(pController.height, defaultHeight, crouchTime  *Time.deltaTime);
			transform.position += new Vector3(0, (pController.height - lastHeight) , 0);
			pController.radius = 0.3f;
		}
		
	}


    // Update is called once per frame
    void Update()
    {
		

		if (Input.GetKey(KeyCode.LeftControl))
		{
			crouch();

		}
		else
		{
				getUp();
		}
		if (Input.GetMouseButtonDown(0)){



			

			if (Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hit, interactionDistance )){
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
