using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif
namespace TurnTheGameOn.Timer{
	[System.Serializable]
	public class DisplayOptions{
		public bool milliseconds = true, seconds = true, minutes = true, hours = true, days = true;
	}
	[System.Serializable]
	public class TimerFormat{
		public bool milliseconds = true, seconds = true, minutes = true, hours = true;
	}
	
	[ExecuteInEditMode]
	public class Timer : MonoBehaviour {
		public enum TimerType{CountUp, CountDown, CountUpInfinite}
		public enum LoadSceneOn{Disabled, TimesUp, SpecificTime}
		public enum TimerState{Disabled, Counting}
		public DisplayOptions displayOptions;
		public TimerFormat timerFormat;
		
		private string ms, s, m, d, h;
		
		[Header("Timer Settings")]
		public TimerState timerState;
		public bool useSystemTime;
		private DateTime systemDateTime;
		private float gameTime;
		public Text timerText;
		public float timerSpeed = 1;
		public int day;
		public int hour;
		public int minute;
		public int second;
		public int millisecond;
		
		[Header("Times Up Settings")]
		public bool setZeroTimescale;
		public UnityEvent timesUpEvent;
		public GameObject[] destroyOnFinish;
		[HideInInspector()] public TimerType timerType;
		[HideInInspector()] public float startTime;
		[HideInInspector()] public float finishTime;
		[HideInInspector()] public LoadSceneOn loadSceneOn;
		[HideInInspector()] public string loadSceneName;
		[HideInInspector()] public float timeToLoadScene;
		
		string FormatSeconds(float elapsed){
			if (timerType == TimerType.CountUpInfinite) {
				if (useSystemTime) {
					CheckDisplayOptions ();
					gameTime = ((float)DateTime.Now.Hour + ((float)DateTime.Now.Minute) + (float)DateTime.Now.Second);
					millisecond = (int)DateTime.Now.Millisecond;
					second = (int)DateTime.Now.Second;
					minute = (int)DateTime.Now.Minute;
					hour = (int)DateTime.Now.Hour;
					day = (int)DateTime.Now.DayOfYear;
					return String.Format (d + h + m + s + ms, day, hour, minute, second, millisecond);
				} else {
					CheckDisplayOptions ();
					TimeSpan t = TimeSpan.FromSeconds (elapsed);
					day = t.Days;
					hour = t.Hours;
					minute = t.Minutes;
					second = t.Seconds;
					millisecond = t.Milliseconds;
					
					return String.Format ( d + h + m + s + ms, 
					                      t.Days, t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
				}
				
				
			} else {
				TimeSpan t = TimeSpan.FromSeconds (elapsed);
				CheckTimerOptions ();
				return String.Format ( h + m + s + ms, t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
			}
		}
		
		void CheckDisplayOptions(){
			if (displayOptions.milliseconds) {
				ms = ".{4:D3}";
			} else {
				ms = "";
			}
			if (displayOptions.seconds) {
				s = "{3:D2}";
			} else {
				s = "";
			}
			if (displayOptions.minutes) {
				m = "{2:D2}:";
			} else {
				m = "";
			}
			if (displayOptions.hours) {
				h = "{1:D2}:";
			} else {
				h = "";
			}
			if (displayOptions.days) {
				d = "{0:D3}:";
			} else {
				d = "";
			}
		}
		
		void CheckTimerOptions(){
			if (timerFormat.milliseconds) {
				ms = ".{3:D3}";
			} else {
				ms = "";
			}
			if (timerFormat.seconds) {
				s = "{2:D2}";
			} else {
				s = "";
			}
			if (timerFormat.minutes) {
				m = "{1:D2}:";
			} else {
				m = "";
			}
			if (timerFormat.hours) {
				h = "{0:D2}:";
			} else {
				h = "";
			}
		}
		
		void Start () {		
			if(timerState == TimerState.Counting){
				if(timerText != null) timerText.text = FormatSeconds(gameTime);
				if (timerType == TimerType.CountUp) {
					gameTime = 0;
				}
				if (timerType == TimerType.CountDown) {
					gameTime = startTime;
				}
			}
		}
		
		void Update () {
			#if UNITY_EDITOR
			if(!Application.isPlaying){
				if (timerType == TimerType.CountUp) {
					gameTime = 0;
					if(timerText != null) timerText.text = FormatSeconds(gameTime);
				}
				if (timerType == TimerType.CountDown) {
					gameTime = startTime;
					if(timerText != null) timerText.text = FormatSeconds(gameTime);
				}
				if(timerType == TimerType.CountUpInfinite){
					if(timerText != null) timerText.text = FormatSeconds(gameTime);
				}
			}
			#endif
			if (timerState == TimerState.Counting) {
				if (timerType == TimerType.CountUp) {
					gameTime += 1 * Time.deltaTime * timerSpeed;
					if (gameTime >= timeToLoadScene) {
						if (loadSceneOn == LoadSceneOn.SpecificTime) {
							#if !UNITY_5_3_OR_NEWER
							Application.LoadLevel (loadSceneName);
							#endif
							#if UNITY_5_3_OR_NEWER
							SceneManager.LoadScene (loadSceneName);
							#endif
						}
					}
				}
				if (timerType == TimerType.CountDown) {
					gameTime -= 1 * Time.deltaTime * timerSpeed;
					if (gameTime <= timeToLoadScene) {
						if (loadSceneOn == LoadSceneOn.SpecificTime) {
							#if !UNITY_5_3_OR_NEWER
							Application.LoadLevel (loadSceneName);
							#endif
							#if UNITY_5_3_OR_NEWER
							SceneManager.LoadScene (loadSceneName);
							#endif
						}
					}
				}
				if (timerType == TimerType.CountUpInfinite) {
					if (useSystemTime) {
						
					} else {
						gameTime += 1 * Time.deltaTime * timerSpeed;
					}
				}
				if (timerType == TimerType.CountDown && gameTime <= 0) {
					StopTimer ();
					timesUpEvent.Invoke();
					for (int i = 0; i < destroyOnFinish.Length; i++) {
						Destroy (destroyOnFinish [i]);
					}
					if (loadSceneOn == LoadSceneOn.TimesUp)
						#if !UNITY_5_3_OR_NEWER
						Application.LoadLevel (loadSceneName);
						#endif
						#if UNITY_5_3_OR_NEWER
						SceneManager.LoadScene (loadSceneName);
						#endif
				}
				if (timerType == TimerType.CountUp && gameTime >= finishTime) {
					timesUpEvent.Invoke();
					StopTimer ();
					for (int i = 0; i < destroyOnFinish.Length; i++) {
						Destroy (destroyOnFinish [i]);
					}
					if (loadSceneOn == LoadSceneOn.TimesUp)
						#if !UNITY_5_3_OR_NEWER
						Application.LoadLevel (loadSceneName);
					#endif
					#if UNITY_5_3_OR_NEWER
					SceneManager.LoadScene (loadSceneName);
					#endif
				}
				if(timerText != null) timerText.text = FormatSeconds(gameTime);
				
			}
		}
		
		[ContextMenu("Start Timer")]
		public void StartTimer(){
			timerState = TimerState.Counting;
		}
		
		[ContextMenu("Stop Timer")]
		public void StopTimer(){
			timerState = TimerState.Disabled;
			if (setZeroTimescale) {
				Time.timeScale = 0;
			}
		}
		
		[ContextMenu("Restart Timer")]
		public void RestartTimer(){
			if (timerType == TimerType.CountDown) {
				gameTime = startTime;
			} else {
				gameTime = 0;
			}
			if(timerText != null) timerText.text = FormatSeconds(gameTime);
			StartTimer ();
		}
		
		[ContextMenu("Reset Timer")]
		public void ResetTimer(){
			if (timerType == TimerType.CountDown) {
				gameTime = startTime;
			} else {
				gameTime = 0;
			}
			if(timerText != null) timerText.text = FormatSeconds(gameTime);
		}
		
		public float GetTimerValue(){
			return gameTime;
		}
		
	}
}