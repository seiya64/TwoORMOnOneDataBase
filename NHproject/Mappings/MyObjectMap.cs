using FluentNHibernate.Mapping;
using NHproject.Entities;

namespace NHproject.Mappings
{
    public class MyObjectMap : ClassMap<MyObject>
    {
        public MyObjectMap()
        {
            this.DynamicInsert();
            this.DynamicUpdate();
            this.OptimisticLock.Version();
            this.Version(x => x.Version)
                .CustomSqlType("timestamp")
                .Generated.Always().Unique();

            this.SetupMapping();
        }

        private void SetupMapping()
        {
            this.Table("MyObject");
            this.Schema("`dbo`");
            
            this.Id(x => x.Id).Column("Id").GeneratedBy.GuidComb().Default("NEWID()");

            this.Map(x => x.Code).Length(20).Not.Nullable();

            this.Map(x => x.Description).Length(255).Not.Nullable();
        }
    }
}
