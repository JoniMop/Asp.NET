using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class MembresiaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_IdUsuario = "IdUsuario";
        private const string DB_COL_MontoMembresiaAnual = "MontoMembresiaAnual";
        private const string DB_COL_Estado = "Estado";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateMembresia" };

            var m = (Membresia)entity;

            operation.AddVarcharParam(DB_COL_IdUsuario, m.IdUsuario);
            operation.AddDoubleParam(DB_COL_MontoMembresiaAnual, m.MontoMembresiaAnual);
            operation.AddVarcharParam(DB_COL_Estado, m.Estado);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveMembresiaXidUsuario" };

            var m = (Membresia)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, m.IdUsuario);
            //operation.AddDoubleParam(DB_COL_MontoMembresiaAnual, m.MontoMembresiaAnual);
            //  operation.AddVarcharParam(DB_COL_Estado, m.Estado);  

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllMembresias" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateMembresia" };

            var m = (Membresia)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, m.IdUsuario);
            operation.AddDoubleParam(DB_COL_MontoMembresiaAnual, m.MontoMembresiaAnual);
            operation.AddVarcharParam(DB_COL_Estado, m.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteMembresia" };

            var m = (Membresia)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, m.IdUsuario);
            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var document = BuildObject(row);
                lstResults.Add(document);
            }
            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var m = new Membresia
            {
                IdUsuario = GetStringValue(row, DB_COL_IdUsuario),
                MontoMembresiaAnual = GetDoubleValue(row, DB_COL_MontoMembresiaAnual),
                Estado = GetStringValue(row, DB_COL_Estado)

            };
            return m;
        }
    }
}