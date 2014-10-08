using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Inventory {
	public class ClickFilter : BtnClickActive {
		[SerializeField] Inventory.InventoryManager inventoryTarget;
		[SerializeField] SidebarText sidebar;
		
		public override void SetActive (Button btn) {
			base.SetActive(btn);

			sidebar.SetText("", "");

			Text text = btn.GetComponentInChildren<Text>();
			inventoryTarget.SetFilter(text.text);
		}
	}
}