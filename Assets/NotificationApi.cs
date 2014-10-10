using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UiTools {
	public class NotificationApi : MonoBehaviour {
		[Tooltip("Displayable text lines")]
		[SerializeField] GameObject messagePrefab;
		
		[Tooltip("Location to dump text")]
		[SerializeField] Transform contentTarget;

		List<string> notifications; // Stack of upcoming messages
		float delay = 0; // When less than 0 its okay to add a new message

		void Awake () {
			notifications = new List<string>();
		}

		// @TODO Messages must be added to the stack so we can implement a delay between introducing each item
		public void AddMessage (string text) {
			notifications.Add(text);
		}

		void Next (string text) {
			GameObject m = (GameObject)Instantiate(messagePrefab, Vector3.zero, Quaternion.identity);
			RectTransform rect = m.GetComponent<RectTransform>();
			m.GetComponent<Text>().text = text;
			m.transform.parent = contentTarget;
			rect.anchoredPosition = Vector2.zero;

			delay = m.GetComponent<NotificationMover>().pushTime;
			
			foreach (Transform t in contentTarget) {
				t.GetComponent<NotificationMover>().AddMove();
			}
		}

		void Update () {
			delay -= Time.deltaTime;
			if (delay < 0 && notifications.Count > 0) {
				Next(notifications[0]);
				notifications.RemoveAt(0);
			}
		}
	}
}