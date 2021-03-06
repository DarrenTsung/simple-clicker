using DT;
using System;
using System.Collections;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT.Game {
	public class GameView : BasicView<GameViewController> {
		// PRAGMA MARK - Public Interface
		public Text scoreText;
		
		public override void Show() {
			this.StartCoroutine(this.MoveBetweenPositions(new Vector2(0.0f, 700.0f), new Vector2(0.0f, 0.0f), time : 0.4f, callback: () => {
				this.EndShow();
			}));
			
			base.Show();
		}
		
		public override void Dismiss() {
			this.StartCoroutine(this.MoveBetweenPositions(new Vector2(0.0f, 0.0f), new Vector2(0.0f, -700.0f), time : 0.4f, callback: () => {
				this.EndDismiss();
			}));
			
			base.Dismiss();
		}
		
		
		// PRAGMA MARK - Button Callbacks
		public void OnHarvestTapped() {
			this._viewController.OnHarvestTapped();
		}
		
		
		// PRAGMA MARK - Internal
		[SerializeField] 
		private SimpleUITimer _timer;
		
		protected void Start() {
			this._timer.SetTimeRemainingProvider(this._viewController.gameSession);
			this._viewController.gameSession.OnScoreChanged += this.HandleScoreChanged;
		}
		
		protected void OnDisable() {
			this._viewController.gameSession.OnScoreChanged -= this.HandleScoreChanged;
		}
		
		protected void HandleScoreChanged(int newScore) {
			this.scoreText.text = newScore.ToString();
		}
		
		protected IEnumerator MoveBetweenPositions(Vector2 startPosition, Vector2 endPosition, float time, Action callback) {
			this.transform.localPosition = startPosition;
			
			for (float elapsedTime = 0; elapsedTime <= time; elapsedTime += Time.deltaTime) {
				this.transform.localPosition = Vector2.Lerp(startPosition, endPosition, Easers.Ease(EaseType.QuadOut, 0.0f, 1.0f, elapsedTime, time));
				yield return new WaitForEndOfFrame();
			}
			
			callback();
		}
	}
}