using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextboxResizeFix : MonoBehaviour {
	RectTransform rt;
	Text txt;

	// Use this for initialization
	void Start () {
		rt = gameObject.GetComponent<RectTransform>(); // Acessing the RectTransform 
		txt = gameObject.GetComponent<Text>(); // Accessing the text component
		rt.sizeDelta = new Vector2(rt.rect.width, txt.preferredHeight); // Setting the height to equal the height of text
	}
}
