using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButton : MonoBehaviour {

	public void ChangeButtonState(int newAttributePoints)
    {
        if(newAttributePoints > 0){
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
}
