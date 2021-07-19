using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace XuModel
{
    //加入映射
    public  class XuDtoMapper
    {
        //配置映射关系
        public static void Initialize()
        {
            Mapper.Initialize(DbMapper);
        }
        private static void DbMapper(IMapperConfigurationExpression cfg)
        {
            //先找出Model所有实体类
            List<Type> modelTypes = Assembly.Load("XuDb").GetTypes().ToList();
            //model对应的Dto实体(注意:这里我做了命名约定,所有对应实体的Dto对象都以Dto结尾)
            List<Type> modelDtoTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name.EndsWith("Dto")).ToList();
            foreach (var dtoType in modelDtoTypes)
            {
                var modelType = modelTypes.Where(t => t.Name.StartsWith(dtoType.Name.Replace("Dto", ""))).First();
                cfg.CreateMap(dtoType, modelType);
                cfg.CreateMap(modelType, dtoType);
            }
        }
    }
}
