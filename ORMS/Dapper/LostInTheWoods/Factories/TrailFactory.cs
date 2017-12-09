using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;

namespace LostInTheWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=lost_in_the_woods;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Trail nt)
        {
            using(IDbConnection cnx = Connection){
                string query = "INSERT INTO trails(Name, Description, Length, ElevationChange, Longitude, Latitude) VALUES (@Name, @Description, @Length, @ElevationChange, @Longitude, @Latitude)";
                cnx.Open();
                cnx.Execute(query, nt);
            }
        }

        public IEnumerable<Trail> GetAllTrails()
        {
            using(IDbConnection cnx = Connection){
                string query = "SELECT * FROM trails;";
                cnx.Open();
                return cnx.Query<Trail>(query);
            }
        }

        public Trail GetOneTrail(int id)
        {
            using(IDbConnection cnx = Connection){
                string query = $"SELECT * FROM trails WHERE id = {id};";
                cnx.Open();
                return cnx.Query<Trail>(query).FirstOrDefault();
            }
        }
    }
}