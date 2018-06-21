using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TurnTheGameOn.Timer{
	public class uGUIAnalogClock : MonoBehaviour {

		public RectTransform secondHandPivot;
		public RectTransform minuteHandPivot;
		public RectTransform hourHandPivot;
		public Timer timerAsset;
		public float secondhandRotation;
		public float minuteRotation;
		public float hourRotation;

		void Start () {
			if (timerAsset == null)
				timerAsset = GameObject.Find("Timer").GetComponent<Timer> ();
		}

		void Update () {
			secondhandRotation = timerAsset.second * 6f;
			minuteRotation = timerAsset.minute * 6f;
			hourRotation = (timerAsset.hour * 30) + (minuteRotation/12);

			secondHandPivot.localRotation = Quaternion.Euler(0, 0, -secondhandRotation);
			minuteHandPivot.localRotation = Quaternion.Euler(0, 0, -minuteRotation);
			hourHandPivot.localRotation = Quaternion.Euler(0, 0, -hourRotation);
		}
	}
}