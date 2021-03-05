using SQLite4Unity3d;

public class DictionaryLookup
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }


    public override string ToString()
    {
        return string.Format("[DL: Id={0}, Name={1}]", Id, Name);
    }
}
