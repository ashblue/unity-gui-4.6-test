using UnityEngine;
using System.Collections;

namespace Loader {
	public class LoadInventory : MonoBehaviour {		
		void Awake () {
			string dataMock = Resources.Load("Data/Items").ToString();
			JSONObject data = new JSONObject(dataMock);
			foreach(JSONObject j in data.list) {
				// Generate prefab
				for (int i = 0; i < j.list.Count; i++){
					string key = (string)j.keys[i];
					JSONObject val = (JSONObject)j.list[i];
					Debug.Log(key);
					Debug.Log(val.str);
					// Update prefab values
				}
			}
		}
	}
}

