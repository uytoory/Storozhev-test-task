[System.Serializable]
public class ProgressData
{
    public int Coins;
    public int Golds;
    
    public ProgressData(Progress progress)
    {
        Coins = progress.Coins;
        Golds = progress.Golds;
    }
}
