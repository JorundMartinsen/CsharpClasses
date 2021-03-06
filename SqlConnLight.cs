﻿using System;
using System.Data.SqlClient;
/// <summary>
/// Written by 
/// 
/// Jørund Martinsen
/// jorund@automasjonservice.no
/// https://www.automasjonservice.no
///
/// https://github.com/JorundMartinsen/CsharpClasses
/// </summary>
class SqlConnLight
{
    protected static SqlConnection myAccessConnection;
    protected static SqlCommand myAccessCommand;
    protected static string connectionString { get; private set; }
    /// <summary>
    /// Creates a new empty object
    /// </summary>
    protected SqlConnLight()
    {

    }
    /// <summary>
    /// Creates a new object
    /// </summary>
    /// <param name="server">Server to connect to</param>
    /// <param name="database">Database on server</param>
    /// <param name="user">Username to connect with</param>
    /// <param name="password">Password for user</param>
    protected SqlConnLight(string server, string database, string user, string password)
    {
        connectionString =
            "Data Source=" + server + ";" +
            "Initial Catalog=" + database + ";" +
            "User ID=" + user + ";" +
            "Password=" + password + ";";

        try
        {
            myAccessConnection = new SqlConnection(connectionString);
            myAccessCommand = new SqlCommand("SELECT * FROM table", myAccessConnection);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    /// <summary>
    /// Runs any given query
    /// </summary>
    /// <param name="query">Query to run</param>
    protected void RunQuery(string query)
    {
        try
        {
            myAccessConnection.Open();
            myAccessCommand = new SqlCommand(query, myAccessConnection);
            myAccessCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myAccessConnection.Close();
            GC.Collect();
        }
    }
}