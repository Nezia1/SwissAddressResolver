using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SwissAddressResolver
{
    public class PostDatabase
    {
        MySqlConnection connection;

        public PostDatabase()
        {
            connection = new MySqlConnection("Server=localhost;User ID=root;Database=poste");
            connection.Open();
        }

        public List<Street> ConvertPLZToStreetNames(int plz)
        {
            List<Street> result = new List<Street>();
            var query = new MySqlCommand(String.Format("SELECT new_plz1.PLZ, new_plz1.ORT_BEZ_18, new_str.STR_BEZ_2l FROM new_str INNER JOIN new_plz1 ON new_plz1.ONRP = new_str.ONRP WHERE plz = {0}", plz), connection);
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Street() { Plz = Convert.ToInt32(reader.GetValue(0)), Municipality = reader.GetValue(1).ToString(), StreetName = reader.GetValue(2).ToString() });
            }
            return result;
        }

        public List<Plz> ConvertStreetNameToPLZ(string streetName)
        {
            List<Plz> result = new List<Plz>();
            var query = new MySqlCommand(String.Format("SELECT new_plz1.PLZ FROM new_plz1 INNER JOIN new_str ON new_str.ONRP = new_plz1.ONRP WHERE new_str.STR_BEZ_2l LIKE \"%{0}%\"", streetName), connection);
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Plz() { Number = Convert.ToInt32(reader.GetValue(0)) });
            }
            return result;
        }

    }
}
