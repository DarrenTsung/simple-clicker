using DT;
using System;
using System.Collections;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT.Game {
	public class FinishedSessionView : BasicView<FinishedSessionViewController> {
		// PRAGMA MARK - Public Interface
		public override void Show() {
			this.StartCoroutine(this.MoveBetweenPositions(this.transform, new Vector2(0.0f, -700.0f), new Vector2(0.0f, 0.0f), time : 0.4f, callback: () => {
				this.EndShow();
			}));
			
			Transform scoreTransform = this._scoreText.transform;
			this.StartCoroutine(this.MoveBetweenPositions(scoreTransform, scoreTransform.localPosition + new Vector3(0.0f, 700.0f), this._targetScoreLocalPosition, time : 0.4f));
			this.StartCoroutine(this.AnimateScoreFontSize(time : 0.4f));
			
			base.Show();
		}
		
		public override void Dismiss() {
			this.StartCoroutine(this.MoveBetweenPositions(this.transform, new Vector2(0.0f, 0.0f), new Vector2(0.0f, 700.0f), time : 0.4f, callback: () => {
				this.EndDismiss();
			}));
			
			base.Dismiss();
		}
		
		public void SetReusedScoreText(Text scoreText) {
			this._scoreText = scoreText;
			this._scoreText.transform.SetParent(this.transform, false);
		}
		
		
		// PRAGMA MARK - Button Callbacks
		public void HandleBackToTitleScreenTapped() {
			this._viewController.HandleBackToTitleScreenTapped();
		}
		
		
		// PRAGMA MARK - Internal
		[SerializeField]
		private Text _scoreText;
		[SerializeField]
		private int _targetScoreFontSize = 80;
		[SerializeField]
		private Vector2 _targetScoreLocalPosition = new Vector2(0.0f, 0.0f);
		
		protected IEnumerator MoveBetweenPositions(Transform t, Vector2 startPosition, Vector2 endPosition, float time, Action callback = default(Action)) {
			t.localPosition = startPosition;
			
			for (float elapsedTime = 0; elapsedTime <= time; elapsedTime += Time.deltaTime) {
				t.localPosition = Vector2.Lerp(startPosition, endPosition, Easers.Ease(EaseType.QuadOut, 0.0f, 1.0f, elapsedTime, time));
				yield return new WaitForEndOfFrame();
			}
			
			if (callback != null) {
				callback();
			}
		}
		
		protected IEnumerator AnimateScoreFontSize(float time) {
			int originalFontSize = this._scoreText.fontSize;
			for (float elapsedTime = 0; elapsedTime <= time; elapsedTime += Time.deltaTime) {
				this._scoreText.fontSize = (int)Easers.Ease(EaseType.QuadOut, originalFontSize, this._targetScoreFontSize, elapsedTime, time);
				yield return new WaitForEndOfFrame();
			}
		}
	}
}