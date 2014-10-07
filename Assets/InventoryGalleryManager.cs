using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Inventory {
	public class InventoryGalleryManager : BtnClickActive {
		[SerializeField] Inventory.SidebarText textTarget;
		
		public override void SetActive (Button btn) {
			base.SetActive(btn);

			InventoryItem item = btn.GetComponent<InventoryItem>();
			textTarget.SetText (item.title, item.description);
		}
	}
}