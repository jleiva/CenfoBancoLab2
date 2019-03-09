using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class AddressMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_CLIENTEID = "CLIENTEID";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ADDRESS_PR" };

            var c = (Address)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ADDRESS_PR" };

            var c = (Address)entity;
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ADDRESS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ADDRESS_PR" };

            var c = (Address)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ADDRESS_PR" };

            var c = (Address)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var address = BuildObject(row);
                lstResults.Add(address);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var address = new Address
            {
                Id = GetIntValue(row, DB_COL_ID),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                ClienteId = GetStringValue(row, DB_COL_CLIENTEID)
            };

            return address;
        }
    }
}
