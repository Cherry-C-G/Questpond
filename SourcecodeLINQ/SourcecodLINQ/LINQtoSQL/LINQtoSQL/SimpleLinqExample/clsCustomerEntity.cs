using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;
using System.Data.Linq;
namespace SimpleLinqExample
{
    
    // This is a simple class with LINQ mappings
    [Table(Name = "Customer")]
    public class clsCustomerEntity
    {
        [Column(DbType= "nvarchar(50)")]
        public string CustomerCode;

        [Column(DbType = "nvarchar(50)")]
        public string CustomerName;
    }

    // This is a simple LINQ class with encapsulated properties
    [Table(Name = "Customer")]
    public class clsCustomerEntityWithProperties
    {
        private int _CustomerId;
        private string _CustomerCode;
        private string _CustomerName;
       
        [Column(DbType = "nvarchar(50)")]
        public string CustomerCode
        {
            set
            {
                _CustomerCode = value;
            }
            get
            {
                return _CustomerCode;
            }
        }

        [Column(DbType = "nvarchar(50)")]
        public string CustomerName
        {
            set
            {
                _CustomerName = value;
            }
            get
            {
                return _CustomerName;
            }
        }

        [Column(DbType = "int", IsPrimaryKey = true)]
        public int CustomerId
        {
            set
            {
                _CustomerId = value;
            }
            get
            {
                return _CustomerId;
            }
        }
    }

    // This is a simple class which shows customer and addresses
    // relationship using entityset
    [Table(Name = "Customer")]
    public class clsCustomerWithAddresses
    {
        private int _CustomerId;
        private string _CustomerCode;
        private string _CustomerName;
        private EntitySet<clsAddresses> _CustomerAddresses;

        [Column(DbType="int",IsPrimaryKey=true)]
        public int CustomerId
        {
            set
            {
                _CustomerId = value;
            }
            get
            {
                return _CustomerId;
            }
        }
        
        [Column(DbType = "nvarchar(50)")]
        public string CustomerCode
        {
            set
            {
                _CustomerCode = value;
            }
            get
            {
                return _CustomerCode;
            }
        }
        
        [Column(DbType = "nvarchar(50)")]
        public string CustomerName
        {
            set
            {
                _CustomerName = value;
            }
            get
            {
                return _CustomerName;
            }
        }

        [Association(Storage = "_CustomerAddresses",ThisKey="CustomerId", OtherKey = "CustomerId")]
        public EntitySet<clsAddresses> Addresses
        {
            set
            {
                _CustomerAddresses = value;
            }
            get
            {
                return _CustomerAddresses;
            }

        }
    }
    [Table(Name = "CustomerAddresses")]
    
    public class clsAddresses
    {
        private int _Customerid;
        private int _AddressId;
        private string _Address1;
        private EntityRef<clsPhone> _Phone;
        [Column(DbType="int")]
        public int CustomerId
        {
            set
            {
                _Customerid = value;
            }
            get
            {
                return _Customerid;
            }
        }
        [Column(DbType = "int", IsPrimaryKey = true)]
        public int AddressId
        {
            set
            {
                _AddressId = value;
            }
            get
            {
                return _AddressId;
            }
        }
        [Column(DbType = "nvarchar(50)")]
        public string Address1
        {
            set
            {
                _Address1 = value;
            }
            get
            {
                return _Address1;
            }
        }
        [Association(Storage = "_Phone", 
         ThisKey = "AddressId", OtherKey = "AddressId")]
        public clsPhone Phone
        {
            set
            {
                _Phone.Entity = value;
            }
            get
            {
                return _Phone.Entity;
            }
        }
    }

    [Table(Name = "Phone")]
    public class clsPhone
    {
        private int _PhoneId;
        private int _AddressId;
        private string _MobilePhone;
        private string _LandLine;
        
        [Column(DbType = "int", IsPrimaryKey = true)]
        public int PhoneId
        {
            set
            {
                _PhoneId = value;
            }
            get
            {
                return _PhoneId;
            }
        }
        [Column(DbType = "int")]
        public int AddressId
        {
            set
            {
                _PhoneId = value;
            }
            get
            {
                return _PhoneId;
            }
        }
        [Column(DbType = "nvarchar")]
        public string MobilePhone
        {
            set
            {
                _MobilePhone = value;
            }
            get
            {
                return _MobilePhone;
            }
        }
        [Column(DbType = "nvarchar")]
        public string LandLine
        {
            set
            {
                _LandLine = value;
            }
            get
            {
                return _LandLine;
            }
        }
    }

   
}
