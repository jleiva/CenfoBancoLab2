using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class CreditMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_TASA = "TASA";
        private const string DB_COL_CLIENTEID = "CLIENTEID";
        private const string DB_COL_CUOTA = "CUOTA";
        private const string DB_COL_FEC_INIC = "FEC_INIC";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_SALDO = "SALDO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CREDITO_PR" };

            var c = (Credit)entity;
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);
            operation.AddDoubleParam(DB_COL_TASA, c.Tasa);
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);
            operation.AddDoubleParam(DB_COL_CUOTA, c.Cuota);
            operation.AddVarcharParam(DB_COL_FEC_INIC, c.FechaInicio);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CREDITO_PR" };

            var c = (Credit)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CREDITO_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CREDITO_PR" };

            var c = (Credit)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);
            operation.AddDoubleParam(DB_COL_TASA, c.Tasa);
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);
            operation.AddDoubleParam(DB_COL_CUOTA, c.Cuota);
            operation.AddVarcharParam(DB_COL_FEC_INIC, c.FechaInicio);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CREDITO_PR" };

            var c = (Credit)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var credit = BuildObject(row);
                lstResults.Add(credit);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var credit = new Credit
            {
                Id = GetIntValue(row, DB_COL_ID),
            };

            return credit;
        }
    }
}
