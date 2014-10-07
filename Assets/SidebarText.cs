using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Inventory {
	public class SidebarText : MonoBehaviour {
		[SerializeField] Text title;
		[SerializeField] Text desc;

		bool updatePos;

		public void SetText (string title, string desc) {
			this.title.text = title;
			this.desc.text = desc;

			RectTransform textBox = this.desc.rectTransform;	

			// Update the text bounding box to overflow vertically
			textBox.sizeDelta = new Vector2(textBox.sizeDelta.x, this.desc.preferredHeight);

			// Half the negative height is the top of the overflow (because its measured from the center)
			textBox.localPosition = new Vector3(0, this.desc.preferredHeight / -2, 0);	
		}
	}
}
