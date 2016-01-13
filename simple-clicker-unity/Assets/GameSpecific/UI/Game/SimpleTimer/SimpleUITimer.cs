using DT;
using System.Collections;
﻿using UnityEngine;
using UnityEngine.UI;

namespace DT.Game {
	public class SimpleUITimer : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public void SetTimeRemainingProvider(ITimeRemainingProvider timeRemainingProvider) {
			this._timeRemainingProvider = timeRemainingProvider;
		}
		
		
		// PRAGMA MARK - Internal
		[SerializeField]
		private Color _maxColor;
		[SerializeField]
		private Color _minColor;
		
		[SerializeField] 
		private Image _barImage;
		[SerializeField, ReadOnly]
		private float _baseWidth;
		
		private ITimeRemainingProvider _timeRemainingProvider;
		
		
		protected void Awake() {
			RectTransform rectTransform = (RectTransform)transform;
			this._baseWidth = rectTransform.sizeDelta.x;
		}
		
		protected void Update() {
			this.UpdateDisplay();
		}
		
		protected void UpdateDisplay() {
			float percentTimeRemaining = _timeRemainingProvider.PercentTimeRemaining;
			
			Color displayColor = Color.Lerp(_minColor, _maxColor, percentTimeRemaining);
			_barImage.color = displayColor;
			
			RectTransform rectTransform = (RectTransform)transform;
			rectTransform.sizeDelta = rectTransform.sizeDelta.SetX(this._baseWidth * percentTimeRemaining);
		}
	}
}