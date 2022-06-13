namespace TicTacToe.Data;

public struct StatisticsRow
{
    public GameResult Result { get; init; }
    public string Mode { get; init; }
    public int NumberOfMoves { get; init; }
    public PlayerType Player { get; init; }
    public PlayerType Opponent { get; init; }
}