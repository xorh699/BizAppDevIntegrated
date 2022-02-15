using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace BizAppDev
{
    public class Order
    {
        string _connStr = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        private DateTime _purchaseDate;
        private DateTime _deliveryDate;
        private int _Cust_ID;
        private string _status;
        private string _deliveryType;
        private int orderID;

    }
}