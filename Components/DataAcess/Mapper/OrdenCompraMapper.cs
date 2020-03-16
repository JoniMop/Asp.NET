using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class OrdenCompraMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_IdOC = "IdOrdenCompra";
        private const string DB_COL_IdRestaurante = "IdRestaurante";
        private const string DB_COL_nombreRestaurante = "NombreComercial"; //read only
        private const string DB_COL_IdCliente = "IdCliente";
        private const string DB_COL_nombreCliente = "NombreCliente"; //read only
        private const string DB_COL_IdViaje = "IdViaje";
        private const string DB_COL_Subtotal = "Subtotal";
        private const string DB_COL_IVA = "IVA";
        private const string DB_COL_Total = "Total";
        private const string DB_COL_CodigoQR = "CodigoQR";
        private const string DB_COL_CalificacionRestaurante = "CalificacionRestaurante";
        private const string DB_COL_CalificacionTransporte = "CalificacionTransporte";
        private const string DB_COL_EstadoOrden = "EstadoOrden";
        private const string DB_COL_Reclamo = "Reclamo";
        private const string DB_COL_RespuestaReclamo = "RespuestaReclamo";



        //OBTENER PRIMERO LOS PRODUCTOS DEL CARRITO
        public SqlOperation GetProductosXOrden(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaAsignarProductosXOrden" };

            var oc = (OrdenCompra)entity;
            operation.AddVarcharParam(DB_COL_IdOC, oc.IdOrdenCompra);

            return operation;
        }


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateOrdenCompra" };

            var oc = (OrdenCompra)entity;

            operation.AddVarcharParam(DB_COL_IdOC, oc.IdOrdenCompra);
            operation.AddVarcharParam(DB_COL_IdRestaurante, oc.IdRestaurante);
            operation.AddVarcharParam(DB_COL_IdCliente, oc.IdCliente);
            operation.AddIntParam(DB_COL_IdViaje, oc.IdViaje);
            operation.AddDoubleParam(DB_COL_Subtotal, oc.Subtotal);
            operation.AddDoubleParam(DB_COL_IVA, oc.IVA);
            operation.AddDoubleParam(DB_COL_Total, oc.Total);
            operation.AddVarcharParam(DB_COL_CodigoQR, oc.CodigoQR);
            operation.AddIntParam(DB_COL_CalificacionRestaurante, oc.CalificacionRestaurante);
            operation.AddIntParam(DB_COL_CalificacionTransporte, oc.CalificacionTransporte);
            operation.AddVarcharParam(DB_COL_EstadoOrden, oc.EstadoOrden);
            operation.AddVarcharParam(DB_COL_Reclamo, oc.Reclamo);
            operation.AddVarcharParam(DB_COL_RespuestaReclamo, oc.RespuestaReclamo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveOrdenCompra" };

            var oc = (OrdenCompra)entity;
            operation.AddVarcharParam(DB_COL_IdOC, oc.IdOrdenCompra);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllOrdenesCompra" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateOrdenCompra" };

            var oc = (OrdenCompra)entity;

            operation.AddVarcharParam(DB_COL_IdOC, oc.IdOrdenCompra);
            operation.AddVarcharParam(DB_COL_IdRestaurante, oc.IdRestaurante);
            operation.AddVarcharParam(DB_COL_IdCliente, oc.IdCliente);
            operation.AddIntParam(DB_COL_IdViaje, oc.IdViaje);
            operation.AddDoubleParam(DB_COL_Subtotal, oc.Subtotal);
            operation.AddDoubleParam(DB_COL_IVA, oc.IVA);
            operation.AddDoubleParam(DB_COL_Total, oc.Total);
            operation.AddVarcharParam(DB_COL_CodigoQR, oc.CodigoQR);
            operation.AddIntParam(DB_COL_CalificacionRestaurante, oc.CalificacionRestaurante);
            operation.AddIntParam(DB_COL_CalificacionTransporte, oc.CalificacionTransporte);
            operation.AddVarcharParam(DB_COL_EstadoOrden, oc.EstadoOrden);
            operation.AddVarcharParam(DB_COL_Reclamo, oc.Reclamo);
            operation.AddVarcharParam(DB_COL_RespuestaReclamo, oc.RespuestaReclamo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteOrdenCompra" };

            var oc = (OrdenCompra)entity;
            operation.AddVarcharParam(DB_COL_IdOC, oc.IdOrdenCompra);
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
            var oc = new OrdenCompra
            {
                IdOrdenCompra = GetStringValue(row, DB_COL_IdOC),
                IdRestaurante = GetStringValue(row, DB_COL_IdRestaurante),
                NombreComercial = GetStringValue(row, DB_COL_nombreRestaurante), //read only
                IdCliente = GetStringValue(row, DB_COL_IdCliente),
                NombreCliente = GetStringValue(row, DB_COL_nombreCliente), //read only
                IdViaje = GetIntValue(row, DB_COL_IdViaje),
                Subtotal = GetDoubleValue(row, DB_COL_Subtotal),
                IVA = GetDoubleValue(row, DB_COL_IVA),
                Total = GetDoubleValue(row, DB_COL_Total),
                CodigoQR = GetStringValue(row, DB_COL_CodigoQR),
                CalificacionRestaurante = GetIntValue(row, DB_COL_CalificacionRestaurante),
                CalificacionTransporte = GetIntValue(row, DB_COL_CalificacionTransporte),
                EstadoOrden = GetStringValue(row, DB_COL_EstadoOrden),
                Reclamo = GetStringValue(row, DB_COL_Reclamo),
                RespuestaReclamo = GetStringValue(row, DB_COL_RespuestaReclamo)
            };

            return oc;
        }

    }
}