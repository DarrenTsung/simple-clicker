using DT;
using System;
using System.Collections;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT.Game {
	public class TitleScreenView : BasicView {
		// PRAGMA MARK - Public Interface
		public override void Show() {
			this.StartCoroutine(this.MoveFromPositionsLinear(new Vector2(-500.0f, 0.0f), new Vector2(0.0f, 0.0f), 0.5f, () => {
				this.EndShow();
			}));
			
			base.Show();
		}
		
		public override void Dismiss() {
			this.StartCoroutine(this.MoveFromPositionsLinear(new Vector2(0.0f, 0.0f), new Vector2(500.0f, 0.0f), 0.5f, () => {
				this.EndDismiss();
			}));
			
			base.Dismiss();
		}
		
		
		// PRAGMA MARK - Internal
		[SerializeField] private Text _title;
		
		protected IEnumerator MoveBetweenPositionsLinear(Vector2 startPosition, Vector2 endPosition, float time, Action callback) {
			this.transform.localPosition = startPosition;
			
			for (float elapsedTime = 0; elapsedTime <= time; elapsedTime += Time.deltaTime) {
				this.transform.localPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / time);
				yield return new WaitForEndOfFrame();
			}
			
			callback();
		}
	}
}