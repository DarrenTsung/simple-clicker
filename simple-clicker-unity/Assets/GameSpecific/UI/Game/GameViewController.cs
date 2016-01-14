using DT;
using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;

namespace DT.Game {
  public class GameViewController : BasicViewController<GameView> {
    public GameSession gameSession;
    
    public GameViewController(GameSession gameSession) {
      this._viewPrefabName = "GameView";
      this.gameSession = gameSession;
      this.gameSession.OnGameSessionFinished += this.HandleGameSessionFinished;
    }
    
    
    // PRAGMA MARK - Button Callbacks
    public void OnHarvestTapped() {
      this.gameSession.HandleHarvestEvent();
    }
    
    
    // PRAGMA MARK - Internal
    protected void HandleGameSessionFinished(GameSession finishedGameSession) {
      finishedGameSession.OnGameSessionFinished -= this.HandleGameSessionFinished;
      
      FinishedSessionViewController newViewController = new FinishedSessionViewController(finishedGameSession, this._view.scoreText);
      Toolbox.GetInstance<ViewControllerActivePresentationManager>().ReplaceActiveViewControllerWith(newViewController);
    }
  }
}