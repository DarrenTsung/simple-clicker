using DT;
using UnityEngine;

namespace DT.Game {
  public class GameSession : MonoBehaviour, ITimeRemainingProvider {
    // PRAGMA MARK - Public Interface
    public delegate void HandleGameSessionFinished(GameSession finishedGameSession);
    public event HandleGameSessionFinished OnGameSessionFinished = delegate {};
    
    public int Score {
      get; private set;
    }
    
    [SerializeField, ReadOnly]
    private bool _isFinished;
    public bool IsFinished {
      get {
        return this._isFinished;
      }
      private set {
        this._isFinished = value;
        if (this._isFinished) {
          this.OnGameSessionFinished.Invoke(this);
        }
      }
    }
    
    public void HandleHarvestEvent() {
      if (this.IsFinished) {
        return;
      }
      
      this.Score++;
      this.ResetTimeLeft();
    }
		
    
    // PRAGMA MARK - ITimeRemainingProvider implementation
    public float PercentTimeRemaining {
      get {
        return this._timeLeft / this._baseTime;
      }
    }
    
    
    // PRAGMA MARK - Internal
		[SerializeField, ReadOnly]
		private float _timeLeft;
    
    private float _baseTime = 5.0f;
    
    protected void Awake() {
      this._timeLeft = this._baseTime;
    }
    
    protected void Update() {
      if (this.IsFinished) {
        return;
      }
      
      this.UpdateTimeLeft();
    }
    
    protected void UpdateTimeLeft() {
      this._timeLeft -= Time.deltaTime;
      if (this._timeLeft <= 0.0f) {
        this._timeLeft = 0.0f;
        this.IsFinished = true;
      }
    }
		
		protected void ResetTimeLeft() {
			this._timeLeft = this._baseTime;
		}
  }
}