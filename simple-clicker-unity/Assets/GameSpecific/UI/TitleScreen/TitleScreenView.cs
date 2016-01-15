using DT;
using System;
using System.Collections;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT.Game {
	public class TitleScreenView : BasicView<TitleScreenViewController> {
		// PRAGMA MARK - Public Interface
		public override void Show() {
			this.StartCoroutine(this.MoveBetweenPositions(new Vector2(-500.0f, 0.0f), new Vector2(0.0f, 0.0f), 0.5f, () => {
				this.EndShow();
			}));

			base.Show();
		}

		public override void Dismiss() {
			this.StartCoroutine(this.MoveBetweenPositions(new Vector2(0.0f, 0.0f), new Vector2(500.0f, 0.0f), 0.5f, () => {
				this.EndDismiss();
        Toolbox.GetInstance<ObjectPoolManager>().Recycle(this.gameObject);
			}));

			base.Dismiss();
		}


		// PRAGMA MARK - Button Callbacks
		public void OnStartGameTapped() {
			this._viewController.OnStartGameTapped();
		}


		// PRAGMA MARK - Internal
		[SerializeField] private Text _title;
		[SerializeField] private Text _startGameButtonText;

		protected IEnumerator MoveBetweenPositions(Vector2 startPosition, Vector2 endPosition, float time, Action callback) {
			this.transform.localPosition = startPosition;

			for (float elapsedTime = 0;; elapsedTime += Time.deltaTime) {
				this.transform.localPosition = Vector2.Lerp(startPosition, endPosition, Easers.Ease(EaseType.QuadOut, 0.0f, 1.0f, elapsedTime, time));

				if (elapsedTime >= time) {
					break;
				}
				yield return new WaitForEndOfFrame();
			}

			callback();
		}
	}
}