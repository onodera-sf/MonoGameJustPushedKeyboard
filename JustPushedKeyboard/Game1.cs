using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JustPushedKeyboard
{
	/// <summary>
	/// ゲームメインクラス
	/// </summary>
	public class Game1 : Game
	{
    /// <summary>
    /// グラフィックデバイス管理クラス
    /// </summary>
    private readonly GraphicsDeviceManager _graphics = null;

    /// <summary>
    /// スプライトのバッチ化クラス
    /// </summary>
    private SpriteBatch _spriteBatch = null;

    /// <summary>
    /// スプライトでテキストを描画するためのフォント
    /// </summary>
    private SpriteFont _font = null;

    /// <summary>
    /// 現在スペースキーを押しているか
    /// </summary>
    private bool _nowSpaceKeyPushed = false;

    /// <summary>
    /// 前回スペースキーを押しているか
    /// </summary>
    private bool _previousSpaceKeyPushed = false;

    /// <summary>
    /// キーが押された回数
    /// </summary>
    private int _pushedCount = 0;


    /// <summary>
    /// GameMain コンストラクタ
    /// </summary>
    public Game1()
    {
      // グラフィックデバイス管理クラスの作成
      _graphics = new GraphicsDeviceManager(this);

      // ゲームコンテンツのルートディレクトリを設定
      Content.RootDirectory = "Content";

      // マウスカーソルを表示
      IsMouseVisible = true;
    }

    /// <summary>
    /// ゲームが始まる前の初期化処理を行うメソッド
    /// グラフィック以外のデータの読み込み、コンポーネントの初期化を行う
    /// </summary>
    protected override void Initialize()
    {
      // TODO: ここに初期化ロジックを書いてください

      // コンポーネントの初期化などを行います
      base.Initialize();
    }

    /// <summary>
    /// ゲームが始まるときに一回だけ呼ばれ
    /// すべてのゲームコンテンツを読み込みます
    /// </summary>
    protected override void LoadContent()
    {
      // テクスチャーを描画するためのスプライトバッチクラスを作成します
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      // フォントをコンテンツパイプラインから読み込む
      _font = Content.Load<SpriteFont>("Font");
    }

    /// <summary>
    /// ゲームが終了するときに一回だけ呼ばれ
    /// すべてのゲームコンテンツをアンロードします
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: ContentManager で管理されていないコンテンツを
      //       ここでアンロードしてください
    }

    /// <summary>
    /// 描画以外のデータ更新等の処理を行うメソッド
    /// 主に入力処理、衝突判定などの物理計算、オーディオの再生など
    /// </summary>
    /// <param name="gameTime">このメソッドが呼ばれたときのゲーム時間</param>
    protected override void Update(GameTime gameTime)
    {
      // ゲームパッドの Back ボタン、またはキーボードの Esc キーを押したときにゲームを終了させます
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
      {
        Exit();
      }

      // 前回のスペースキーの押下状態を記憶
      _previousSpaceKeyPushed = _nowSpaceKeyPushed;

      // キーボードの現在の状態を取得
      KeyboardState keyState = Keyboard.GetState();

      // 現在のスペースキーの押下状態を記憶
      _nowSpaceKeyPushed = keyState.IsKeyDown(Keys.Space);

      // キーが押された瞬間ならカウントする
      if (_nowSpaceKeyPushed && !_previousSpaceKeyPushed)
      {
        _pushedCount++;
      }

      // 登録された GameComponent を更新する
      base.Update(gameTime);
    }

    /// <summary>
    /// 描画処理を行うメソッド
    /// </summary>
    /// <param name="gameTime">このメソッドが呼ばれたときのゲーム時間</param>
    protected override void Draw(GameTime gameTime)
    {
      // 画面を指定した色でクリアします
      GraphicsDevice.Clear(Color.CornflowerBlue);

      // スプライトの描画準備
      _spriteBatch.Begin();

      _spriteBatch.DrawString(_font, "Please press a space key.",
         new Vector2(50.0f, 50.0f), Color.White);

      // キーが押された回数を表示
      _spriteBatch.DrawString(_font,
          "Pushed Count : " + _pushedCount.ToString(),
          new Vector2(50.0f, 80.0f), Color.White);

      // スペースキーが押されている場合は文字を表示する
      if (_nowSpaceKeyPushed)
      {
        _spriteBatch.DrawString(_font, "A space key is being pressed.",
            new Vector2(50.0f, 110.0f), Color.Yellow);
      }

      // スプライトの一括描画
      _spriteBatch.End();

      // 登録された DrawableGameComponent を描画する
      base.Draw(gameTime);
    }
  }
}
