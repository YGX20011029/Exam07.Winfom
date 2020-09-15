using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;

namespace Exam07.Winfom
{
    public class DALModel
    {
        MysqlDBhelper dBhelper = new MysqlDBhelper();
        public List<DataModel> Getgen(int id)
        {
            string sql = $"select * from City where CId={id}";
            DataTable dt = dBhelper.Query(sql);
            var json = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<List<DataModel>>(json);
            return list;
        }
        
        
    }
}
