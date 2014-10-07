using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Inventory {
	public class InventoryManager : MonoBehaviour {
		[SerializeField] Text filterTitle;
		[SerializeField] GameObject galleryTarget;
		
		public void SetFilter (string name) {
			filterTitle.text = name;
		}
	}
}