using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutmentAgency.Data
{
    public class Vacancy
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime DateBegin { get; set; }
        public virtual DateTime DateEnd { get; set; }
        public virtual string Company { get; set; }
        public virtual string Demand { get; set; }
        public virtual decimal Salary { get; set; }
        public virtual User UserId { get; set; }
    }

    public class VacancyMap: ClassMap<Vacancy>
    {
        public VacancyMap()
        {
            Id(f => f.Id);
            Map(f => f.Name).Length(255);
            Map(f => f.Description).Length(50);
            Map(f => f.DateBegin);
            Map(f => f.DateEnd);
            Map(f => f.Company);
            Map(f => f.Demand);
            Map(f => f.Salary);
            References(u => u.UserId).Column("UserId").Cascade.SaveUpdate();
        }
    }
}
