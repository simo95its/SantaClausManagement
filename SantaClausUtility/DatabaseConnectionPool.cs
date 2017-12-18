using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

namespace SantaClausUtility
{
    //public class DatabaseConnectionPool
    //{
    //    // Connections will hold an array of 100 connections
    //    private IDbConnection[] Connections;
    //    private int POOL_SIZE = 100;
    //    private int MAX_IDLE_TIME = 10;

    //    // Locks array will hold integers 1 or 0
    //    // 1 means connection in use, 0 free.
    //    private int[] Locks;
    //    //Dates will hold the latest date and time the connection was used.
    //    private DateTime[] Dates;

    //    //Check for a free connection 
    //    //What the method actually does is to loop over all items in the array, and look for a 0 value.
    //    public IDbConnection GetConnection(out int identifier)
    //    {
    //        for (int i = 0; i < POOL_SIZE; i++)
    //        {
    //            //This thread-safe method does an atomic operation
    //            //checking the value and changing it,
    //            //all in the same operation,
    //            //and guarantees that no other thread will check the same slot at the same time
    //            //If the value is 0, set it to 1.
    //            //The next thread will see this slot as busy 
    //            //and will continue to the next slot.
    //            //Inside the Interlocked block, we can check 
    //            //the last time the connection was used, or if it was never initialized,
    //            //and create aa new one. 
    //            //Now that we have a free connection, we return it, along with the identifier
    //            //(the index in the connection array)
    //            if (Interlocked.CompareExchange(ref Locks[i], 1, 0) == 0)
    //            {
    //                if (Dates[i] != DateTime.MinValue && (DateTime.Now - Dates[i]).TotalMinutes > MAX_IDLE_TIME)
    //                {
    //                    Connections[i].Dispose();
    //                    Connections[i] = null;
    //                }
    //                if (Connections[i] == null)
    //                {
    //                    IDbConnection conn = CreateConnection();
    //                    Connections[i] = conn;
    //                    conn.Open();
    //                }
    //                Dates[i] = DateTime.Now;
    //                identifier = i;
    //                return Connections[i];
    //            }
    //        }
    //        throw new Exception("No free connections");
    //    }

    //    public IDbConnection CreateConnection()
    //    {
    //        return new SqlConnection(this.ConnectionString);
    //    }

    //    //The FreeConnection method simply puts back the value ’0′ in the array, 
    //    //freeing the connection so other thread can use it. We don’t need to call 
    //    //Dispose on the connection any more, since the connections are managed by our pool.
    //    public void FreeConnection(int identifier)
    //    {
    //        if (identifier < 0 || identifier >= POOL_SIZE)
    //        {
    //            return;
    //        }
    //        Interlocked.Exchange(ref Locks[identifier], 0);
    //    }
    //}

    //public class TestClass
    //{
    //    public void Test()
    //    {
    //        DatabaseConnectionPool a = new DatabaseConnectionPool();
    //        int iConn = 0;
    //        try
    //        {
    //            IDbConnection conn = a.GetConnection(out iConn);
    //            using (IDbCommand cmd = conn.CreateCommand())
    //            {
    //                cmd.CommandText = "QUERY";
    //                cmd.ExecuteNonQuery();
    //            }
    //        }
    //        finally
    //        {
    //            a.FreeConnection(iConn);
    //        }
    //    }
    //}
}
