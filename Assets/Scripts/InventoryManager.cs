using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Inventory {
	class ItemData {
		public List<string> category;
		public string name = "Undefined";
		public string description = "Undefined";
		public string imgName = "200";

		public bool IsCategory (string category) {
			if (category == "All") return true;

			if (this.category.Find(x => x.Contains (category)) != null)
				return true;

			return false;
		}
	}

	// @TODO Game already has an API for item entry (use that instead when implementing)
	class ItemEntry {
		public int count = 0;
	}

	public class InventoryManager : MonoBehaviour {
		[SerializeField] Text filterTitle;
		[SerializeField] ClickFilter filterTarget;
		[SerializeField] GameObject galleryTarget;
		[SerializeField] GameObject galleryItemPrefab;

		Dictionary<string, ItemData> itemLib;
		Dictionary<string, int> items;

		void Awake () {
			// Create a stub of inventory item references
			itemLib = new Dictionary<string, ItemData>() {
				{ "Bloodthorn", new ItemData { name="Bloodthorn", description="A", category=new List<string> { "Ingredients" } } },
				{ "Seraph Crystal", new ItemData { name="Seraph Crystal", description="B", category=new List<string> { "Crafting" } } },
				{ "Legendary Key", new ItemData { name="Legendary Key", description="C", category=new List<string> { "Quest" } } }
			};

			items = new Dictionary<string, int>() {
				{ "Bloodthorn", 2 },
				{ "Seraph Crystal", 1 },
				{ "Legendary Key", 4 }
			};
		}

		void Start () {
			// Force set filter upon initialization, Awake causes errors due to caching logic
			// @TODO On enable SetFilter to "All" again
			SetFilter("All");
			filterTarget.SetActiveByIndex(0);
		}
		
		public void SetFilter (string name) {
			filterTitle.text = name;

			// Wipe gallery items
			foreach (Transform child in galleryTarget.transform) {
				Destroy(child.gameObject);
			}

			foreach (KeyValuePair<string, int> i in items) {
				// do something with entry.Value or entry.Key
				ItemData item = itemLib[i.Key];
				if (!item.IsCategory(name)) continue;
				GameObject galleryItem = Instantiate(galleryItemPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
				galleryItem.transform.parent = galleryTarget.transform;
				InventoryItem data = galleryItem.GetComponent<InventoryItem>();

				galleryItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + item.imgName);

				data.title = item.name;
				data.description = item.description;
			}

			galleryTarget.GetComponent<InventoryGalleryManager>().BindChildren();
		}
	}
}