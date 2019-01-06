using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvokeOnClick : MonoBehaviour {
	public void invokeOnClick()
	{
		GetComponent<Button>().onClick.Invoke();
	}
}
