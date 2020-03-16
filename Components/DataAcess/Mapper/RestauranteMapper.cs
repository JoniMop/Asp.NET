using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class RestauranteMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_CedulaJuridica = "CedulaJuridica";
        private const string DB_COL_NombreComercial = "NombreComercial";
        private const string DB_COL_IdEncargado = "IdEncargado";
        private const string DB_COL_Categoria = "Categoria";
        private const string DB_COL_HorarioOpen = "HorarioOpen";
        private const string DB_COL_HorarioClose = "HorarioClose";
        




        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateRestaurante" };

            var r = (Restaurante)entity;

            operation.AddVarcharParam(DB_COL_CedulaJuridica, r.CedulaJuridica);
            operation.AddVarcharParam(DB_COL_NombreComercial, r.NombreComercial);
            operation.AddVarcharParam(DB_COL_IdEncargado, r.IdEncargado);
            operation.AddVarcharParam(DB_COL_Categoria, r.Categoria);
            operation.AddVarcharParam(DB_COL_HorarioOpen, r.HorarioOpen);
            operation.AddVarcharParam(DB_COL_HorarioClose, r.HorarioClose);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveRestauranteXcedulaJuridica" };

            var r = (Restaurante)entity;
            operation.AddVarcharParam(DB_COL_CedulaJuridica, r.CedulaJuridica);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllRestaurantes" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateRestaurante" };

            var r = (Restaurante)entity;

            operation.AddVarcharParam(DB_COL_CedulaJuridica, r.CedulaJuridica);
            operation.AddVarcharParam(DB_COL_NombreComercial, r.NombreComercial);
            operation.AddVarcharParam(DB_COL_IdEncargado, r.IdEncargado);
            operation.AddVarcharParam(DB_COL_Categoria, r.Categoria);
            operation.AddVarcharParam(DB_COL_HorarioOpen, r.HorarioOpen);
            operation.AddVarcharParam(DB_COL_HorarioClose, r.HorarioClose);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteRestaurante" };

            var r = (Restaurante)entity;
            operation.AddVarcharParam(DB_COL_CedulaJuridica, r.CedulaJuridica);
            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var restaurante = BuildObject(row);
                lstResults.Add(restaurante);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var restaurante = new Restaurante
            {

                CedulaJuridica = GetStringValue(row, DB_COL_CedulaJuridica),
                NombreComercial = GetStringValue(row, DB_COL_NombreComercial),
                IdEncargado = GetStringValue(row, DB_COL_IdEncargado),
                Categoria = GetStringValue(row, DB_COL_Categoria),
                HorarioOpen = GetStringValue(row, DB_COL_HorarioOpen),
                HorarioClose = GetStringValue(row, DB_COL_HorarioClose)
            };

            return restaurante;
        }

    }
}