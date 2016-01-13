using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT.Game {
	public class AppInit : GameInit {
		// PRAGMA MARK - Internal
		protected override void InitializeGame() {
			base.InitializeGame();
      ViewControllerPresentationManager.Instance.Present(new TitleScreenViewController(), VCPresentationType.IMMEDIATE);
		}
	}
}