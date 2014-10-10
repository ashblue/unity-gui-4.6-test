using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationMover : MonoBehaviour {
	[SerializeField] float pushUp = 20f;
	public float pushTime = 0.3f;
	[Tooltip("How long to keep alive after being pushed up")]
	[SerializeField] float lifetime = 2f;
	[SerializeField] float fadeTime = 0.5f;

	RectTransform rect;
	Text text;

	float creationTime;
	float startTime;
	Vector2 startPos;
	Vector2 targetPos;
	float fadeStartTime;

	void Awake () {
		rect = GetComponent<RectTransform>();
		creationTime = Time.time;
		fadeStartTime = creationTime + lifetime;
		text = GetComponent<Text>();
	}

	void FixedUpdate () {
		if (creationTime + lifetime < Time.time) {
			float fadePercent = (Time.time - fadeStartTime) / fadeTime;
			text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1, 0, fadePercent));
			if (text.color.a == 0f) Destroy(gameObject);
		}

		float percent = (Time.time - startTime) / pushTime;
		rect.anchoredPosition = Vector2.Lerp(startPos, targetPos, percent);		
	}

	public void AddMove () {
		startTime = Time.time;
		startPos = rect.anchoredPosition;
		targetPos = new Vector2(0, rect.anchoredPosition.y + pushUp);
	}
}
