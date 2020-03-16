using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper

{
    public class UsuarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_Cedula = "Cedula";
        private const string DB_COL_Nombre = "Nombre";
        private const string DB_COL_Apellidos = "Apellidos";
        private const string DB_COL_Provincia = "Provincia";
        private const string DB_COL_Canton = "Canton";
        private const string DB_COL_Distrito = "Distrito";
        private const string DB_COL_Mapa = "Mapa";
        private const string DB_COL_Telefono = "Telefono";
        private const string DB_COL_Email = "Email";
        private const string DB_COL_Contrasena = "Contrasena";
        private const string DB_COL_Rol = "Rol";
        private const string DB_COL_IdPaypal = "IdPaypal";
        private const string DB_COL_CodigoAsignado = "CodigoAsignado";
        private const string DB_COL_CodigoVerificacion = "CodigoVerificacion";

        //tabla rolXusuario
        private const string DB_COL_IdRol = "IdRol";
        private const string DB_COL_IdUsuario = "IdUsuario";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaCreateUsuario" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_Cedula, u.Cedula);
            operation.AddVarcharParam(DB_COL_Nombre, u.Nombre);
            operation.AddVarcharParam(DB_COL_Apellidos, u.Apellidos);
            operation.AddVarcharParam(DB_COL_Provincia, u.Provincia);
            operation.AddVarcharParam(DB_COL_Canton, u.Canton);
            operation.AddVarcharParam(DB_COL_Distrito, u.Distrito);
            operation.AddVarcharParam(DB_COL_Mapa, u.Mapa);
            operation.AddIntParam(DB_COL_Telefono, u.Telefono);
            operation.AddVarcharParam(DB_COL_Email, u.Email);
            operation.AddVarcharParam(DB_COL_Contrasena, u.Contrasena);
            operation.AddVarcharParam(DB_COL_Rol, u.Rol);
            operation.AddVarcharParam(DB_COL_IdPaypal, u.IdPaypal);
            operation.AddVarcharParam(DB_COL_CodigoAsignado, u.CodigoAsignado);
            operation.AddVarcharParam(DB_COL_CodigoVerificacion, u.CodigoVerificacion);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveUsuarioXcedula" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_Cedula, u.Cedula);

            return operation;
        }


        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveAllUsuarios" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaUpdateUsuario" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_Cedula, u.Cedula);
            operation.AddVarcharParam(DB_COL_Nombre, u.Nombre);
            operation.AddVarcharParam(DB_COL_Apellidos, u.Apellidos);
            operation.AddVarcharParam(DB_COL_Provincia, u.Provincia);
            operation.AddVarcharParam(DB_COL_Canton, u.Canton);
            operation.AddVarcharParam(DB_COL_Distrito, u.Distrito);
            operation.AddVarcharParam(DB_COL_Mapa, u.Mapa);
            operation.AddIntParam(DB_COL_Telefono, u.Telefono);
            operation.AddVarcharParam(DB_COL_Email, u.Email);
            operation.AddVarcharParam(DB_COL_Contrasena, u.Contrasena);
            operation.AddVarcharParam(DB_COL_Rol, u.Rol);
            operation.AddVarcharParam(DB_COL_IdPaypal, u.IdPaypal);
            operation.AddVarcharParam(DB_COL_CodigoAsignado, u.CodigoAsignado);
            operation.AddVarcharParam(DB_COL_CodigoVerificacion, u.CodigoVerificacion);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaDeleteUsuario" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_Cedula, u.Cedula);
            return operation;
        }


        //----------------------LOGIN--------------------------//
        public SqlOperation GetRetriveLoginInfo(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PaRetrieveInfoLogin" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_Email, u.Email);

            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                Cedula = GetStringValue(row, DB_COL_Cedula),
                Nombre = GetStringValue(row, DB_COL_Nombre),
                Apellidos = GetStringValue(row, DB_COL_Apellidos),
                Provincia = GetStringValue(row, DB_COL_Provincia),
                Canton = GetStringValue(row, DB_COL_Canton),
                Distrito = GetStringValue(row, DB_COL_Distrito),
                Mapa = GetStringValue(row, DB_COL_Mapa),
                Telefono = GetIntValue(row, DB_COL_Telefono),
                Email = GetStringValue(row, DB_COL_Email),
                Contrasena = GetStringValue(row, DB_COL_Contrasena),
                Rol = GetStringValue(row, DB_COL_Rol),
                IdPaypal = GetStringValue(row, DB_COL_IdPaypal),
                CodigoAsignado = GetStringValue(row, DB_COL_CodigoAsignado),
                CodigoVerificacion = GetStringValue(row, DB_COL_CodigoVerificacion),
            };

            return usuario;
        }

    }
}
