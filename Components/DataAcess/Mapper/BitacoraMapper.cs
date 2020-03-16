using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class BitacoraMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_FechaHora = "FechaHora";
        private const string DB_COL_DescripcionCRUD = "DescripcionCRUD";
        private const string DB_COL_IdUsuario = "IdUsuario";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateBitacora" };

            var b = (Bitacora)entity;

            operation.AddDateParam(DB_COL_FechaHora, b.FechaHora);
            operation.AddVarcharParam(DB_COL_DescripcionCRUD, b.DescripcionCRUD);
            operation.AddVarcharParam(DB_COL_IdUsuario, b.IdUsuario);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveBitacoraXidUsuario" };

            var b = (Bitacora)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, b.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllBitacoras" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateBitacora" };

            var b = (Bitacora)entity;
            operation.AddDateParam(DB_COL_FechaHora, b.FechaHora);
            operation.AddVarcharParam(DB_COL_DescripcionCRUD, b.DescripcionCRUD);
            operation.AddVarcharParam(DB_COL_IdUsuario, b.IdUsuario);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteBitacora" };

            var b = (Bitacora)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, b.IdUsuario);
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
            var b = new Bitacora
            {
                FechaHora = GetDateValue(row, DB_COL_FechaHora),
                DescripcionCRUD = GetStringValue(row, DB_COL_DescripcionCRUD),
                IdUsuario = GetStringValue(row, DB_COL_IdUsuario)
            };
            return b;
        }

    }
}