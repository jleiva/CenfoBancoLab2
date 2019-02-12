using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class AccountMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_CLIENTEID = "CLIENTEID";
        private const string DB_COL_MONEDA = "MONEDA";
        private const string DB_COL_SALDO = "SALDO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CUENTA_PR" };

            var c = (Account)entity;
            operation.AddVarcharParam(DB_COL_MONEDA, c.Moneda);
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CUENTA_PR" };

            var c = (Account)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CUENTA_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CUENTA_PR" };

            var c = (Account)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);
            operation.AddVarcharParam(DB_COL_MONEDA, c.Moneda);
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CUENTA_PR" };

            var c = (Account)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var account = BuildObject(row);
                lstResults.Add(account);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var account = new Account
            {
                Id = GetIntValue(row, DB_COL_ID),
                Moneda = GetStringValue(row, DB_COL_MONEDA),
                ClienteId = GetStringValue(row, DB_COL_CLIENTEID),
                Saldo = GetDoubleValue(row, DB_COL_SALDO)
            };

            return account;
        }
    }
}
