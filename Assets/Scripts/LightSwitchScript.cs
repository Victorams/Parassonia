using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
	[SerializeField] private bool isOn;
	[SerializeField] private bool energyOn;
	private bool closeToPlayer;
	private float distanceFromPlayer;
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
        distanceFromPlayer  = Vector3.Distance(player.transform.position, this.transform.position);
        if(distanceFromPlayer <= 0.5f){
        	closeToPlayer = true;
        }
        else{
        	closeToPlayer = false;
        }
    }



    public void toggleState(){
    	if ( isOn == true){
    		
    		isOn = false;
    	}else{
    		if(energyOn == true)
    			isOn = true;
    	}
    }

    public bool getSwitchState(){
    	return isOn;
    }
}
