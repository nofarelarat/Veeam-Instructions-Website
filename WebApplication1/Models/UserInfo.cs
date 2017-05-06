using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Threading.Tasks;
using MySql.Data;
using System.ComponentModel;
using WebApplication1.Models;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace WebApplication1.Models
{
    public class UserInfo
    {
        private int id;
        private string name;
        private string pass;

        public UserInfo(int id, string name, string pass)
        {
            this.id = id;
            this.name = name;
            this.pass = pass;
        }
        public bool TestOnDB(users user)
        {
            Model1 testcontext = new Model1();
            if (testcontext.users.Find(user.id) == null)
            {
                return false;
            }
            
            return true;
        }
        public int getid()
        {
            return (this.id);
        }
        public string getname()
        {
            return (this.name);
        }
        public string getpass()
        {
            return (this.pass);
        }
        public bool AddUser ()
        {
            Model1 testcontext = new Model1();
            users tmp = new users();
            tmp.id = this.id;
            tmp.name = this.name;
            tmp.passsword = this.pass;
            if(TestOnDB(tmp) == true)
            {
                return false;
            }
            try
            {
                testcontext.users.Add(tmp);
                testcontext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool DeleteUser(int id)
        {
            Model1 testcontext = new Model1();
            users tmp = testcontext.users.First(i => i.id == id);
            if (tmp == null)
            {
                return true;
            }
            try
            {
                testcontext.users.Remove(tmp);
                testcontext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public void GetUser(int id)
        {
            Model1 testcontext = new Model1();
            users tmp = new users();
            try
            {
                tmp = testcontext.users.First(i => i.id == id);

            }
            catch
            {

            }
            this.id = tmp.id;
            this.name = tmp.name;
            this.pass = tmp.passsword;
        }
        public bool EditUserName(int id, string newname)
        {
            Model1 testcontext = new Model1();
            users tmp = new users();
            try
            {
                tmp = testcontext.users.First(i => i.id == id);
                UserInfo newuser = new UserInfo(tmp.id, newname, tmp.passsword);
                DeleteUser(id);
                newuser.AddUser();
                testcontext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool EditUserpass(int id, string newpass)
        {
            Model1 testcontext = new Model1();
            users tmp = new users();
            try
            {
                tmp = testcontext.users.First(i => i.id == id);
                UserInfo newuser = new UserInfo(tmp.id, tmp.name, newpass);
                DeleteUser(id);
                newuser.AddUser();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}