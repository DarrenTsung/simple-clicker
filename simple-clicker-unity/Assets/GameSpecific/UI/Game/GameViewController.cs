using DT;
using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;

namespace DT.Game {
  public class GameViewController : BasicViewController {
    public GameSession gameSession;
    
    public GameViewController(GameSession gameSession) {
      this._viewPrefabName = "GameView";
      this.gameSession = gameSession;
    }
    
    
    // PRAGMA MARK - Button Callbacks
    public void OnHarvestTapped() {
      this.gameSession.HandleHarvestEvent();
    }
  }
}