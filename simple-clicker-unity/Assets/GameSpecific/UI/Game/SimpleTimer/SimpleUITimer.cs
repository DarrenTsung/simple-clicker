using DT;
using System.Collections;
﻿using UnityEngine;
using UnityEngine.UI;

namespace DT.Game {
	public class SimpleUITimer : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public float baseTime;
		
		public void ResetTimeLeft() {
			this._timeLeft = this.baseTime;
		}
		
		
		// PRAGMA MARK - Internal
		[SerializeField, ReadOnly]
		private float _timeLeft;
		
		[SerializeField]
		private Color _maxColor;
		[SerializeField]
		private Color _minColor;
		
		[SerializeField] 
		private Image _barImage;
		[SerializeField, ReadOnly]
		private float _baseWidth;
		
		
		protected void Awake() {
			RectTransform rectTransform = (RectTransform)transform;
			this._baseWidth = rectTransform.sizeDelta.x;
			this.ResetTimeLeft();
		}
		
		protected void Update() {
			this.UpdateTimeLeft();
			this.UpdateDisplay();
		}
	
		protected void UpdateTimeLeft() {
			this._timeLeft -= Time.deltaTime;
			if (this._timeLeft < 0.0f) {
				this._timeLeft = 0.0f;
			}
		}
		
		protected void UpdateDisplay() {
			float percentTimeRemaining = this._timeLeft / this.baseTime;
			
			Color displayColor = Color.Lerp(_minColor, _maxColor, percentTimeRemaining);
			_barImage.color = displayColor;
			
			RectTransform rectTransform = (RectTransform)transform;
			rectTransform.sizeDelta = rectTransform.sizeDelta.SetX(this._baseWidth * percentTimeRemaining);
		}
	}
}