using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	private CharacterController pController;
	private Ray crosshairRay;

	Rigidbody m_Rigidbody;
	Vector3 m_YAxis;
	// Start is called before the first frame update

	[SerializeField] private float interactionDistance;

	private LightSwitchScript lightSwitchScript;
	private DoorScript doorScript;
	private RaycastHit hit;

	
	[SerializeField] private float defaultHeight;
	[SerializeField] private float crouchHeight;
	[SerializeField] private float crouchTime;


	void Start()
    {

        crosshairRay =  new Ray(this.transform.position, this.transform.forward);
		m_YAxis = new Vector3(0, 5, 0);
		m_Rigidbody = GetComponent<Rigidbody>();
		//Set up vector for moving the Rigidbody in the y axis

		pController = GetComponent<CharacterController>();
		defaultHeight = pController.height;
    }

	public float getInteractionDistance()
    {
		return this.interactionDistance;
    }

	void crouch()
    {

		print("senta :" + pController.height);
		if (pController.height > crouchHeight)
		{
			m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
			pController.center = new Vector3(0, Mathf.Lerp(0, -2, crouchTime * Time.deltaTime), 0); ;
			pController.radius = 0.1f;
			pController.height = Mathf.Lerp(pController.height, crouchHeight, crouchTime * Time.deltaTime);
		}
	}

	void getUp()
    {
		
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
				}else if(hit.collider.tag == "Door") {

					doorScript = hit.collider.gameObject.GetComponent<DoorScript>();

                    if (doorScript.isDoorOpen())
                    {
						doorScript.close();
                    }
                    else
                    {
						doorScript.open();
					}
					
					
				}	
			}
		}
		
    }
}
