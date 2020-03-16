using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class DocumentoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        
        private const string DB_COL_IdUsuario = "IdUsuario";
        private const string DB_COL_VehiculoEcologico = "VehiculoEcologico";
        private const string DB_COL_TipoVehiculo = "TipoVehiculo";
        private const string DB_COL_LicenciaConducir = "LicenciaConducir";
        private const string DB_COL_PermisoMinSalud = "PermisoMinSalud";
       


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateDocument" };

            var d = (Documento)entity;
            
            operation.AddVarcharParam(DB_COL_IdUsuario, d.IdUsuario);
            operation.AddVarcharParam(DB_COL_VehiculoEcologico, d.VehiculoEcologico);
            operation.AddVarcharParam(DB_COL_TipoVehiculo, d.TipoVehiculo);
            operation.AddVarcharParam(DB_COL_LicenciaConducir, d.LicenciaConducir);
            operation.AddVarcharParam(DB_COL_PermisoMinSalud, d.PermisoMinSalud);
           
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveDocumentXIdUsuario" };

            var d = (Documento)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, d.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllDocuments" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateDocument" };

            var d = (Documento)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, d.IdUsuario);
            operation.AddVarcharParam(DB_COL_VehiculoEcologico, d.VehiculoEcologico);
            operation.AddVarcharParam(DB_COL_TipoVehiculo, d.TipoVehiculo);
            operation.AddVarcharParam(DB_COL_LicenciaConducir, d.LicenciaConducir);
            operation.AddVarcharParam(DB_COL_PermisoMinSalud, d.PermisoMinSalud);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteDocument" };

            var d = (Documento)entity;
            operation.AddVarcharParam(DB_COL_IdUsuario, d.IdUsuario);
            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var document= BuildObject(row);
                lstResults.Add(document);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var documento = new Documento
            {
                
                IdUsuario = GetStringValue(row, DB_COL_IdUsuario),
                VehiculoEcologico = GetStringValue(row, DB_COL_VehiculoEcologico),
                TipoVehiculo = GetStringValue(row, DB_COL_TipoVehiculo),
                LicenciaConducir = GetStringValue(row, DB_COL_LicenciaConducir),
                PermisoMinSalud = GetStringValue(row, DB_COL_PermisoMinSalud)
               
            };

            return documento;
        }

    }
}