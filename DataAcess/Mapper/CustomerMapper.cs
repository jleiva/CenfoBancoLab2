using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class CustomerMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_CEDULA = "CEDULA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDO = "APELLIDO";
        private const string DB_COL_GENERO = "GENERO";
        private const string DB_COL_EST_CIVIL = "EST_CIVIL";
        private const string DB_COL_FEC_NAC = "FEC_NAC";
        private const string DB_COL_AGE = "AGE";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_CLIENTE_PR"};

            var c = (Customer) entity;            
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO, c.Apellido);
            operation.AddVarcharParam(DB_COL_GENERO, c.Genero);
            operation.AddVarcharParam(DB_COL_EST_CIVIL, c.EstadoCivil);
            operation.AddVarcharParam(DB_COL_FEC_NAC, c.FechaNacimiento);
            operation.AddIntParam(DB_COL_AGE, c.Edad);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "RET_CLIENTE_PR"};

            var c = (Customer)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);
         
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CLIENTE_PR" };            
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CLIENTE_PR" };

            var c = (Customer)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO, c.Apellido);
            operation.AddVarcharParam(DB_COL_GENERO, c.Genero);
            operation.AddVarcharParam(DB_COL_EST_CIVIL, c.EstadoCivil);
            operation.AddVarcharParam(DB_COL_FEC_NAC, c.FechaNacimiento);
            operation.AddIntParam(DB_COL_AGE, c.Edad);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CLIENTE_PR" };

            var c = (Customer)entity;
            operation.AddVarcharParam(DB_COL_CEDULA, c.Cedula);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;            
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var customer = new Customer
            {
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido = GetStringValue(row, DB_COL_APELLIDO),
                Genero = GetStringValue(row, DB_COL_GENERO),
                EstadoCivil = GetStringValue(row, DB_COL_EST_CIVIL),
                FechaNacimiento = GetStringValue(row, DB_COL_FEC_NAC),
                Edad = GetIntValue(row, DB_COL_AGE)
            };

            return customer;
        }

        public BaseEntity BuildCompleteObject(Dictionary<string, object> row)
        {
            var customer = new Customer
            {
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido = GetStringValue(row, DB_COL_APELLIDO),
                Genero = GetStringValue(row, DB_COL_GENERO),
                EstadoCivil = GetStringValue(row, DB_COL_EST_CIVIL),
                FechaNacimiento = GetStringValue(row, DB_COL_FEC_NAC),
                Edad = GetIntValue(row, DB_COL_AGE)
            };

            return customer;
        }

    }
}
