using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConnect
/// </summary>
public class DatabaseConnect
{
	public DatabaseConnect()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private static DataClassesDataContext dataContext = null;
    public static DataClassesDataContext DataContext
    {
        get
        {
            if (dataContext == null)
            {
                dataContext = new DataClassesDataContext();
                dataContext.Connection.ConnectionString = "Data Source=461f27e0-e0f1-4766-adca-a12f00da8405.sqlserver.sequelizer.com;Initial Catalog=db461f27e0e0f14766adcaa12f00da8405;User ID=pdupqqrutnndunei;Password=LWAUjmMPbDuSvyMSgf2DAJ22tQYczrpDyrnTWNpMeSN3JwV8UMVQL2qb4GzBvKoS";
            }
            return dataContext;
        }
    }
}
