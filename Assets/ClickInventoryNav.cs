using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Inventory {
	public class ClickInventoryNav : BtnClickActive {
		[SerializeField] MenuContentManager menuContent;

		void Start () {
			SetActiveByIndex(0);
		}

		public override void SetActive (Button btn) {
			base.SetActive(btn);
		}
	}
}