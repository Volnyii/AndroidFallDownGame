public class CounterPresenter
{
    private CounterView _counterView;
    private GameController _gameController;

    public CounterPresenter(CounterView counterView, GameController gameController)
    {
        _counterView = counterView;
        _gameController = gameController;
        _gameController.Info.ScoreInfo.OnScoreChanged += ChangedValue;
    }

    private void ChangedValue(int value)
    {
        _counterView.ChangeCounterValue(value);
    }
}
