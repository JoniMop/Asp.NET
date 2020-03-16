using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class FacturaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_FacturaPDF = "FacturaPDF";
        private const string DB_COL_IdUsuario = "IdUsuario";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateFactura" };

            var f = (Factura)entity;

            operation.AddVarcharParam(DB_COL_FacturaPDF, f.FacturaPDF);
            operation.AddVarcharParam(DB_COL_IdUsuario, f.IdUsuario);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveFacturaXIdUsuario" };

            var f = (Factura)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, f.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllFacturas" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateFactura" };

            var f = (Factura)entity;
            operation.AddVarcharParam(DB_COL_FacturaPDF, f.FacturaPDF);
            operation.AddVarcharParam(DB_COL_IdUsuario, f.IdUsuario);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteFactura" };

            var f = (Factura)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, f.IdUsuario);
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
            var f = new Factura
            {
                FacturaPDF = GetStringValue(row, DB_COL_FacturaPDF),
                IdUsuario = GetStringValue(row, DB_COL_IdUsuario)
            };
            return f;
        }
    }
}