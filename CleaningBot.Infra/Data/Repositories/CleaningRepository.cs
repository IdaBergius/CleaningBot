using System;
using CleaningBot.Core.Models;
using CleaningBot.Core.Services;
using Npgsql;

namespace CleaningBot.Infra.Data.Repositories
{
    public class CleaningRepository
    {
        private string ConnectionString { get; set; }
        private readonly CleaningService cleaningService = new CleaningService();

        public CleaningRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Save(Instruction instruction)
        {
            var result = cleaningService.Clean(instruction);
            string sql = @$" INSERT INTO executions
                                ( Id
                                 ,NoOfCommands
                                 ,UniqeLocationsCleaned 
                                 ,Timestamp
                                 ,Duration  )

                               VALUES
                                (  NEWID()
                                 ,{result.NoOfCommands}
                                 ,{result.UniqeLocationsCleaned}
                                 ,{DateTime.Now}
                                 ,{result.Duration}  )
                                ";

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(ConnectionString);

                conn.Open();

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQueryAsync();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
        }

        public string GetById(int id)
        {
            string sql = @$" SELECT * FROM executions
                             WHERE Id = {id}
                             FOR JSON AUTO
                            ";
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(ConnectionString);

                conn.Open();

               using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        return Convert.ToString(reader.Read());
                    }
                }
            
                    conn.Close();
            }
            catch (Exception ex)
            {
                // _logger.Error(ex.Message);
                throw;
            }

            return "";
        }
      

    }
}
