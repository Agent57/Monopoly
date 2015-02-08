namespace MonopolySpecification
{
  public class Player
  {
    public Player(string name)
    {
      Name = name;
      Cash = Resource.StartingCash;
    }

    public string Name { get; set; }
    public int Position { get; set; }
    public int Cash { get; set; }
  }
}