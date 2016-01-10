using DT;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DT.Game {
  public class DebugManager : Singleton<DebugManager> {
    protected TitleScreenViewController _vc1, _vc2, _vc3, _vc4;
    protected TitleScreenViewController VC1 {
      get {
        if (this._vc1 == null) {
          this._vc1 = new TitleScreenViewController();
        }
        return this._vc1;
      }
    }
    
    protected TitleScreenViewController VC2 {
      get {
        if (this._vc2 == null) {
          this._vc2 = new TitleScreenViewController();
        }
        return this._vc2;
      }
    }
    
    protected void Update() {
      if (Input.GetKeyDown(KeyCode.H)) {
        ViewControllerManager.Instance.Present(this.VC1, VCPresentationType.IMMEDIATE);
      }
      if (Input.GetKeyDown(KeyCode.Y)) {
        this.VC1.Dismiss();
      }
      
      if (Input.GetKeyDown(KeyCode.J)) {
        ViewControllerManager.Instance.Present(this.VC2, VCPresentationType.QUEUED);
      }
      if (Input.GetKeyDown(KeyCode.U)) {
        this.VC2.Dismiss();
      }
    }
  }
}