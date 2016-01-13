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
      ViewControllerPresentationManager.Instance.Present(new GameViewController(), VCPresentationType.QUEUED, VCPriority.HIGH);
      this.Dismiss();
    }
  }
}