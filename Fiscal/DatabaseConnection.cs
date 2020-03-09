using System.Data.SqlClient;
using System.Text;

namespace FiscalApp
{
    public sealed class DatabaseConnection
    {
        public static SqlConnection DEBUGConnection
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=");
                sb.Append(@"C:\Users\sobebe01\source\repos\FiscalApp\Fiscal\bin\Debug\App_Data\Database.mdf");
                sb.Append(";Integrated Security=True");

                //global::FiscalApp.Properties.Settings.Default.dbProgram = sb.ToString();

                return new SqlConnection(sb.ToString());
            }
        }

    }
}