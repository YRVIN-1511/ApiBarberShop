using BCP.SLK.DATABASE;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Threading.Tasks;

namespace CROSS.DATABASE
{

    public class DBOptions : IDBOptions
    {
        public List<DBOptionItems> _dBOptions;
        public string Name { get; set; } = string.Empty;
        public DBOptions(IConfiguration configuration) {
            this._dBOptions = new();
            configuration.GetSection("database:connections").Bind(this._dBOptions);
            for (int i = 0; i <= this._dBOptions.Count - 1; i++)
            {
                string connection = "Persist Security Info=True;User ID=" + _dBOptions[i].User + ";Pwd=" + _dBOptions[i].Password + ";Server=" + this._dBOptions[i].Server + ";Database=" + this._dBOptions[i].DataBase + ";Application Name =" + this._dBOptions[i].Name;
                this._dBOptions[i].ConnectionString = connection;
            }
        }
        public DBOptionItems getItemOptions(string name)
        { 
            return this._dBOptions.Find(x => x.Name == name);
        }
    }
}