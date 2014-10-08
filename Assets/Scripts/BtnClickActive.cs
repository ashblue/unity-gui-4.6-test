using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnClickActive : MonoBehaviour {
	[SerializeField] Color colorActive;
	Color colorDefault;
	Button[] buttons;

	void Awake () {
		buttons = GetComponentsInChildren<Button>();
		colorDefault = buttons[0].image.color;
		BindChildren();
	}

	// Force bind all available first level children
	public void BindChildren () {
		buttons = GetComponentsInChildren<Button>();
		for (int i = 0, l = buttons.Length; i < l; i++) {
			Button btn = buttons[i];
			buttons[i].onClick.AddListener(() => { SetActive(btn); });
		}
	}

	public void SetActiveByIndex (int index) {
		buttons = GetComponentsInChildren<Button>();
		for (int i = 0, l = buttons.Length; i < l; i++) {
			buttons[i].image.color = colorDefault;
		}

		Button btn = buttons[index];
		btn.image.color = colorActive;
	}

	// Callback when setting a button to active
	public virtual void SetActive (Button btn) {
		buttons = GetComponentsInChildren<Button>();
		for (int i = 0, l = buttons.Length; i < l; i++) {
			buttons[i].image.color = colorDefault;
		}

		btn.image.color = colorActive;
	}
}
