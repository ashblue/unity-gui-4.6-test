using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuContentManager : MonoBehaviour {
	List<Transform> children;

	void Awake () {
		children = new List<Transform>();
		foreach (Transform child in transform) {
			children.Add(child);
		}
	}

	public void Show (int index) {
		HideAll();
		children[index].gameObject.SetActive(true);
	}

	public void HideAll () {
		for (int i = 0, l = children.Count; i < l; i++) {
			children[i].gameObject.SetActive(false);
		}
	}
}
