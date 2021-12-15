
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using MonoTouch.Foundation;
using Mono.Data.Sqlite;
using MonoTouch.UIKit;
using SynPsg.iPhoneUtil;

namespace SPC2010DemoClient
{
	public static class Util
	{
		public static MonoTouch.UIKit.UINavigationController NavController{ get; set; }

		
		public static void SetupTextField(UITextField tf)
		{
			tf.ShouldReturn = delegate(UITextField textfield) {
				textfield.ResignFirstResponder();
				return true;
			};
		}
		
		public static bool CheckDatabase()
		{
			Debug.WriteLine("APP: Checking for existing database");
			bool retval=true;
			string dbSpec = getDatabaseFileSpec();
			if (!File.Exists(dbSpec))
				retval = createDatabase(dbSpec);
			return retval;
		}
		
		public static void RefreshCustomers()
		{
			Debug.WriteLine("APP: Deleting customers from cache");

			SqliteConnection conn = new SqliteConnection("Data Source=" + getDatabaseFileSpec());
			SqliteCommand cmd = conn.CreateCommand();

			try
			{
				cmd.CommandText = "DELETE FROM CUSTOMERS";
				cmd.CommandType = CommandType.Text;
				conn.Open();
				cmd.ExecuteNonQuery();
				Debug.WriteLine("APP: Finished deleting customers");
				populateDatabase(conn);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("APP: ERROR: " + ex.Message);
			}
			finally
			{
				if (conn.State!=ConnectionState.Closed)
					conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
		}
		
		private static string getDatabaseFileSpec()
		{
			string databaseName = "AppDatabase.db3";
			string documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(documents,databaseName);
		}
		
		private static bool createDatabase(string dbSpec)
		{
			bool retval = true;
			
			try
			{
				Debug.WriteLine("APP: Creating new database");
				SqliteConnection.CreateFile(dbSpec);
				retval = createDatabaseTables(dbSpec);
			}
			catch
			{
				//Failed to create database	
				retval = false;
			}
			return retval;
		}
		
		private static bool createDatabaseTables(string dbSpec)
		{
			Debug.WriteLine("APP: Creating database tables");
			
			bool retval = true;

			SqliteConnection conn = new SqliteConnection("Data Source=" + dbSpec);
			SqliteCommand cmd = conn.CreateCommand();

			try
			{
				cmd.CommandText = "CREATE TABLE CUSTOMERS (CUSTOMER_ID BIGINT PRIMARY KEY, CUSTOMER_NAME VARCHAR(50))";
				cmd.CommandType = CommandType.Text;
				conn.Open();
				cmd.ExecuteNonQuery();
				//Now populate the database with initial data
				populateDatabase(conn);
			}
			catch 
			{
				retval = false;
			}
			finally
			{
				if (conn.State!=ConnectionState.Closed)
					conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
			
			return retval;
		}
		
		private static bool populateDatabase(SqliteConnection conn)
		{
			bool retval = true;
			SPC2010.SPC2010WebService svc = null;
			int customerCount = 0;
			
			try
			{
				//Get a collection of customers from the web service

				Debug.WriteLine("APP: Downloading customers from web service");			
				svc = new SPC2010.SPC2010WebService();
				SPC2010.Customer[] customers = svc.GetCustomers();
				
				//Insert the customers into the database
	
				Debug.WriteLine("APP: Inserting customers into database");
				SqliteCommand cmd;

				try
				{
					foreach (SPC2010.Customer customer in customers)
					{
						customerCount++;
						cmd = new SqliteCommand("INSERT INTO CUSTOMERS(CUSTOMER_ID,CUSTOMER_NAME) VALUES(@CustomerId,@CustomerName)",conn);
						cmd.Parameters.Add(new SqliteParameter("@CustomerId",customer.CustomerId));
						cmd.Parameters.Add(new SqliteParameter("@CustomerName",customer.CustomerName));
						cmd.ExecuteNonQuery();
						cmd.Dispose();
					}
					string msg = String.Format("{0} customer records were downloaded and stored locally. You can refresh your customer list by clcking the refresh button at the bottom of the customers screen.",customerCount);
					Debug.WriteLine("APP: " + msg);
					UiTools.InfoMessage("Customers Downloaded",msg);
					}
				catch (Exception ex)
				{
					Debug.WriteLine("APP: DATABASE ERROR: " + ex.Message);
					retval = false;
				}
				finally
				{
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("APP: WEB SERVICE ERROR: " + ex.Message);
			}
			finally
			{
				svc.Dispose();
			}
			
			return retval;
		}
		
		public static List<SPC2010.Customer>  GetCustomersFromDatabase()
		{
			List<SPC2010.Customer> customers = new List<SPC2010.Customer>();

			SqliteConnection conn = new SqliteConnection("Data Source=" + getDatabaseFileSpec());
			SqliteCommand cmd = new SqliteCommand("SELECT CUSTOMER_ID, CUSTOMER_NAME FROM CUSTOMERS",conn);
			conn.Open();
			SqliteDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows==true)
			{
				SPC2010.Customer customer;
				while (dr.Read())
				{
					customer = new SPC2010.Customer();
					customer.CustomerId = Convert.ToInt32(dr["CUSTOMER_ID"]);
					customer.CustomerName = Convert.ToString(dr["CUSTOMER_NAME"]);
					customers.Add(customer);
				}
			}

			dr.Dispose();
			conn.Close();
			conn.Dispose();
			
			return customers;
		}

		public static List<SPC2010.Customer>  GetCustomersFromDatabase(string filter)
		{
			List<SPC2010.Customer> customers = new List<SPC2010.Customer>();

			SqliteConnection conn = new SqliteConnection("Data Source=" + getDatabaseFileSpec());
			SqliteCommand cmd = new SqliteCommand("SELECT CUSTOMER_ID, CUSTOMER_NAME FROM CUSTOMERS WHERE CUSTOMER_NAME LIKE '%" +filter+"%'",conn);
			conn.Open();
			SqliteDataReader dr = cmd.ExecuteReader();

			if (dr.HasRows==true)
			{
				SPC2010.Customer customer;
				while (dr.Read())
				{
					customer = new SPC2010.Customer();
					customer.CustomerId = Convert.ToInt32(dr["CUSTOMER_ID"]);
					customer.CustomerName = Convert.ToString(dr["CUSTOMER_NAME"]);
					customers.Add(customer);
				}
			}

			dr.Dispose();
			conn.Close();
			conn.Dispose();
			
			return customers;
		}
	}
}
