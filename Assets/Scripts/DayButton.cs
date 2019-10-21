using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;

public class DayButton : MonoBehaviour {

	private Calendar calendar; 							//Calendar Script (attached to UI text for selected month
	private TextMeshPro btext;									//text of this button
	[Tooltip("The Original Number of This Button")]	
	public int orgNumber;								//original number of each button

	void Start () {
		btext = GetComponentInChildren<TextMeshPro>();
		NumberDays();
	}

	//Change the text in the button to the day of selected month
	//Blank out buttons that are not numbered
	public void NumberDays(){
		/*Button button = GetComponent<Button>();*/
        PressableButton button = GetComponent<PressableButton>();
    	if (CurrentNumber() <= 0 || CurrentNumber() > calendar.DaysInMonth()){
    		
    		button.enabled = false;
    		btext.text = "";
    	}else{
    		btext.text = CurrentNumber().ToString();
			button.enabled = true;
			
    	}
    }

    public int CurrentNumber(){
		calendar = GameObject.FindObjectOfType<Calendar>();
	  	return orgNumber - calendar.FirstOfMonthDay()+1;
    }
}