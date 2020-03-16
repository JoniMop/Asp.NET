using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class TransaccionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_IdUsuario = "IdUsuario";
        private const string DB_COL_Debito = "Debito";
        private const string DB_COL_Credito = "Credito";
        private const string DB_COL_Detalle = "Detalle";
        private const string DB_COL_Fecha = "Fecha";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateTransaccion" };

            var t= (Transaccion)entity;

            operation.AddVarcharParam(DB_COL_IdUsuario, t.IdUsuario);
            operation.AddDoubleParam(DB_COL_Debito, t.Debito);
            operation.AddDoubleParam(DB_COL_Credito, t.Credito);
            operation.AddVarcharParam(DB_COL_Detalle, t.Detalle);
            operation.AddDateParam(DB_COL_Fecha, t.Fecha);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveTransaccionXIdUsuario" };

            var t = (Transaccion)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, t.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllTransacciones" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateTransaccion" };

            var t = (Transaccion)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, t.IdUsuario);
            operation.AddDoubleParam(DB_COL_Debito, t.Debito);
            operation.AddDoubleParam(DB_COL_Credito, t.Credito);
            operation.AddVarcharParam(DB_COL_Detalle, t.Detalle);
            operation.AddDateParam(DB_COL_Fecha, t.Fecha);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteTransaccion" };

            var t = (Transaccion)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, t.IdUsuario);
            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var transacion = BuildObject(row);
                lstResults.Add(transacion);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var p = new Transaccion
            {

                IdUsuario = GetStringValue(row, DB_COL_IdUsuario),
                Debito = GetDoubleValue(row, DB_COL_Debito),
                Credito = GetDoubleValue(row, DB_COL_Credito),
                Detalle = GetStringValue(row, DB_COL_Detalle),
                Fecha = GetDateValue(row, DB_COL_Fecha),
            };

            return p;
        }

    }
}