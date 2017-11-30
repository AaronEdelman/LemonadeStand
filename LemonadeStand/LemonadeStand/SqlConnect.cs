using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System;

namespace LemonadeStand
{
    class SqlConnect
    {
        SqlConnection seed = new SqlConnection("Data Source=.;Initial Catalog=LemonadeStandScore;Integrated Security=True");

        public void ExecuteSqlTransaction(string name)
        {
            using (SqlConnection seed = new SqlConnection(name))
            {
                seed.Open();
                SqlCommand command = seed.CreateCommand();
                SqlTransaction transaction;

                transaction = seed.BeginTransaction("SampleTransaction");

                command.Connection = seed;
                command.Transaction = transaction;

                    command.CommandText =
                "Insert into LemonadeScore (Name, Profit) Values (name, profit)";
                    command.ExecuteNonQuery();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
            }
        }
    }
}
