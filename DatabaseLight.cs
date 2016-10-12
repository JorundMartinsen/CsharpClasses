using System.Threading.Tasks;
/// <summary>
/// Written by 
/// 
/// Jørund Martinsen
/// jorund@automasjonservice.no
/// https://www.automasjonservice.no
///
/// SqlConnLight available here:
/// https://github.com/JorundMartinsen/CsharpClasses
/// </summary>
class DatabaseLight : SqlConnLight
{

    public string table { get; private set; }
    /// <summary>
    /// Creates a new object without any properties
    /// </summary>
    public DatabaseLight() : base()
    {

    }
    /// <summary>
    /// Creates a new object for writing to a database
    /// </summary>
    /// <param name="Server">Server to connect to</param>
    /// <param name="Database">Database to use</param>
    /// <param name="Table">Table to write to</param>
    /// <param name="User">Username for connecting to server</param>
    /// <param name="Password">Password for the user</param>
    public DatabaseLight(string Server, string Database, string Table, string User, string Password) : base(Server, Database, User, Password)
    {
        table = Table;
    }
    /// <summary>
    /// Async version
    /// Writes data to the table.
    /// Designed for writing to the 'Jars' table
    /// </summary>
    /// <param name="amountDelivered">Data to write to AmountDelivered</param>
    /// <param name="rfid">Rfid of jar</param>
    /// <returns>Task</returns>
    public async Task WriteAsync(string amountDelivered, string rfid)
    {
        string query = string.Format("UPDATE {0} SET AmountDelivered={1}, Status=2 WHERE Rfid={2}", table, amountDelivered, rfid);
        RunQuery(query);
    }
    /// <summary>
    /// Writes data to the table.
    /// Designed for writing to the 'Jars' table
    /// </summary>
    /// <param name="amountDelivered">Data to write to AmountDelivered</param>
    /// <param name="rfid">Rfid of jar</param>
    public void Write(string amountDelivered, string rfid)
    {
        string query = string.Format("UPDATE {0} SET AmountDelivered={1}, Status=2 WHERE Rfid={2}", table, amountDelivered, rfid);
        RunQuery(query);
    }
}