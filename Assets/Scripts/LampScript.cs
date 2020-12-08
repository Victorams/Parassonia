using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    // Start is called before the first frame update

	Light lightComp;
	[SerializeField] private GameObject LightSwitch;
	[SerializeField] private Color color;
	[SerializeField] private int range;
	[SerializeField] private float intensity;
	private bool switchState;
	private LightSwitchScript lightSwitchScript;

    void Start()
    {
    	lightComp = gameObject.AddComponent<Light>();
        lightComp.color = color;
        lightComp.range = range;	
        lightComp.intensity = intensity;
        lightComp.shadows = LightShadows.Hard;
        
        //var lightSwitchScript : Control = LightSwitch.GetComponent("Light Switch Script");
 		lightSwitchScript = LightSwitch.gameObject.GetComponent<LightSwitchScript>();

    }

    // Update is called once per frame
    void Update()
    {
        switchState = lightSwitchScript.getSwitchState();

        if(switchState == true){
        	lightComp.intensity = intensity;
        }else{
        	lightComp.intensity = 0;
        }
    }

}
