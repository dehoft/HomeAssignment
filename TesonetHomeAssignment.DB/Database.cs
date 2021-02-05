using System.Configuration;
using System.Data.SqlClient;
using TesonetHomeAssignment.DB.Models;

namespace TesonetHomeAssignment.DB
{
    public static class Database
    {
        public static (string, bool) GetSqlConnection(string connectionStringName = "Playground")
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName]?.ConnectionString;
            if (connectionString == null)
                return ("", false);  
            
            string password = get_prase_after_word(connectionString, "password=", ";");
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    connection.Close();
                    return (connectionString, true);
                }
                catch
                {
                    return (connectionString, false);                   
                }
            }
        }

        private static string get_prase_after_word(string search_string_in, string word_before_in, string word_after_in)
        {
            int myStartPos = 0;
            string myWorkString = "";            

            if (!string.IsNullOrEmpty(word_before_in) && search_string_in.Contains(word_before_in))
            {
                myStartPos = search_string_in.ToLower().IndexOf(word_before_in) + word_before_in.Length;                               
                myWorkString = search_string_in.Substring(myStartPos, search_string_in.Length - myStartPos).Trim();

                if (!string.IsNullOrEmpty(word_after_in))
                {
                    myWorkString = myWorkString.Substring(0, myWorkString.IndexOf(word_after_in)).Trim();
                }
            }
            else
            {
                myWorkString = string.Empty;
            }
            return myWorkString.Trim();
        }                
    }
}
