using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace HouseRentalAndSales
{

    class Handle
    {
        private DAL dal;
        private int id;
        private string passWord;
        public Handle()
        {
            dal = new DAL();
        }
        public Handle(int id, string pass)
        {
            this.id = id;
            this.passWord = pass;
            dal = new DAL();
        }

        public string getRole()
        {
            return dal.sendRole(id, passWord); ;
        }

        public string getFullName()
        {
            return dal.sendFullName(id, passWord);
        }
        public DataTable getCustomer(int idCust, string spName)
        {
            DataTable dt = new DataTable();
            dt = dal.getCustomer(idCust, spName);
            return dt;
        }
        public void updateCust(string fname, string lname, string phone, int id, string spName)
        {
            dal.updateCust(fname, lname, phone, id, spName);
        }
        public string insertCust(string fname, string lname, string phone, string spName)
        {
            return dal.insertCust(fname, lname, phone, spName);
        }
        public DataTable getProperty(string spName, int id)
        {
            DataTable dt = new DataTable();
            dt = dal.getProperty(spName, id);
            return dt;
        }
        public void updateProperty(string Address, string Type, string status, string sale, int price, int rooms, int id)
        {
            dal.updateProperty(Address, Type, status, sale, price, rooms, id);
        }
        public void addPicture(int id, byte[] pic)
        {
            dal.enterPicture(id, pic);
        }
        public DataTable searchProperty(int value1, int value2, int v1, int v2, string text2, string text3)
        {
            DataTable dt = new DataTable();
            dt = dal.searchProperty(value1, value2, v1, v2, text2, text3);
            return dt;
        }
        public DataTable searchImage(int id)
        {
            DataTable dt = new DataTable();
            dt = dal.searchImage(id);
            return dt;
        }
        public void insertAudit(int custId, int ownID, int propID, int empID, string type)
        {
            dal.insertAudit(custId, ownID, propID, empID, type);
        }
        public DataTable getID(string spName)
        {
            DataTable dt = new DataTable();
            dt = dal.getID(spName);
            return dt;
        }
        public string addEmp(string fname,string lname, string pass, string role)
        {
            try
            {
                string Id = dal.insertEmployee(fname, lname, pass, role);
                return Id;
            }
            catch (Error e1)
            {
                throw new Error(e1.Message);
            }
        }
        public void updateEmployee(string fname, string lname, string pass, string role, int id)
        {
            dal.updateEmployee(fname, lname, pass, role, id);
        }
        public void deleteEmp(int id,string spName)
        {
            dal.deleteEmp(id,spName);
        }
        public void backUp()
        {
            if(Directory.Exists("C:\\DB BACKUPS"))
            {
                if(File.Exists("C:\\DB BACKUPS\\HRAS_DB.bak"))
                {
                    File.Delete("C:\\DB BACKUPS\\HRAS_DB.bak");
                    dal.backUpDatabase();
                }
                else
                {
                    dal.backUpDatabase();
                }
            }
            else
            {
                Directory.CreateDirectory("C:\\DB BACKUPS");
                dal.backUpDatabase();
            }
        }
    }
}
