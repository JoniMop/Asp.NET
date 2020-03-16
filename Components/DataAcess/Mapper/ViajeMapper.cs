using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class ViajeMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_IdTransport = "IdTransportista";
        private const string DB_COL_NombreTrans = "NombreTransportista";
        private const string DB_COL_TarifaBasica = "TarifaBasica";
        private const string DB_COL_KilometrosRecorridos = "KilometrosRecorridos";
        private const string DB_COL_DescuentoEcologico = "DescuentoEcologico";
        private const string DB_COL_PagoTotal = "PagoTotal";
        private const string DB_COL_Mapa = "Mapa";
        private const string DB_COL_PuntoPartidaLatitud = "PuntoPartidaLatitud";
        private const string DB_COL_PuntoPartidaLongitud = "PuntoPartidaLongitud";
        private const string DB_COL_PuntoLlegadaLatitud = "PuntoLlegadaLatitud";
        private const string DB_COL_PuntoLlegadaLongitud = "PuntoLlegadaLongitud";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateViaje" };

            var v = (Viaje)entity;

            operation.AddVarcharParam(DB_COL_IdTransport, v.IdTransportista);
            operation.AddDoubleParam(DB_COL_TarifaBasica, v.TarifaBasica);
            operation.AddDoubleParam(DB_COL_KilometrosRecorridos, v.KilometrosRecorridos);
            operation.AddDoubleParam(DB_COL_DescuentoEcologico, v.DescuentoEcologico);
            operation.AddDoubleParam(DB_COL_PagoTotal, v.PagoTotal);
            operation.AddVarcharParam(DB_COL_Mapa, v.Mapa);
            operation.AddDoubleParam(DB_COL_PuntoPartidaLatitud, v.PuntoPartidaLatitud);
            operation.AddDoubleParam(DB_COL_PuntoPartidaLongitud, v.PuntoPartidaLongitud);
            operation.AddDoubleParam(DB_COL_PuntoLlegadaLatitud, v.PuntoLlegadaLatitud);
            operation.AddDoubleParam(DB_COL_PuntoLlegadaLongitud, v.PuntoLlegadaLongitud);


            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveViajesXIdTransportista" };

            var v = (Viaje)entity;
            operation.AddVarcharParam(DB_COL_IdTransport, v.IdTransportista);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllViajes" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateViaje" };

            var v = (Viaje)entity;

            operation.AddVarcharParam(DB_COL_IdTransport, v.IdTransportista);
            operation.AddDoubleParam(DB_COL_TarifaBasica, v.TarifaBasica);
            operation.AddDoubleParam(DB_COL_KilometrosRecorridos, v.KilometrosRecorridos);
            operation.AddDoubleParam(DB_COL_DescuentoEcologico, v.DescuentoEcologico);
            operation.AddDoubleParam(DB_COL_PagoTotal, v.PagoTotal);
            operation.AddVarcharParam(DB_COL_Mapa, v.Mapa);
            operation.AddDoubleParam(DB_COL_PuntoPartidaLatitud, v.PuntoPartidaLatitud);
            operation.AddDoubleParam(DB_COL_PuntoPartidaLongitud, v.PuntoPartidaLongitud);
            operation.AddDoubleParam(DB_COL_PuntoLlegadaLatitud, v.PuntoLlegadaLatitud);
            operation.AddDoubleParam(DB_COL_PuntoLlegadaLongitud, v.PuntoLlegadaLongitud);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteViaje" };

            var v = (Viaje)entity;
            operation.AddVarcharParam(DB_COL_IdTransport, v.IdTransportista);
            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var viaje = BuildObject(row);
                lstResults.Add(viaje);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var v = new Viaje
            {
                IdTransportista = GetStringValue(row, DB_COL_IdTransport),
                NombreTransportista = GetStringValue(row, DB_COL_NombreTrans),
                TarifaBasica = GetDoubleValue(row, DB_COL_TarifaBasica),
                KilometrosRecorridos = GetDoubleValue(row, DB_COL_KilometrosRecorridos),
                DescuentoEcologico = GetDoubleValue(row, DB_COL_DescuentoEcologico),
                PagoTotal = GetDoubleValue(row, DB_COL_PagoTotal),
                Mapa = GetStringValue(row, DB_COL_Mapa),
                PuntoPartidaLatitud = GetDoubleValue(row, DB_COL_PuntoPartidaLatitud),
                PuntoPartidaLongitud = GetDoubleValue(row, DB_COL_PuntoPartidaLongitud),
                PuntoLlegadaLatitud = GetDoubleValue(row, DB_COL_PuntoLlegadaLatitud),
                PuntoLlegadaLongitud = GetDoubleValue(row, DB_COL_PuntoLlegadaLongitud),
            };
            return v;
        }

    }
}
