using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class ImagenRestauranteCrudFactory : CrudFactory
    {
        ImagenRestauranteMapper mapper;

        public ImagenRestauranteCrudFactory() : base()
        {
            mapper = new ImagenRestauranteMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var imgRest = (ImagenRestaurante)entity;
            var sqlOperation = mapper.GetCreateStatement(imgRest);
            dao.ExecuteProcedure(sqlOperation);
        }



        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var imgRest = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    imgRest.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return imgRest;
        }

        public override void Update(BaseEntity entity)
        {
            var imgRest = (ImagenRestaurante)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(imgRest));
        }

        public override void Delete(BaseEntity entity)
        {
            var imgRest = (ImagenRestaurante)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(imgRest));
        }


    }
}
