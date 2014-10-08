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
		}
	}
}
