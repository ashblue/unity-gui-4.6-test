using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Inventory {
	public class ClickFilter : BtnClickActive {
		[SerializeField] Inventory.InventoryManager inventoryTarget;
		
		public override void SetActive (Button btn) {
			base.SetActive(btn);
			
			Text text = btn.GetComponentInChildren<Text>();
			inventoryTarget.SetFilter(text.text);
		}
	}
}