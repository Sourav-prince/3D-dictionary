using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Vuforia
{
public class detect : MonoBehaviour, ITrackableEventHandler {
	public Text word;
	private TrackableBehaviour mTrackableBehaviour;
	// Use this for initialization
	void Start () {
		word.text = "start";
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
	}
	
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				Found();
			}
			else
			{
				Lost();
			}
		}
		private void Found()
		{
			word.text = mTrackableBehaviour.TrackableName;
			Debug.Log ("my func" + mTrackableBehaviour.TrackableName);
		}
		private void Lost()
		{
			word.text ="";
			Debug.Log ("my func no obj");
		}

}
}