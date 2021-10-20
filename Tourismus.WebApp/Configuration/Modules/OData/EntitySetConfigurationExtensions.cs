using Microsoft.AspNet.OData.Builder;

namespace Tourismus.WebApp.Configuration.Modules.OData {

    public static class EntitySetConfigurationExtensions {
        public static EntitySetConfiguration<TEntityType> AddGetList<TEntityType, TResult>(this EntitySetConfiguration<TEntityType> entitySetConfiguration) where TEntityType : class {
            entitySetConfiguration.EntityType
                .Collection
                .Function("GetList")
                .ReturnsCollection<TResult>();

            return entitySetConfiguration;
        }
    }
}