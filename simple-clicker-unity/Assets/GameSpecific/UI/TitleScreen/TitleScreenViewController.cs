using DT;
using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;

namespace DT.Game {
  public class TitleScreenViewController : BasicViewController {
    public TitleScreenViewController() {
      this._viewPrefabName = "TitleScreenView";
    }
    
    // PRAGMA MARK - Button Callbacks
    public void OnStartGameTapped() {
      GameSession newGameSession = Toolbox.GetInstance<GameSessionManager>().StartNewGameSession();
      Toolbox.GetInstance<ViewControllerActivePresentationManager>().ReplaceActiveViewControllerWith(new GameViewController(newGameSession));
    }
  }
}