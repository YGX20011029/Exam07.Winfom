using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Dal
{
    public class MysqlDBhelper
    {//1.现获取数据库的连接字符串
        private string con = "server=127.0.0.1;User Id=root;password=1234;DataBase=oa";
        //执行添加、删除、修改的方法
        public int ExcuteSql(string sql)
        {
           
            int flag = 0;
            using (MySqlConnection connection = new MySqlConnection(con))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    flag= command.ExecuteNonQuery();
                }
            }
            return flag;
        }
        public DataTable Query(string sql)
        {
            DataTable table = new DataTable();
            //mysql对象
            using (MySqlConnection connection = new MySqlConnection(con))
            {
                //打开数据
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    //使用适配器填充数据到datatable中
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                    dataAdapter.Fill(table);
                }
            }
            return table;
        }

    }
}
