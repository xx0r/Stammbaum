﻿
namespace CoreDb
{


    public abstract class UniversalConnectionStringBuilder
    {
        protected System.Data.Common.DbConnectionStringBuilder m_ConnectionStringBuilder;
        protected DataBaseEngine_t m_DataBaseEngine;


        public static UniversalConnectionStringBuilder CreateInstance()
        {
            return new GenericUniversalConnectionStringBuilder();
        }


        public virtual DataBaseEngine_t Engine
        {
            get
            {
                return m_DataBaseEngine;
            }

            set
            {
                this.m_DataBaseEngine = value;
            }
        }



        public virtual string EngineName
        {
            get 
            {
                return m_DataBaseEngine.ToString();
            }
        }



        public static UniversalConnectionStringBuilder CreateInstance(DataBaseEngine_t DataBaseEngine)
        {
            return CreateInstance(DataBaseEngine, null);
        }


        public static UniversalConnectionStringBuilder CreateInstance(DataBaseEngine_t DataBaseEngine, string connectionString)
        {
            UniversalConnectionStringBuilder csb = null;
            
            switch (DataBaseEngine)
            {
                case DataBaseEngine_t.MS_SQL:
                    csb = new MS_SQLUniversalConnectionStringBuilder(connectionString);
                    break;
                case DataBaseEngine_t.PostGreSQL:
                    csb = new PostGreUniversalConnectionStringBuilder(connectionString);
                    break;
                case DataBaseEngine_t.Oracle:
                    csb = new OracleUniversalConnectionStringBuilder(connectionString);
                    break;
                case DataBaseEngine_t.FireBird:
                    csb = new FirebirdUniversalConnectionStringBuilder(connectionString);
                    break;
                default:
                    csb = new GenericUniversalConnectionStringBuilder(connectionString);
                    break;
            }



            csb.Engine = DataBaseEngine;
            return csb;
        }


        public UniversalConnectionStringBuilder()
        {
            this.m_ConnectionStringBuilder = new System.Data.Common.DbConnectionStringBuilder();
        }

        public UniversalConnectionStringBuilder(string connectionString)
        {
            this.m_ConnectionStringBuilder = new System.Data.Common.DbConnectionStringBuilder();
            this.m_ConnectionStringBuilder.ConnectionString = connectionString;
        }


        public virtual System.Data.Common.DbConnectionStringBuilder csb
        {
            get
            {
                return this.m_ConnectionStringBuilder;
            }
        }


        public virtual string ApplicationName
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Application Name"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Application Name"] = value;
            }
        }


        public virtual string Server
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Server"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Server"] = value;
            }
        }

        public virtual int Port
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["Port"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Port"] = value;
            }
        }



        public virtual string PortString
        {
            get
            {
                return ":" + this.Port.ToString();
            }
            
        }


        public virtual string FailoverPartner
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Failover Partner"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Failover Partner"] = value;
            }
        }


        public virtual string DataBase
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Database"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Database"] = value;
            }
        }


        public virtual bool IntegratedSecurity
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["Integrated Security"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Integrated Security"] = value;
            }
        }


        public virtual string UserName
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["UserName"];
            }
            set
            {
                this.m_ConnectionStringBuilder["UserName"] = value;
            }
        }

        public virtual string Password
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Password"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Password"] = value;
            }

        }


        public virtual bool IsReadOnly
        {
            get
            {
                object val;
                var x = m_ConnectionStringBuilder.TryGetValue("IsReadOnly", out val);
                return (bool)val;
            }
        }


        public virtual bool TrustServerCertificate
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["TrustServerCertificate"];
            }
            set
            {
                this.m_ConnectionStringBuilder["TrustServerCertificate"] = value;
            }
        }


        public virtual bool SSL
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["SSL"];
            }
            set
            {
                this.m_ConnectionStringBuilder["SSL"] = value;
            }
        }


        public virtual bool PersistSecurityInfo
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["PersistSecurityInfo"];
            }
            set
            {
                this.m_ConnectionStringBuilder["PersistSecurityInfo"] = value;
            }
        }


        public virtual bool IsFixedSize
        {
            get
            {
                object val;
                var x = m_ConnectionStringBuilder.TryGetValue("IsFixedSize", out val);
                return (bool)val;
                //return this.m_ConnectionStringBuilder.IsFixedSize;
            }
        }


        public virtual bool Replication
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["Replication"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Replication"] = value;
            }
        }


        public virtual bool Pooling
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["Pooling"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Pooling"] = value;
            }
        }


        public virtual int MinPoolSize
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["MinPoolSize"];
            }
            set
            {
                this.m_ConnectionStringBuilder["MinPoolSize"] = value;
            }
        }


        public virtual int MaxPoolSize
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["MaxPoolSize"];
            }
            set
            {
                this.m_ConnectionStringBuilder["MaxPoolSize"] = value;
            }
        }


        public virtual bool Enlist
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["Enlist"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Enlist"] = value;
            }
        }


        public virtual bool PreloadReader
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["PreloadReader"];
            }
            set
            {
                this.m_ConnectionStringBuilder["PreloadReader"] = value;
            }
        }


        // Gets flag indicating if we are using Synchronous notification or not. The default value is false.
        public virtual bool SyncNotification
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["SyncNotification"];
            }
            set
            {
                this.m_ConnectionStringBuilder["SyncNotification"] = value;
            }
        }


        public virtual bool AsynchronousProcessing
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["AsynchronousProcessing"];
            }
            set
            {
                this.m_ConnectionStringBuilder["AsynchronousProcessing"] = value;
            }
        }


        public virtual int PacketSize
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["PacketSize"];
            }
            set
            {
                this.m_ConnectionStringBuilder["PacketSize"] = value;
            }
        }


        // ConnectionTimeout=0 is bad, make it something reasonable like 30 seconds. 
        public virtual int ConnectTimeout
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["ConnectTimeout"];
            }
            set
            {
                this.m_ConnectionStringBuilder["ConnectTimeout"] = value;
            }
        }


        // how long a connection lives before it is killed and recreated. 
        // A lifetime of 0 means never kill and recreate. 
        // Through various bugs your connections may get stuck in an unstable state 
        // (like when dealing with weird 3 way transactions).. 
        // but 99% of the time it is good to keep connection lifetime as infinite.
        public virtual int ConnectionLifeTime
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["ConnectionLifeTime"];
            }
            set
            {
                this.m_ConnectionStringBuilder["ConnectionLifeTime"] = value;
            }
        }


        public virtual int CommandTimeout
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["CommandTimeout"];
            }
            set
            {
                this.m_ConnectionStringBuilder["CommandTimeout"] = value;
            }
        }


        public virtual int LoadBalanceTimeout
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["LoadBalanceTimeout"];
            }
            set
            {
                this.m_ConnectionStringBuilder["LoadBalanceTimeout"] = value;
            }
        }


        public virtual int MaxPageCount
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["MaxPageCount"];
            }
            set
            {
                this.m_ConnectionStringBuilder["MaxPageCount"] = value;
            }
        }


        public virtual int PageSize
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["PageSize"];
            }
            set
            {
                this.m_ConnectionStringBuilder["PageSize"] = value;
            }
        }


        public virtual int DbCachePages
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["DbCachePages"];
            }
            set
            {
                this.m_ConnectionStringBuilder["DbCachePages"] = value;
            }
        }


        public virtual int Dialect
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["Dialect"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Dialect"] = value;
            }
        }


        public virtual string ConnectionString
        {
            get
            {
                return this.m_ConnectionStringBuilder.ConnectionString;
            }
            set
            {
                this.m_ConnectionStringBuilder.ConnectionString = value;
            }

        }


        public virtual string SearchPath
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["SearchPath"];
            }
            set
            {
                this.m_ConnectionStringBuilder["SearchPath"] = value;
            }

        }


        public virtual string CurrentLanguage
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["CurrentLanguage"];
            }
            set
            {
                this.m_ConnectionStringBuilder["CurrentLanguage"] = value;
            }

        }


        public virtual string WorkstationID
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["WorkstationID"];
            }
            set
            {
                this.m_ConnectionStringBuilder["WorkstationID"] = value;
            }

        }


        public virtual string ClientLibrary
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["ClientLibrary"];
            }
            set
            {
                this.m_ConnectionStringBuilder["ClientLibrary"] = value;
            }

        }


        public virtual string Charset
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Charset"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Charset"] = value;
            }

        }


        public virtual string Role
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Role"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Role"] = value;
            }

        }


        public virtual string Driver
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Driver"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Driver"] = value;
            }

        }


        public virtual string Dsn
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Dsn"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Dsn"] = value;
            }

        }


        public virtual string FileName
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["FileName"];
            }
            set
            {
                this.m_ConnectionStringBuilder["FileName"] = value;
            }

        }


        public virtual string Provider
        {
            get
            {
                return (string)this.m_ConnectionStringBuilder["Provider"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Provider"] = value;
            }

        }


        public virtual int OleDbServices
        {
            get
            {
                return (int)this.m_ConnectionStringBuilder["OleDbServices"];
            }
            set
            {
                this.m_ConnectionStringBuilder["OleDbServices"] = value;
            }
        }


        public virtual bool OmitOracleConnectionName
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["OmitOracleConnectionName"];
            }
            set
            {
                this.m_ConnectionStringBuilder["OmitOracleConnectionName"] = value;
            }

        }


        public virtual bool Unicode
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["Unicode"];
            }
            set
            {
                this.m_ConnectionStringBuilder["Unicode"] = value;
            }

        }


        public virtual bool ContextConnection
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["ContextConnection"];
            }
            set
            {
                this.m_ConnectionStringBuilder["ContextConnection"] = value;
            }

        }


        public virtual bool ReturnRecordsAffected
        {
            get
            {
                return (bool)this.m_ConnectionStringBuilder["ReturnRecordsAffected"];
            }
            set
            {
                this.m_ConnectionStringBuilder["ReturnRecordsAffected"] = value;
            }

        }



        public static void Tests()
        {
            System.Data.Common.DbConnectionStringBuilder dbcsb = new System.Data.Common.DbConnectionStringBuilder();


            System.Data.SqlClient.SqlConnectionStringBuilder sqlcsb =
                new System.Data.SqlClient.SqlConnectionStringBuilder();

            // sqlcsb.NetworkLibrary = "";
            //sqlcsb.TransactionBinding
            sqlcsb.TypeSystemVersion = "";
            sqlcsb.UserInstance = true;




            Npgsql.NpgsqlConnectionStringBuilder csb =
                new Npgsql.NpgsqlConnectionStringBuilder();

            // csb.Protocol
            // csb.Compatible
            //csb.SslMode = Npgsql.SslMode.Require;
            // csb.UseExtendedTypes


            /*
            System.Data.OracleClient.OracleConnectionStringBuilder ocb = new System.Data.OracleClient.OracleConnectionStringBuilder();

            FirebirdSql.Data.FirebirdClient.FbConnectionStringBuilder fbcsb = new FirebirdSql.Data.FirebirdClient.FbConnectionStringBuilder();
            fbcsb.ServerType = FirebirdSql.Data.FirebirdClient.FbServerType.Embedded;


            Mono.Data.Sqlite.SqliteConnectionStringBuilder litecsb = new Mono.Data.Sqlite.SqliteConnectionStringBuilder();
            litecsb.BinaryGUID = true;
            litecsb.DateTimeFormat = Mono.Data.Sqlite.SQLiteDateFormats.ISO8601;
            litecsb.DefaultIsolationLevel = System.Data.IsolationLevel.ReadCommitted;
            litecsb.DefaultTimeout = 123;
            litecsb.FailIfMissing = true;
            litecsb.JournalMode = Mono.Data.Sqlite.SQLiteJournalModeEnum.Off;
            litecsb.LegacyFormat = false;
            litecsb.SyncMode = Mono.Data.Sqlite.SynchronizationModes.Full;
            litecsb.Uri = "";

            litecsb.Version = 123;



            MySql.Data.MySqlClient.MySqlConnectionStringBuilder mycb = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
            mycb.AllowBatch = true;
            mycb.CertificateFile = "";
            mycb.CertificatePassword = "";
            mycb.CertificateStoreLocation = MySql.Data.MySqlClient.MySqlCertificateStoreLocation.LocalMachine;
            mycb.CertificateThumbprint = "";
            mycb.CharacterSet = "";
            mycb.CheckParameters = true;
            mycb.ConnectionLifeTime = 123;
            mycb.ConnectionProtocol = MySql.Data.MySqlClient.MySqlConnectionProtocol.Tcp;
            mycb.ConnectionReset = true;
            mycb.ConvertZeroDateTime = false;
            mycb.DefaultCommandTimeout = 123;
            mycb.FunctionsReturnString = true;
            mycb.IgnorePrepare = true;
            mycb.InteractiveSession = false;
            mycb.Keepalive = 123;
            mycb.PipeName = "";


            System.Data.Odbc.OdbcConnectionStringBuilder odbc = new System.Data.Odbc.OdbcConnectionStringBuilder();
            //System.Data.OleDb.OleDbConnectionStringBuilder oledb = new System.Data.OleDb.OleDbConnectionStringBuilder();
            */

        } // End Sub 


    } // End Class 


}
