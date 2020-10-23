using Mono.Data.Sqlite;
using System;

public class DbAccess
{
    private static DbAccess _ins;

    private SqliteCommand dbCommand;
    private SqliteConnection dbConnection;
    private SqliteDataReader reader;

    public static DbAccess Instance
    {
        get
        {
            if (_ins == null)
            {
                _ins = new DbAccess();
            }
            return _ins;
        }
    }

    private DbAccess()
    {
    }

    public void connDB(string connectionString)
    {
        this.OpenDB(connectionString);
    }

    public void CloseSqlConnection()
    {
        disposeCommand();
        if (this.reader != null)
        {
            this.reader.Close();
            this.reader.Dispose();
        }
        this.reader = null;
        if (this.dbConnection != null)
        {
            this.dbConnection.Close();
            this.dbConnection.Dispose();
        }
        this.dbConnection = null;
        ClientLog.Log("Disconnected from db.");
    }

    private void disposeCommand()
    {
        if (this.dbCommand != null)
        {
            this.dbCommand.Dispose();
            this.dbCommand = null;
        }
    }

    public SqliteDataReader CreateTable(string name, string[] col, string[] colType)
    {
        if (col.Length != colType.Length)
        {
            throw new SqliteException("columns.Length != colType.Length");
        }
        string[] textArray1 = new string[] { "CREATE TABLE ", name, " (", col[0], " ", colType[0] };
        string sqlQuery = string.Concat(textArray1);
        for (int i = 1; i < col.Length; i++)
        {
            string str2 = sqlQuery;
            string[] textArray2 = new string[] { str2, ", ", col[i], " ", colType[i] };
            sqlQuery = string.Concat(textArray2);
        }
        sqlQuery = sqlQuery + ")";
        return this.ExecuteQuery(sqlQuery);
    }

    public SqliteDataReader Delete(string tableName, string[] cols, string[] colsvalues)
    {
        string[] textArray1 = new string[] { "DELETE FROM ", tableName, " WHERE ", cols[0], " = ", colsvalues[0] };
        string sqlQuery = string.Concat(textArray1);
        for (int i = 1; i < colsvalues.Length; i++)
        {
            string str2 = sqlQuery;
            string[] textArray2 = new string[] { str2, " or ", cols[i], " = ", colsvalues[i] };
            sqlQuery = string.Concat(textArray2);
        }
        return this.ExecuteQuery(sqlQuery);
    }

    public SqliteDataReader DeleteContents(string tableName)
    {
        string sqlQuery = "DELETE FROM " + tableName;
        return this.ExecuteQuery(sqlQuery);
    }

    public void deleteFullTable(string tableName)
    {
        string sqlQuery = "delete  FROM " + tableName;
        this.ExecuteQuery(sqlQuery);
    }

    public SqliteDataReader ExecuteQuery(string sqlQuery)
    {
        this.dbCommand = this.dbConnection.CreateCommand();
        this.dbCommand.CommandText = sqlQuery;
        this.reader = this.dbCommand.ExecuteReader();
        // XXX 需要释放，否则unity editor会一直占用着db文件，导致下次运行时报错
        disposeCommand();
        return this.reader;
    }

    public SqliteDataReader InsertInto(string tableName, string[] values)
    {
        string sqlQuery = "INSERT INTO " + tableName + " VALUES (" + values[0];
        for (int i = 1; i < values.Length; i++)
        {
            sqlQuery = sqlQuery + ", " + values[i];
        }
        sqlQuery = sqlQuery + ")";
        return this.ExecuteQuery(sqlQuery);
    }

    public SqliteDataReader InsertIntoSpecific(string tableName, string[] cols, string[] values)
    {
        if (cols.Length != values.Length)
        {
            throw new SqliteException("columns.Length != values.Length");
        }
        string sqlQuery = "INSERT INTO " + tableName + "(" + cols[0];
        for (int i = 1; i < cols.Length; i++)
        {
            sqlQuery = sqlQuery + ", " + cols[i];
        }
        sqlQuery = sqlQuery + ") VALUES (" + values[0];
        for (int j = 1; j < values.Length; j++)
        {
            sqlQuery = sqlQuery + ", " + values[j];
        }
        sqlQuery = sqlQuery + ")";
        return this.ExecuteQuery(sqlQuery);
    }

    public void OpenDB(string connectionString)
    {
        try
        {
            this.dbConnection = new SqliteConnection(connectionString);
            this.dbConnection.Open();
            ClientLog.Log("Connected to db ok!connectionString=" + connectionString);
        }
        catch (Exception exception)
        {
            ClientLog.LogError(exception.ToString() + connectionString);
        }
    }

    public SqliteDataReader ReadFullTable(string tableName)
    {
        string sqlQuery = "SELECT * FROM " + tableName;
        return this.ExecuteQuery(sqlQuery);
    }

    public SqliteDataReader SelectWhere(string tableName, string[] items, string[] col, string[] operation, string[] values)
    {
        if ((col.Length != operation.Length) || (operation.Length != values.Length))
        {
            throw new SqliteException("col.Length != operation.Length != values.Length");
        }
        string sqlQuery = "SELECT " + items[0];
        for (int i = 1; i < items.Length; i++)
        {
            sqlQuery = sqlQuery + ", " + items[i];
        }
        string str2 = sqlQuery;
        string[] textArray1 = new string[] { str2, " FROM ", tableName, " WHERE ", col[0], operation[0], "'", values[0], "' " };
        sqlQuery = string.Concat(textArray1);
        for (int j = 1; j < col.Length; j++)
        {
            str2 = sqlQuery;
            string[] textArray2 = new string[] { str2, " AND ", col[j], operation[j], "'", values[0], "' " };
            sqlQuery = string.Concat(textArray2);
        }
        return this.ExecuteQuery(sqlQuery);
    }

    public SqliteDataReader UpdateInto(string tableName, string[] cols, string[] colsvalues, string selectkey, string selectvalue)
    {
        string str2;
        string[] textArray1 = new string[] { "UPDATE ", tableName, " SET ", cols[0], " = ", colsvalues[0] };
        string sqlQuery = string.Concat(textArray1);
        for (int i = 1; i < colsvalues.Length; i++)
        {
            str2 = sqlQuery;
            string[] textArray2 = new string[] { str2, ", ", cols[i], " =", colsvalues[i] };
            sqlQuery = string.Concat(textArray2);
        }
        str2 = sqlQuery;
        string[] textArray3 = new string[] { str2, " WHERE ", selectkey, " = ", selectvalue, " " };
        sqlQuery = string.Concat(textArray3);
        return this.ExecuteQuery(sqlQuery);
    }
}

