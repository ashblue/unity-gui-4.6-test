using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnClickActive : MonoBehaviour {
	[SerializeField] Color colorActive;
	Color colorDefault;
	Button[] buttons;

	// Use this for initialization
	void Awake () {
		buttons = GetComponentsInChildren<Button>();
		for (int i = 0, l = buttons.Length; i < l; i++) {
			Button btn = buttons[i];
			buttons[i].onClick.AddListener(() => { SetActive(btn); });
		}

		colorDefault = buttons[0].image.color;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SetActive (Button btn) {
		for (int i = 0, l = buttons.Length; i < l; i++) {
			buttons[i].image.color = colorDefault;
		}

		btn.image.color = colorActive;
	}
}
