using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryContentManager : MonoBehaviour {
	List<Transform> children;

	void Awake () {

		children = new List<Transform>();
		foreach (Transform child in transform) {
			children.Add(child);
		}
	}

	public void HideAll () {
		foreach (Transform trans in children) {
			trans.gameObject.SetActive(false);
		}
	}
}
