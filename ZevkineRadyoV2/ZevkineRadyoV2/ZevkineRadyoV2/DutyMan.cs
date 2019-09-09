using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ZevkineRadyoV2
{
	class DutyMan
	{
		private SqlConnection con;
		private SqlCommand cmd;

		public DutyMan()
		{
			Connect();
		}

		public void Connect()
		{
			con = new SqlConnection
				("Data Source=DESKTOP-KA1TM07\\SQLEXPRESS;Initial Catalog=baseStation;Integrated Security=True");
			cmd = new SqlCommand();
			cmd.Connection = con;
		}
		private void Missionary()
		{
			con.Open();
			cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			con.Close();
		}

		public List<string> Populate()
		{
			try
			{
				List<string> names = new List<string>();
				cmd.CommandText = "select * from baseStationTable";
				cmd.CommandType = CommandType.Text;
				con.Open();

				SqlDataReader dr;
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					names.Add(dr["name"].ToString());
				}
				con.Close();

				return names;
			}
			catch
			{
				throw;
			}
			finally
			{
				if(con != null)
				{
					con.Close();
				}
			}

		}

		public DataTable Fill()
		{

			try
			{

				cmd.CommandText = "Select * FROM baseStationTable";
				cmd.CommandType = CommandType.Text;
				con.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);
				con.Close();

				return dataTable;
			}
			catch
			{
				throw;
			}
			finally
			{
				if (con != null)
				{
					con.Close();
				}
			}

		}

		public string GiveTheMusic(string basename)
		{
			try
			{
				string frequency = "";
				cmd.CommandText = "select radioFrequency from baseStationTable where name = @base";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@base", basename);
				cmd.CommandType = CommandType.Text;
				con.Open();
				SqlDataReader dr;
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					frequency = dr[0].ToString();
				}
				con.Close();

				return frequency;

			}
			catch
			{
				throw;
			}
			finally
			{
				if(con != null)
				{
					con.Close();
				}
			}
		}

		public void Add(string name, string baseFrequency)
		{
			try
			{
				cmd.CommandText = "INSERT INTO baseStationTable(name, radioFrequency) values(@namedb, @baseFrequencydb)";
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@namedb", name);
				cmd.Parameters.AddWithValue("@baseFrequencydb", baseFrequency);
				Missionary();
			}
			catch
			{
				throw;
			}
			finally
			{
				if (con != null)
				{
					con.Close();
				}
			}
		}

		public void Delete(string name)
		{
			try
			{
				cmd.CommandText = "DELETE FROM baseStationTable  WHERE name = @namedb";
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@namedb", name);

				Missionary();
			}
			catch
			{
				throw;
			}
			finally
			{
				if (con != null)
				{
					con.Close();
				}
			}
		}


	}
}
