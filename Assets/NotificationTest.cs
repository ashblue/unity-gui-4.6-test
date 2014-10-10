using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UiTools {
	public class NotificationTest : MonoBehaviour {
		[SerializeField] InputField messageSource;
		[SerializeField] NotificationApi notifyApi;

		public void AddNotification () {
			notifyApi.AddMessage(messageSource.value);
		}
	}
}

