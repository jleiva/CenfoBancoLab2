using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class LocalizationMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_VALOR = "VALOR";
        private const string DB_COL_CLIENTEID = "CLIENTEID";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_LOCALIZATION_PR" };

            var c = (Localization)entity;
            operation.AddVarcharParam(DB_COL_TIPO, c.Tipo);
            operation.AddVarcharParam(DB_COL_VALOR, c.Valor);
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LOCALIZATION_PR" };

            var c = (Localization)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LOCALIZATION_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_LOCALIZATION_PR" };

            var c = (Localization)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_TIPO, c.Tipo);
            operation.AddVarcharParam(DB_COL_VALOR, c.Valor);
            operation.AddVarcharParam(DB_COL_CLIENTEID, c.ClienteId);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_LOCALIZATION_PR" };

            var c = (Localization)entity;
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
            var localization = new Localization
            {
                Id = GetIntValue(row, DB_COL_ID),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                Valor = GetStringValue(row, DB_COL_VALOR),
                ClienteId = GetStringValue(row, DB_COL_CLIENTEID)
            };

            return localization;
        }
    }
}
