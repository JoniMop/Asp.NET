using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class ProductoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_CodigoProducto = "CodigoProducto";
        private const string DB_COL_NombreProducto = "NombreProducto";
        private const string DB_COL_DescripcionProducto = "DescripcionProducto";
        private const string DB_COL_PrecioProducto = "PrecioProducto";
        private const string DB_COL_Descuento = "Descuento";
        private const string DB_COL_IdRestaurante = "IdRestaurante";
        private const string DB_COL_Imagen = "Imagen";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateProducto" };

            var p = (Producto)entity;
            operation.AddVarcharParam(DB_COL_CodigoProducto, p.CodigoProducto);
            operation.AddVarcharParam(DB_COL_NombreProducto, p.NombreProducto);
            operation.AddVarcharParam(DB_COL_DescripcionProducto, p.DescripcionProducto);
            operation.AddDoubleParam(DB_COL_PrecioProducto, p.PrecioProducto);
            operation.AddDoubleParam(DB_COL_Descuento, p.Descuento);
            operation.AddVarcharParam(DB_COL_IdRestaurante, p.IdRestaurante);
            operation.AddVarcharParam(DB_COL_Imagen, p.Imagen);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveProductosXCodProducto" };

            var p = (Producto)entity;
            operation.AddVarcharParam(DB_COL_CodigoProducto, p.CodigoProducto);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllProductos" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateProducto" };

            var p = (Producto)entity;
            operation.AddVarcharParam(DB_COL_CodigoProducto, p.CodigoProducto);
            operation.AddVarcharParam(DB_COL_NombreProducto, p.NombreProducto);
            operation.AddVarcharParam(DB_COL_DescripcionProducto, p.DescripcionProducto);
            operation.AddDoubleParam(DB_COL_PrecioProducto, p.PrecioProducto);
            operation.AddDoubleParam(DB_COL_Descuento, p.Descuento);
            operation.AddVarcharParam(DB_COL_IdRestaurante, p.IdRestaurante);
            operation.AddVarcharParam(DB_COL_Imagen, p.Imagen);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteProducto" };

            var p = (Producto)entity;
            operation.AddVarcharParam(DB_COL_CodigoProducto, p.CodigoProducto);
            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var producto = BuildObject(row);
                lstResults.Add(producto);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var p = new Producto
            {
                CodigoProducto = GetStringValue(row, DB_COL_CodigoProducto),
                NombreProducto = GetStringValue(row, DB_COL_NombreProducto),
                DescripcionProducto = GetStringValue(row, DB_COL_DescripcionProducto),
                PrecioProducto = GetDoubleValue(row, DB_COL_PrecioProducto),
                Descuento = GetDoubleValue(row, DB_COL_Descuento),
                IdRestaurante = GetStringValue(row, DB_COL_IdRestaurante),
                Imagen = GetStringValue(row, DB_COL_Imagen)
            };

            return p;
        }

    }
}