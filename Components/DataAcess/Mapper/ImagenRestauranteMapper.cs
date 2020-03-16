using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class ImagenRestauranteMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_Logo = "Logo";
        private const string DB_COL_IdRestaurante = "IdRestaurante";
        private const string DB_COL_Perfil = "Perfil";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateImagenRestaurante" };

            var i = (ImagenRestaurante)entity;

            operation.AddVarcharParam(DB_COL_Logo, i.Logo);
            operation.AddVarcharParam(DB_COL_IdRestaurante, i.IdRestaurante);
            operation.AddVarcharParam(DB_COL_Perfil, i.Perfil);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveImagenRestaurante" };

            var i = (ImagenRestaurante)entity;
            operation.AddVarcharParam(DB_COL_IdRestaurante, i.IdRestaurante);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllImagenes" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateImagenRestaurante" };

            var i = (ImagenRestaurante)entity;
            operation.AddVarcharParam(DB_COL_Logo, i.Logo);
            operation.AddVarcharParam(DB_COL_IdRestaurante, i.IdRestaurante);
            operation.AddVarcharParam(DB_COL_Perfil, i.Perfil);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteImagenRestaurante" };

            var i = (ImagenRestaurante)entity;
            operation.AddVarcharParam(DB_COL_IdRestaurante, i.IdRestaurante);
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
            var i = new ImagenRestaurante
            {
                Logo = GetStringValue(row, DB_COL_Logo),
                IdRestaurante = GetStringValue(row, DB_COL_IdRestaurante),
                Perfil = GetStringValue(row, DB_COL_Perfil)

            };
            return i;
        }
    }
}