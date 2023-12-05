using Godot;
public partial class main : Node2D
{
  Node _ball;
  Node _paddle;
  Node _enemyPaddle;
  Node  _player_score;
  Node _enemy_score;
  Node _start_message;
  private bool started;
  private int player_score;
  private int enemy_score;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    GD.Print("Ready");
    started = false;
    _ball = GetNode<ball>("ball");
    _paddle = GetNode <paddle>("Paddle");
    _enemyPaddle = GetNode<enemy_paddle>("EnemyPaddle");
    _player_score = GetNode("score/player-score");
    _enemy_score = GetNode("score/enemy-score");
    _start_message = GetNode("start-message");
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
    var ballInstance = _ball as ball;
    var paddleInstance = _paddle as paddle;
    var enemy_paddleInstance = _enemyPaddle as enemy_paddle;
    var player_scoreInstance = _player_score;
    var enemy_scoreInstance = _enemy_score;
    var start_messageInstance = _start_message;
    var player_scoreLabel = player_scoreInstance as Label;
    var enemy_scoreLabel = enemy_scoreInstance as Label;
    var start_messageLabel = start_messageInstance as Label;
    
    if (Input.IsKeyPressed(Key.Space) && started == false) 
    {
      ballInstance.StartBall();
      started = true;
      start_messageLabel.Text = "";
    }

    
    if (isNotNull(ballInstance) && isNotNull(paddleInstance) && isNotNull(enemy_paddleInstance) && isNotNull(player_scoreInstance) && isNotNull(enemy_paddleInstance))
    {
      var ballpos = ballInstance.Position;
      var ballvel = ballInstance.Velocity;
      var paddlepos = paddleInstance.Position;
      var enemy_paddlepos = enemy_paddleInstance.Position;
      if (ballpos.X <= -1142 && isNotNull(enemy_scoreLabel))
      {
        ballpos = Vector2.Zero;
        ballvel = Vector2.Zero;
        paddlepos = new Vector2(paddlepos.X, 0);
        enemy_paddlepos = new Vector2(enemy_paddlepos.X, 0);
        ballInstance.Position = ballpos;
        ballInstance.Velocity = ballvel;
        paddleInstance.Position = paddlepos;
        enemy_paddleInstance.Position = enemy_paddlepos;
        started = false;
        enemy_score++;
        enemy_scoreLabel.Text = enemy_score.ToString();
        start_messageLabel.Text = "Press space to start!";
      }

      if (ballpos.X >= 1142)
      {
        ballpos = Vector2.Zero;
        ballvel = Vector2.Zero;
        paddlepos = new Vector2(paddlepos.X, 0);
        enemy_paddlepos = new Vector2(enemy_paddlepos.X, 0);
        ballInstance.Position = ballpos;
        ballInstance.Velocity = ballvel;
        paddleInstance.Position = paddlepos;
        enemy_paddleInstance.Position = enemy_paddlepos;
        started = false;
        player_score++;
        player_scoreLabel.Text = player_score.ToString();
        start_messageLabel.Text = "Press space to start!";
      }
    }
  }
  static bool isNotNull(Node node) => node != null;
}