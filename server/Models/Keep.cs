namespace keepr.Models;

public class Keep
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Views { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    public int Kept { get; set; }
}