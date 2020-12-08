using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
	[SerializeField] private bool isOn;

	public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            toggleState();
        }
    }

    private void toggleState(){
    	if (isOn == true){
    		isOn = false;
    	}else{
    		isOn = true;
    	}
    }

    public bool getSwitchState(){
    	return isOn;
    }
}
