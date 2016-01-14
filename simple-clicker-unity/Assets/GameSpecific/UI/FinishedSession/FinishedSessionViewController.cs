using DT;
using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT.Game {
  public class FinishedSessionViewController : BasicViewController<FinishedSessionView> {
    public GameSession finishedGameSession;
    
    public FinishedSessionViewController(GameSession finishedGameSession, Text scoreText) {
      this._viewPrefabName = "FinishedSessionView";
      this.finishedGameSession = finishedGameSession;
			
			this.InitializeView(() => {
				this._view.SetReusedScoreText(scoreText);
			});
    }
    
    
    // PRAGMA MARK - Button Callbacks
    public void HandleBackToTitleScreenTapped() {
      Toolbox.GetInstance<ViewControllerActivePresentationManager>().ReplaceActiveViewControllerWith(new TitleScreenViewController());
    }
  }
}